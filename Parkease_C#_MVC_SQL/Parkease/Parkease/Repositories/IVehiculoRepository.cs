using Parkease.Models.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IVehiculoRepository
{
    Task<IEnumerable<Vehiculo>> ObtenerTodos();
    Task<Vehiculo> ObtenerPorId(int id);
    Task Agregar(Vehiculo vehiculo);
    Task Actualizar(Vehiculo vehiculo);
    Task Eliminar(int id);
    Task<List<Conductor>> ObtenerConductores();
}