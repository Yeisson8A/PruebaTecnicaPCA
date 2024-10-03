using PruebaTecnicaPCA.Core.Entities;

namespace PruebaTecnicaPCA.Core.Interfaces
{
    public interface IReservaRepository
    {
        // Consultar listado reservas
        List<Reserva> ListaReservas();

        // Consultar reserva existente por id
        Task<Reserva> ConsultarReserva(int id);

        // Consultar primera reserva para un id vuelo especifico
        Task<Reserva> ConsultarReservaPorIdVuelo(int idVuelo);

        // Insertar una nueva reserva
        Task InsertarReserva(Reserva reserva);
    }
}
