using Microsoft.AspNetCore.Mvc;

public class DashBoardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}