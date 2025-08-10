using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Parkease.Models;

namespace Parkease.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(); // Permitir que el Index siempre cargue
    }

    public IActionResult Reserva()
    {
        return View();
    }

    public IActionResult Factura()
    {
        return View();
    }

    public IActionResult Conocenos()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    public ActionResult Registro()
    {
        return View("~/Views/Auth/Registro.cshtml");
    }

    public IActionResult Nosotros()
    {
        return View();
    }

    public IActionResult Contacto()
    {
        return View();
    }

    public ActionResult Dashboard()
    {
        return View();
    }
    public IActionResult Error404()
    {
        return View("~/Views/Error/Error404.cshtml");
    }

    public IActionResult Error500()
    {
        return View("~/Views/Error/Error500.cshtml");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}