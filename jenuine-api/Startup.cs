using Serilog;
using MongoDB.Driver;
using Its.Jenuiue.Core.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication;

using Its.Jenuiue.Core.Services.Products;
using Its.Jenuiue.Core.Services.Assets;
using Its.Jenuiue.Core.Services.Jobs;
using Its.Jenuiue.Api.Authentications;
using Its.Jenuiue.Api.Middlewares.AuditLog;

namespace Its.Jenuiue.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connStr = Configuration["DbSetting:ConnectionString"];
            Log.Information("Configuring services...");

            var conn = new MongoClient(connStr);
            var db = new MongoDatabase(conn);

            BasicAuthenticationRepo.SetConfiguration(Configuration);
            AuditLogMiddleware.SetConfiguration(Configuration);

            services.AddScoped<IProductsService>(sp => new ProductsService(db));
            services.AddScoped<IAssetsService>(sp => new AssetsService(db));
            services.AddScoped<IJobsService>(sp => new JobsService(db));
            services.AddSingleton<IBasicAuthenticationRepo, BasicAuthenticationRepo>();

            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);            

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "jenuine_api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "jenuine_api v1"));
            }

            app.UseHttpsRedirection();
            app.UseAuditLogMiddleware();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });            
        }
    }
}
