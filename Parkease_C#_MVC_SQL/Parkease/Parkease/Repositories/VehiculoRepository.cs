using Microsoft.EntityFrameworkCore;
using Parkease.Models;
using Parkease.Models.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

public class VehiculoRepository : IVehiculoRepository
{
    private readonly AplicationDBcontext _context;

    public VehiculoRepository(AplicationDBcontext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Vehiculo>> ObtenerTodos()
    {
        return await _context.Vehiculo.Include(v => v.Conductor).ToListAsync();
    }

    public async Task<Vehiculo> ObtenerPorId(int id)
    {
        return await _context.Vehiculo.Include(v => v.Conductor).FirstOrDefaultAsync(v => v.idVehiculo == id);
    }

    public async Task Agregar(Vehiculo vehiculo)
    {
        await _context.Vehiculo.AddAsync(vehiculo);
        await _context.SaveChangesAsync();
    }

    public async Task Actualizar(Vehiculo vehiculo)
    {
        _context.Vehiculo.Update(vehiculo);
        await _context.SaveChangesAsync();
    }

    public async Task Eliminar(int id)
    {
        var vehiculo = await ObtenerPorId(id);
        if (vehiculo != null)
        {
            _context.Vehiculo.Remove(vehiculo);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Conductor>> ObtenerConductores()
    {
        return await _context.Conductor.ToListAsync();
    }
}