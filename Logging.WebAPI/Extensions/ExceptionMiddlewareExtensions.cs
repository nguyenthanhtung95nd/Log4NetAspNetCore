using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Logging;

namespace Logging.WebAPI.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureBuildInExceptionHandler(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    // Log all unhandled exceptions to a file
                    var _logger = loggerFactory.CreateLogger("exceptionhandlermiddleware");
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var contextRequest = context.Features.Get<IHttpRequestFeature>();

                    if (contextFeature != null)
                    {
                        var _error =
                            $"[{context.Response.StatusCode}] - {contextFeature.Error.Message} : {contextRequest.Path}";

                        // Log all unhandled exceptions to a file
                        _logger.LogError(_error);
                        await context.Response.WriteAsync(_error);
                    }
                });
            });
        }
    }
}