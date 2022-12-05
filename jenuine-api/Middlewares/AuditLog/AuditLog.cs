using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading.Tasks;

namespace Its.Jenuiue.Api.Middlewares.AuditLog
{
    public class Api
    {
        private HttpContext ctx;
        private readonly string pattern1 = @"^\/api\/(.+?)\/org\/(.+)\/action\/(.+)$";
        private readonly string pattern2 = @"^\/api\/(.+?)\/org\/(.+)\/action\/(.+)\/(.+)$";

        public Api(HttpContext httpContext)
        {
            ctx = httpContext;

            path = ctx.Request.Path.ToString();
            claims = new Dictionary<string, string>();

            // /api/products/org/napbiotec/action/GetProducts

            MatchCollection matches = Regex.Matches(path, pattern1);
            if (matches.Count > 0)
            {
                resourceType = matches[0].Groups[1].Value;
                organzation = matches[0].Groups[2].Value;
                action = matches[0].Groups[3].Value;
            }
            else
            {
                matches = Regex.Matches(path, pattern2);
                if (matches.Count > 0)
                {
                    resourceType = matches[0].Groups[1].Value;
                    organzation = matches[0].Groups[2].Value;
                    action = matches[0].Groups[3].Value;
                    resourceId = matches[0].Groups[4].Value;
                }
            }

            foreach (Claim clm in ctx.User.Claims)
            {
                var type = Path.GetFileName(clm.Type);
                claims[type] = clm.Value;
            }

            method = ctx.Request.Method;

            //StreamReader reader = new StreamReader(ctx.Request.Body);
            //var t = reader.ReadToEndAsync();
            //t.Wait();
            //inputParam = t.Result;
        }

        public string path { get; set; }
        public string method { get; set; }
        public string resourceType { get; set; }
        public string organzation { get; set; }
        public string action { get; set; }
        public string resourceId { get; set; }
        //public string inputParam { get; set; }
        public Dictionary<string, string> claims { get; set; }
    }

    public class Connection
    {
        private HttpContext ctx;

        public Connection(HttpContext httpContext)
        {
            ctx = httpContext;

            remoteIP = ctx.Connection.RemoteIpAddress.ToString();
            remotePort = ctx.Connection.RemotePort;
            localIP = ctx.Connection.LocalIpAddress.ToString();
            localPort = ctx.Connection.LocalPort;            
        }

        public string remoteIP { get; set; }
        public int remotePort { get; set; }
        public string localIP { get; set; }
        public int localPort { get; set; }
    }

    public class Response
    {
        private HttpContext ctx;
        
        public Response(HttpContext httpContext)
        {
            ctx = httpContext;

            status = ctx.Response.StatusCode;
            size = ctx.Response.ContentLength;
            contentType = ctx.Response.ContentType;
        }

        public int status { get; set; }
        public long? size { get; set; }
        public string contentType { get; set; }
    }

    public class Request
    {
        private HttpContext ctx;
        public Request(HttpContext httpContext)
        {
            ctx = httpContext;

            path = ctx.Request.Path.ToString();
            pathBase = ctx.Request.PathBase.ToString();
            queryString = ctx.Request.QueryString.ToString();
            size = ctx.Request.ContentLength;
            method = ctx.Request.Method;
            contentType = ctx.Request.ContentType;
            userAgent = ctx.Request.Headers["User-Agent"];
            host = ctx.Request.Host.Host;
        }

        public string path { get; set; }
        public string pathBase { get; set; }
        public string queryString { get; set; }
        public long? size { get; set; }
        public string method { get; set; }
        public string contentType { get; set; }
        public string userAgent { get; set; }
        public string host { get; set; }
    }

    public class AuditLog
    {
        private HttpContext ctx;

        public Connection connection { get; set; }
        public Request request { get; set; }
        public Response response { get; set; }
        public Api api { get; set; }

        public string id { get; set; }
        public DateTime eventDtm { get; set; }
        public double latencyMs { get; set; }
        
        public AuditLog(HttpContext httpContext)
        {
            ctx = httpContext;

            connection = new Connection(ctx);
            request = new Request(ctx);
            response = new Response(ctx);
            api = new Api(ctx);

            id = ctx.Connection.Id;
            eventDtm = DateTime.Now;
        }
    }
}
