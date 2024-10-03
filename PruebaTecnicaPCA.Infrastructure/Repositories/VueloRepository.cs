using PruebaTecnicaPCA.Core.Entities;
using PruebaTecnicaPCA.Core.Interfaces;
using PruebaTecnicaPCA.Infrastructure.Data;

namespace PruebaTecnicaPCA.Infrastructure.Repositories
{
    public class VueloRepository : IVueloRepository
    {
        private readonly PruebaTecnicaPcaContext _context;

        public VueloRepository(PruebaTecnicaPcaContext context)
        {
            _context = context;
        }

        // Actualizar vuelo existente
        public async Task<bool> ActualizarVuelo(Vuelo vuelo)
        {
            _context.Vuelos.Update(vuelo);
            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        // Consultar vuelo existente por id
        public async Task<Vuelo> ConsultarVuelo(int id)
        {
            var vuelo = await _context.Vuelos.FindAsync(id);
            return vuelo;
        }

        // Eliminar vuelo existente
        public async Task<bool> EliminarVuelo(int id)
        {
            var vuelo = await _context.Vuelos.FindAsync(id);
            _context.Vuelos.Remove(vuelo);
            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        // Insertar un nuevo vuelo
        public async Task InsertarVuelo(Vuelo vuelo)
        {
            _context.Vuelos.Add(vuelo);
            await _context.SaveChangesAsync();
        }

        // Consultar listado de vuelos
        public List<Vuelo> ListaVuelos()
        {
            var vuelos = _context.Vuelos.Where(x => x.Disponible).ToList();
            return vuelos;
        }
    }
}
