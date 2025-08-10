using Parkease.Models.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IReservaRepository
{
    Task<List<Reserva>> GetReservasAsync();
    Task<List<Reserva>> GetReservasPorConductorAsync(int conductorId);
    Task<Reserva> GetReservaByIdAsync(int id);
    Task AddReservaAsync(Reserva reserva);
    Task UpdateReservaAsync(Reserva reserva);
    Task DeleteAsync(Reserva reserva);
    Task SaveAsync();
}