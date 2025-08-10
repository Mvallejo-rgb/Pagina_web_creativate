using Microsoft.AspNetCore.Mvc;
using Parkease.Models.Entidades;

public class ReservaController : Controller
{
    private readonly IReservaRepository _reservaRepo;

    public ReservaController(IReservaRepository reservaRepo)
    {
        _reservaRepo = reservaRepo;
    }
    // Mostrar todas las reservas
    public async Task<IActionResult> Index()
    {
        try
        {
            var reservas = await _reservaRepo.GetReservasAsync();
            return View(reservas);
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Error al obtener reservas: {ex.Message}";
            return View(new List<Reserva>());
        }
    }

    public async Task<IActionResult> MisReservas()
    {
        int conductorId = ObtenerConductorIdDesdeSesion(); // Método para obtener el ID
        var reservas = await _reservaRepo.GetReservasPorConductorAsync(conductorId);
        return View(reservas);
    }

    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Reserva reserva)
    {
        if (ModelState.IsValid)
        {
            reserva.idConductor = ObtenerConductorIdDesdeSesion(); // Asignar el ID del usuario autenticado
            await _reservaRepo.AddReservaAsync(reserva);
            TempData["SuccessMessage"] = "¡Reserva creada con éxito!";
            return RedirectToAction("MisReservas");
        }
        return View(reserva);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var reserva = await _reservaRepo.GetReservaByIdAsync(id);
        if (reserva == null)
        {
            return NotFound();
        }
        return View(reserva);
    }

    // Guardar cambios en una reserva
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Reserva reserva)
    {
        if (ModelState.IsValid)
        {
            await _reservaRepo.UpdateReservaAsync(reserva);
            TempData["SuccessMessage"] = "¡Reserva actualizada con éxito!";
            return RedirectToAction("MisReservas");
        }
        return View(reserva);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var reserva = await _reservaRepo.GetReservaByIdAsync(id);
        if (reserva == null)
        {
            return NotFound();
        }
        return View(reserva);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var reserva = await _reservaRepo.GetReservaByIdAsync(id); // Usa un método del repositorio para obtener la reserva
        if (reserva == null)
        {
            return NotFound();
        }

        await _reservaRepo.DeleteAsync(reserva);
        await _reservaRepo.SaveAsync();

        return RedirectToAction(nameof(MisReservas));
    }
    private int ObtenerConductorIdDesdeSesion()
    {
        return 1;
    }
}