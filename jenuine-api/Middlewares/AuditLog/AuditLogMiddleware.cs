using System;
using Serilog;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IO;

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
            DateTime beginTime = DateTime.Now;
            await next(httpContext);
            DateTime endTime = DateTime.Now;

            TimeSpan ts = endTime - beginTime;

            var auditLog = new AuditLog(httpContext);
            auditLog.latencyMs = ts.TotalMilliseconds;

            var json = JsonConvert.SerializeObject(auditLog);

            Log.Information(json);
        }
    }
}
