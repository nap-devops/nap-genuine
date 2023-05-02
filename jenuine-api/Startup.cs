using System;
using Serilog;
using System.Text;
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
using Its.Jenuiue.Core.Services.Configs;
using Its.Jenuiue.Core.Services.Customers;
using Its.Jenuiue.Api.Authentications;
using Its.Jenuiue.Api.Middlewares.AuditLog;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

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
            services.AddScoped<IConfigsService>(sp => new ConfigsService(db));
            services.AddScoped<ICustomersService>(sp => new CustomersService(db));
            services.AddSingleton<IBasicAuthenticationRepo, BasicAuthenticationRepo>();

            BasicAuthenticationHandlerKeycloak.SetConfiguration(Configuration);

            services.AddAuthentication("Basic")
                .AddJwtBearer("BearerKeycloak", o => {
                    byte[] data = Convert.FromBase64String(Configuration["BearerAuthen:Keycloak:jsonKey"]);
                    string decodedString = Encoding.UTF8.GetString(data);

                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration["BearerAuthen:Keycloak:issuer"],
                        ValidAudience = Configuration["BearerAuthen:Keycloak:audience"],
                        IssuerSigningKey = new JsonWebKey(decodedString),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                    };
                })
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandlerKeycloak>("Basic", null);

            services.AddAuthorization(options => {
                var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder("Basic", "BearerKeycloak");
                defaultAuthorizationPolicyBuilder = defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
                options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true);
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
