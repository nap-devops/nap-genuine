using System;
using Serilog;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Serilog.Sinks.Syslog;

namespace Its.Jenuiue.Api.Middlewares.AuditLog
{
    public class AuditLogMiddleware
    {
        private static IConfiguration cfg = null;
        private readonly RequestDelegate next;
        private readonly Serilog.Core.Logger syslog;

        public AuditLogMiddleware(RequestDelegate nextDelegate)
        {
            next = nextDelegate;

            var host = cfg["AuditLog:Host"];
            var port = cfg["AuditLog:Port"];
            
            int portInt;
            int.TryParse(port, out portInt);

            syslog = new LoggerConfiguration()
                .WriteTo.UdpSyslog(host, portInt, format: SyslogFormat.RFC5424)
                .CreateLogger();
        }

        public static void SetConfiguration(IConfiguration config)
        {
            cfg = config;
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
            syslog.Information(json);
        }
    }
}
