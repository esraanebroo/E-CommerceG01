using Domain.Exceptions;
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
            httpContext.Response.StatusCode = ex switch
            {
                NotFoundExceptions => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.NotFound,
            };
            var response=new ErrorDetails 
            {
                StatusCode=httpContext.Response.StatusCode,
                ErrorMessage=ex.Message
            }.ToString();
            await httpContext.Response.WriteAsync(response);
        }
    }
}
