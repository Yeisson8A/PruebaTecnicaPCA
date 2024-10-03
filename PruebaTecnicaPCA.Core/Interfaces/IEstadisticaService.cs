using PruebaTecnicaPCA.Core.CustomEntities;

namespace PruebaTecnicaPCA.Core.Interfaces
{
    public interface IEstadisticaService
    {
        // Obtener cantidad de aerolineas registradas
        Task<ConteoAerolineas> ObtenerCantidadAerolineas();

        // Obtener cantidad de reservas por aerolinea
        Task<List<ReservasPorAerolinea>> ObtenerReservasPorAerolinea();
    }
}
