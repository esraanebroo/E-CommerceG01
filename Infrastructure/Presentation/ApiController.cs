using Microsoft.AspNetCore.Mvc;
using Shared.ErrorModels;
using System.Net;

namespace Presentation
{
    [Controller]
    [Route("api/[Controller]")]
    [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ValidtionErrorResponse), (int)HttpStatusCode.BadRequest)]
    public class ApiController:ControllerBase
    {



    }
}
