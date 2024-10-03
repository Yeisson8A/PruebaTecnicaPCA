using Microsoft.EntityFrameworkCore;
using PruebaTecnicaPCA.Core.CustomEntities;
using PruebaTecnicaPCA.Core.Interfaces;
using PruebaTecnicaPCA.Infrastructure.Data;

namespace PruebaTecnicaPCA.Infrastructure.Repositories
{
    public class EstadisticaRepository : IEstadisticaRepository
    {
        private readonly PruebaTecnicaPcaContext _context;

        public EstadisticaRepository(PruebaTecnicaPcaContext context)
        {
            _context = context;
        }

        // Obtener cantidad de aerolineas registradas
        public async Task<ConteoAerolineas> ObtenerCantidadAerolineas()
        {
            var conteoAerolineas = await (from v in _context.Vuelos
                                    group v by v.Aerolinea into grupo
                                    select new ConteoAerolineas
                                    {
                                        Total = grupo.Count()
                                    }).FirstOrDefaultAsync();
            return conteoAerolineas ?? new ConteoAerolineas();
        }

        // Obtener cantidad de reservas por aerolinea
        public async Task<List<ReservasPorAerolinea>> ObtenerReservasPorAerolinea()
        {
            var reservasPorAerolinea = await (from v in _context.Vuelos
                                       join r in _context.Reservas on v.Id equals r.IdVuelo into reservasJoin
                                       from reserva in reservasJoin.DefaultIfEmpty()
                                       group reserva by v.Aerolinea into grupo
                                       select new ReservasPorAerolinea
                                       {
                                           Aerolinea = grupo.Key,
                                           Total = grupo.Count(r => r != null)
                                       }).ToListAsync();
            return reservasPorAerolinea;
        }
    }
}
