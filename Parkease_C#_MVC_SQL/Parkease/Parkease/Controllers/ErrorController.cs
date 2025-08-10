using Microsoft.AspNetCore.Mvc;

public class ErrorController : Controller
{
    [Route("Error/Error500")]
    public IActionResult Error500()
    {
        return View();
    }

    [Route("Error/Error404")]
    public IActionResult Error404()
    {
        return View();
    }
}