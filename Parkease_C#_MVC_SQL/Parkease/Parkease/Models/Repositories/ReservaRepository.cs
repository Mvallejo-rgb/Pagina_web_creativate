using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parkease.Models;
namespace Parkease.Models.Entidades;

public class ReservaRepository
{
    private readonly AplicationDBcontext _context;

    public ReservaRepository(AplicationDBcontext context)
    {
        _context = context;
    }

    public List<Reserva> GetReservas()
    {
        return _context.Reserva.ToList();
    }

    public async Task<List<Reserva>> GetReservasAsync()
    {
        return await _context.Reserva.ToListAsync();
    }

    public async Task<List<Reserva>> GetReservasPorConductorAsync(int conductorId)
    {
        return await _context.Reserva
            .Where(r => r.ConductorId == conductorId)
            .ToListAsync();
    }

    public async Task<Reserva> GetReservaByIdAsync(int id)
    {
        return await _context.Reserva.FindAsync(id);
    }

    public async Task AddReservaAsync(Reserva reserva)
    {
        _context.Reserva.Add(reserva);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateReservaAsync(Reserva reserva)
    {
        _context.Reserva.Update(reserva);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteReservaAsync(int id)
    {
        var reserva = await _context.Reserva.FindAsync(id);
        if (reserva != null)
        {
            _context.Reserva.Remove(reserva);
            await _context.SaveChangesAsync();
        }
    }
}
