using PruebaTecnicaPCA.Core.CustomEntities;
using PruebaTecnicaPCA.Core.Entities;
using PruebaTecnicaPCA.Core.QueryFilters;

namespace PruebaTecnicaPCA.Core.Interfaces
{
    public interface IReservaService
    {
        // Consultar listado reservas
        PagedList<Reserva> ListaReservas(ReservaQueryFilter filters);

        // Consultar reserva existente por id
        Task<Reserva> ConsultarReserva(int id);

        // Insertar una nueva reserva
        Task InsertarReserva(Reserva reserva);
    }
}
