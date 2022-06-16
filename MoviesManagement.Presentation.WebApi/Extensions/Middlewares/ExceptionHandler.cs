using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MoviesManagement.Core.Application.Commons;
using MoviesManagement.Core.Application.Exceptions.Basic;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace MoviesManagement.Presentation.WebApi.Extensions.Middlewares
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandler> _logger;

        public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string titleText = "Internal Server Error.";
            var statusCode = (int)HttpStatusCode.InternalServerError;
            var traceId = Activity.Current?.Id ?? context?.TraceIdentifier;

            switch (exception)
            {
                case EntityValidationException e:
                    titleText = "One or more validation errors occurred.";
                    statusCode = (int)e.StatusCode;
                    break;
                case ValidationException _:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case Exception _:
                    _logger.LogError(exception, exception.Message);
                    exception = new Exception("Internal Server Error");
                    break;
            }


            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsync(
            JsonConvert.SerializeObject(Result.Failure(
                titleText: titleText,
                statusCode: statusCode,
                traceId: traceId,
                exception: exception
            )));
        }
    }
}
