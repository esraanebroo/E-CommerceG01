using Microsoft.AspNetCore.Mvc;
using Shared.ErrorModels;
using System.Net;

namespace E_CommerceG01.Factories
{
    public class ApiResponseFactory
    {

        public static IActionResult CustomValidtionErrorResponse(ActionContext context0)
        {
            var error = context0.ModelState.Where(error => error.Value.Errors.Any()).Select(error =>
            new ValidationError
            {
                Field = error.Key,
                Errors = error.Value.Errors.Select(e => e.ErrorMessage)
            });
            var response = new ValidtionErrorResponse()
            {
                Errors = error,
                StatusCode = (int)HttpStatusCode.BadRequest,
                ErrorMessage="Validation Faild"
            };
            return new BadRequestObjectResult(response);
        }
    }
}
