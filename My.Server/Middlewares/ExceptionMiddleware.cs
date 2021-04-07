using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using My.Server.ResponseModels;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace My.Server.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string contentType = "application/json";
            var jSerializerOption = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            try
            {
                await _next(context);
            }
           
            catch (Exception ex)
            {

                int statusCode = 500;
                context.Response.ContentType = contentType;
                context.Response.StatusCode = statusCode;
                string response = JsonSerializer.Serialize(
                    new ErrorResponseModel
                    {
                        StatusCode = statusCode,
                        Message = ex.Message,
                        Details =ex.Message
                    }, jSerializerOption);
                _logger.LogError(response, ex);
                await context.Response.WriteAsync(response);

            }
        }
    }
}

