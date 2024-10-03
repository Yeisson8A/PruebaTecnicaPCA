using PruebaTecnicaPCA.Core.CustomEntities;
using PruebaTecnicaPCA.Core.Interfaces;

namespace PruebaTecnicaPCA.Core.Services
{
    public class EstadisticaService : IEstadisticaService
    {
        private readonly IEstadisticaRepository _estadisticaRepository;

        public EstadisticaService(IEstadisticaRepository estadisticaRepository)
        {
            _estadisticaRepository = estadisticaRepository;
        }

        // Obtener cantidad de aerolineas registradas
        public async Task<ConteoAerolineas> ObtenerCantidadAerolineas()
        {
            return await _estadisticaRepository.ObtenerCantidadAerolineas();
        }

        // Obtener cantidad de reservas por aerolinea
        public async Task<List<ReservasPorAerolinea>> ObtenerReservasPorAerolinea()
        {
            return await _estadisticaRepository.ObtenerReservasPorAerolinea();
        }
    }
}
