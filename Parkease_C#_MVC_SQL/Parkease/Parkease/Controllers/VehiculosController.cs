using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using Parkease.Models.Entidades;
using Parkease.Models;

public class VehiculosController : Controller
{
    private readonly AplicationDBcontext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public VehiculosController(AplicationDBcontext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }

    // ✅ Listar Vehículos
    public async Task<IActionResult> Index()
    {
        var vehiculos = await _context.Vehiculo.ToListAsync();
        return View(vehiculos);
    }
    public async Task<IActionResult> VerVehiculo(int id)
    {
        var vehiculo = await _context.Vehiculo.FindAsync(id);
        if (vehiculo == null)
        {
            return NotFound();
        }
        return View(vehiculo);
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Vehiculo vehiculo, IFormFile imagen)
    {
        if (ModelState.IsValid)
        {
            try
            {
                if (imagen != null && imagen.Length > 0)
                {
                    // Definir la ruta donde se guardarán las imágenes
                    string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "imagenesVehiculos");

                    // Crear la carpeta si no existe
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                  
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imagen.FileName);
                    string filePath = Path.Combine(folderPath, fileName);

                   
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imagen.CopyToAsync(stream);
                    }

                   
                    vehiculo.imagenReserva = $"/imagenesVehiculos/{fileName}";
                }
                else
                {
                    vehiculo.imagenReserva = "/imagenesVehiculos/default.jpg";
                }

                // Guardar el vehículo en la base de datos
                _context.Vehiculo.Add(vehiculo);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al subir la imagen: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
                ModelState.AddModelError("", "Hubo un error al guardar la imagen.");
            }
        }

        return View(vehiculo);
    }
    [HttpPost]
    public async Task<IActionResult> EditarVehiculo(Vehiculo vehiculo, IFormFile imagen)
    {
        if (!ModelState.IsValid)
        {
            return View("VerVehiculo", vehiculo);
        }

        try
        {
            var vehiculoDb = await _context.Vehiculo.FindAsync(vehiculo.idVehiculo);
            if (vehiculoDb == null)
            {
                return NotFound();
            }

            // Actualizar los datos del vehículo
            vehiculoDb.placaVeh = vehiculo.placaVeh;
            vehiculoDb.marcaVeh = vehiculo.marcaVeh;
            vehiculoDb.modeloVeh = vehiculo.modeloVeh;
            vehiculoDb.colorVeh = vehiculo.colorVeh;
            vehiculoDb.tipoVeh = vehiculo.tipoVeh;

            if (imagen != null && imagen.Length > 0)
            {
                string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "imagenesVehiculos");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

             
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imagen.FileName);
                string filePath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imagen.CopyToAsync(stream);
                }

                // Eliminar la imagen anterior si existía
                if (!string.IsNullOrEmpty(vehiculoDb.imagenReserva))
                {
                    string oldFilePath = Path.Combine(folderPath, vehiculoDb.imagenReserva);
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }

             
                vehiculoDb.imagenReserva = fileName;
            }

            _context.Update(vehiculoDb);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al actualizar el vehículo: {ex.Message}");
            return View("VerVehiculo", vehiculo);
        }
    }
    [HttpPost]
    public async Task<IActionResult> EliminarVehiculo(int idVehiculo)
    {
        var vehiculo = await _context.Vehiculo.FindAsync(idVehiculo);
        if (vehiculo == null)
        {
            return NotFound();
        }
        try
        {
            // Eliminar la imagen si existe
            if (!string.IsNullOrEmpty(vehiculo.imagenReserva))
            {
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "imagenesVehiculos", vehiculo.imagenReserva);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            _context.Vehiculo.Remove(vehiculo);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al eliminar el vehículo: {ex.Message}");
            return RedirectToAction("VerVehiculo", new { id = idVehiculo });
        }
    }
}