using Microsoft.EntityFrameworkCore;
using PruebaTecnicaPCA.Core.Entities;
using PruebaTecnicaPCA.Core.Interfaces;
using PruebaTecnicaPCA.Infrastructure.Data;

namespace PruebaTecnicaPCA.Infrastructure.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly PruebaTecnicaPcaContext _context;

        public ReservaRepository(PruebaTecnicaPcaContext context)
        {
            _context = context;
        }

        // Consultar reserva existente por id
        public async Task<Reserva> ConsultarReserva(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            return reserva;
        }

        // Consultar primera reserva para un id vuelo especifico
        public async Task<Reserva> ConsultarReservaPorIdVuelo(int idVuelo)
        {
            var reserva = await _context.Reservas.FirstOrDefaultAsync(x => x.IdVuelo == idVuelo);
            return reserva;
        }

        // Insertar nueva reserva
        public async Task InsertarReserva(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();
        }

        // Consultar listado de reservas
        public List<Reserva> ListaReservas()
        {
            var reservas = _context.Reservas.ToList();
            return reservas;
        }
    }
}
