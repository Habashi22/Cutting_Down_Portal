using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Utilities.MiddelWare
{
    public class BandwidthLimitMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<BandwidthLimitMiddleware> _logger;
        private readonly long _maxBytes = 1024 * 1024; // 1MB for example

        public BandwidthLimitMiddleware(RequestDelegate next, ILogger<BandwidthLimitMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Request.EnableBuffering();

            if (context.Request.ContentLength > _maxBytes)
            {
                context.Response.StatusCode = 413; // Payload Too Large
                await context.Response.WriteAsync("Payload too large.");
                return;
            }

            await _next(context);
        }
    }

}
