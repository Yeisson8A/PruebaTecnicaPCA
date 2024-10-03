using PruebaTecnicaPCA.Core.CustomEntities;
using PruebaTecnicaPCA.Core.Entities;
using PruebaTecnicaPCA.Core.QueryFilters;

namespace PruebaTecnicaPCA.Core.Interfaces
{
    public interface IVueloService
    {
        // Consultar listado de vuelos
        PagedList<Vuelo> ListaVuelos(VueloQueryFilter filters);

        // Consultar vuelo existente por id
        Task<Vuelo> ConsultarVuelo(int id);

        // Insertar un nuevo vuelo
        Task InsertarVuelo(Vuelo vuelo);

        // Actualizar vuelo existente
        Task<bool> ActualizarVuelo(Vuelo vuelo);

        // Eliminar vuelo existente
        Task<bool> EliminarVuelo(int id);
    }
}
