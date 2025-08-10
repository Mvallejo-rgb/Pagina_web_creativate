using Microsoft.EntityFrameworkCore;
using Parkease.Models;
using Parkease.Models.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ReservaRepository : IReservaRepository
{
    private readonly AplicationDBcontext _context;

    public ReservaRepository(AplicationDBcontext context)
    {
        _context = context;
    }

    public async Task<List<Reserva>> GetReservasAsync()
    {
        return await _context.Reserva.ToListAsync();
    }

    public async Task<List<Reserva>> GetReservasPorConductorAsync(int conductorId)
    {
        return await _context.Reserva.Where(r => r.idConductor == conductorId).ToListAsync();
    }

    public async Task<Reserva> GetReservaByIdAsync(int id)
    {
        return await _context.Reserva.FindAsync(id);
    }

    public async Task AddReservaAsync(Reserva reserva)
    {
        await _context.Reserva.AddAsync(reserva);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateReservaAsync(Reserva reserva)
    {
        var reservaExistente = await _context.Reserva.AsNoTracking()
            .FirstOrDefaultAsync(r => r.idReserva == reserva.idReserva);

        if (reservaExistente == null)
        {
            throw new KeyNotFoundException("Reserva no encontrada");
        }

        // Mantener el idConductor original para evitar errores de clave foránea
        reserva.idConductor = reservaExistente.idConductor;

        _context.Reserva.Update(reserva);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Reserva reserva)
    {
        _context.Reserva.Remove(reserva);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}