using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Shared.ErrorModels;
using System.Net;

namespace E_CommerceG01.Middlewares
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalErrorHandlingMiddleware> _logger;

        public GlobalErrorHandlingMiddleware(RequestDelegate next,ILogger<GlobalErrorHandlingMiddleware> logger )
        {
           _next = next;
           _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext) 
        {
            try
            {
                await _next(httpContext);
                if (httpContext.Response.StatusCode == (int)HttpStatusCode.NotFound)
                    await HandeNotFoundExceptionAsync(httpContext);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something Went wrong : {ex}");
                await HandleExceptionAsync(httpContext, ex);

            }
        }

        private async Task HandeNotFoundExceptionAsync(HttpContext httpContext)
        {
            httpContext.Response.ContentType = "application/json";
            var response=new ErrorDetails
            {
                StatusCode=(int) HttpStatusCode.NotFound,
                ErrorMessage=$"The End point {httpContext.Request.Path} not Found"
            }.ToString();
            await httpContext.Response.WriteAsync(response);
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";//set content type [application/Json]
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;//500
            var response = new ErrorDetails
            {
                ErrorMessage = ex.Message
            };
            httpContext.Response.StatusCode = ex switch
            {
                NotFoundExceptions => (int)HttpStatusCode.NotFound,//404
                UnauthorizedException => (int)HttpStatusCode.Unauthorized, //401
                ValidtionException validtionException => HandelValiationException(validtionException,response),
                _ => (int)HttpStatusCode.InternalServerError, //500
            };
           
            await httpContext.Response.WriteAsync(response.ToString());
        }

        private int HandelValiationException(ValidtionException validtionException, ErrorDetails response)
        {
           response.Errors= validtionException.Errors;
            return (int)HttpStatusCode.BadRequest;
        }
    }
}
