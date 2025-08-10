using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parkease.Models;
using Parkease.Models.Entidades;
using System.Linq;

namespace Parkease.Controllers
{
    public class PerfilController : Controller
    {
        private readonly AplicationDBcontext _context;

        public PerfilController(AplicationDBcontext context)
        {
            _context = context;
        }

        // Mostrar los datos del usuario
        public IActionResult Index()
        {
            int idConductor = int.Parse(HttpContext.Session.GetString("UserId"));
            var conductor = _context.Conductor.FirstOrDefault(c => c.idConductor == idConductor);

            if (conductor == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            return View(conductor);
        }

        // Editar los datos del usuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Conductor conductor)
        {
            int idConductor = int.Parse(HttpContext.Session.GetString("UserId"));
            var conductorDb = _context.Conductor.FirstOrDefault(c => c.idConductor == idConductor);

            if (conductorDb == null)
            {
                TempData["ErrorMessage"] = "Usuario no encontrado.";
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                // Actualizar los datos
                conductorDb.primerNombre = conductor.primerNombre;
                conductorDb.primerApellido = conductor.primerApellido;
                conductorDb.numDocu = conductor.numDocu;
                conductorDb.correo = conductor.correo;
                conductorDb.edad = conductor.edad;
                conductorDb.placa = conductor.placa;

                // Actualizar la contraseña si se proporcionó
                if (!string.IsNullOrEmpty(conductor.contrasena) && conductor.contrasena == conductor.confirmaContra)
                {
                    conductorDb.contrasena = conductor.contrasena;
                }

                _context.SaveChanges();
                TempData["SuccessMessage"] = "Perfil actualizado con éxito.";
                return RedirectToAction("Index");
            }

            TempData["ErrorMessage"] = "Error en la actualización. Verifica los datos.";
            return View(conductor);
        }
    }
}