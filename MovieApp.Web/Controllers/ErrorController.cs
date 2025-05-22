using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Web.Controllers;

public class ErrorController : Controller
{
    [Route("error/statuscode/{statusCode}")]
    public IActionResult HttpError(int statusCode)
    {
        return View(statusCode);
    }

    [Route("error/exception/")]
    public IActionResult ServerError()
    {
        var error = HttpContext.Features.Get<IExceptionHandlerPathFeature>()?.Error;
        if (error != null)
        {
            Console.Error.WriteLine(error.Message);
            //Debug.WriteLine(error.Message);
        }
        return View();
    }
}
