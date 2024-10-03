using PruebaTecnicaPCA.Core.Entities;

namespace PruebaTecnicaPCA.Core.Interfaces
{
    public interface IVueloRepository
    {
        // Consultar listado de vuelos
        List<Vuelo> ListaVuelos();

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
