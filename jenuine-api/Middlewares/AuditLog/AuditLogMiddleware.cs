using Serilog;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Its.Jenuiue.Api.Middlewares.AuditLog
{
    public class AuditLogMiddleware
    {
        private readonly RequestDelegate next;

        public AuditLogMiddleware(RequestDelegate nextDelegate)
        {
            next = nextDelegate;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            Log.Information($"Begin audit log ...[{httpContext.Request.Path}]");
            await next(httpContext);
            Log.Information($"End audit log [{httpContext.Connection.RemoteIpAddress}]");
        }
    }
}
