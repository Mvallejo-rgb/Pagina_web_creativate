using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parkease.Models;
using Parkease.Models.Entidades;
using System;

namespace Parkease.Controllers
{
    public class FacturacionController : Controller
    {
        private readonly AplicationDBcontext _context;

        public FacturacionController(AplicationDBcontext context)
        {
            _context = context;
        }

        public IActionResult Factura()
        {
            return View(new Factura());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SolicitarFactura(Factura factura)
        {
            try
            {
                _context.Factura.Add(factura);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Solicitud enviada correctamente.";
                return RedirectToAction("ConfirmacionFactura");
            }
            catch (DbUpdateException ex)
            {
                var errorMessage = ex.InnerException?.Message ?? ex.Message;
                return BadRequest($"Error al guardar la factura: {errorMessage}");
            }
            return View(factura);
        }

        public IActionResult ConfirmacionFactura()
        {
            return View();
        }
    }
}