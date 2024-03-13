using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace DietitianTrackingSystemApp.Core.Extensions
{
    public static class HttpContextExtensions
    {
        /// <summary>
        /// If the request header has a X-Request-Id value, it returns that value, otherwise it uses the .net core generated value.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetRequestId(this HttpContext context)
        {
            if (context.Request.Headers.ContainsKey("X-Request-Id"))
            {
                return context.Request.Headers["X-Request-Id"].First();
            }

            var requestIdFeature = context.Features.Get<IHttpRequestIdentifierFeature>();

            return requestIdFeature != null && !string.IsNullOrEmpty(requestIdFeature.TraceIdentifier) ? requestIdFeature.TraceIdentifier : Guid.NewGuid().ToString();
        }
    }
}