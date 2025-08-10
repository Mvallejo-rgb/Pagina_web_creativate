using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Parkease.Models;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Parkease.Models.Entidades;

namespace Parkease.Controllers
{
    public class AuthController : Controller
    {
        private readonly AplicationDBcontext _context;

        public AuthController(AplicationDBcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registro(Conductor conductor)
        {
            if (ModelState.IsValid)
            {
                _context.Conductor.Add(conductor);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Registro exitoso. ¡Inicia sesión!";
                return RedirectToAction("Login");
            }
            return View(conductor);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string correo, string contrasena)
        {
            var usuario = _context.Conductor.FirstOrDefault(u => u.correo == correo);

            if (usuario == null || usuario.contrasena != contrasena)
            {
                ModelState.AddModelError(string.Empty, "Correo o contraseña incorrectos.");
                return View();
            }

            // Guardar sesión
            HttpContext.Session.SetString("UserId", usuario.idConductor.ToString());
            HttpContext.Session.SetString("Email", usuario.correo);  // Guardar el correo en la sesión

            return RedirectToAction("Index", "DashBoard");
        }

      
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
    }
}