using Microsoft.AspNetCore.Builder;

namespace Its.Jenuiue.Api.Middlewares.AuditLog
{
    public static class AuditLogMiddlewareExt
    {
        public static IApplicationBuilder UseAuditLogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuditLogMiddleware>();
        }
    }
}