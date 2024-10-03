using PruebaTecnicaPCA.Core.CustomEntities;
using PruebaTecnicaPCA.Core.Entities;
using PruebaTecnicaPCA.Core.Exceptions;
using PruebaTecnicaPCA.Core.Interfaces;
using PruebaTecnicaPCA.Core.QueryFilters;

namespace PruebaTecnicaPCA.Core.Services
{
    public class VueloService : IVueloService
    {
        private readonly IVueloRepository _vueloRepository;
        private readonly IReservaRepository _reservaRepository;

        public VueloService(IVueloRepository vueloRepository, IReservaRepository reservaRepository)
        {
            _vueloRepository = vueloRepository;
            _reservaRepository = reservaRepository;
        }

        // Actualizar vuelo existente
        public async Task<bool> ActualizarVuelo(Vuelo vuelo)
        {
            return await _vueloRepository.ActualizarVuelo(vuelo);
        }

        // Consultar vuelo existente por id
        public async Task<Vuelo> ConsultarVuelo(int id)
        {
            return await _vueloRepository.ConsultarVuelo(id);
        }

        // Eliminar vuelo existente
        public async Task<bool> EliminarVuelo(int id)
        {
            var reservaExistente = await _reservaRepository.ConsultarReservaPorIdVuelo(id);

            if (reservaExistente != null)
            {
                throw new BusinessException("El vuelo no se puede eliminar, ya que tiene por lo menos una reserva asociada");
            }
            return await _vueloRepository.EliminarVuelo(id);
        }

        // Insertar un nuevo vuelo
        public async Task InsertarVuelo(Vuelo vuelo)
        {
            await _vueloRepository.InsertarVuelo(vuelo);
        }

        // Consultar listado de vuelos
        public PagedList<Vuelo> ListaVuelos(VueloQueryFilter filters)
        {
            var vuelos = _vueloRepository.ListaVuelos();

            // Aplicar filtros a los datos
            if (filters.Origen != null)
            {
                vuelos = vuelos.Where(x => x.Origen.ToLower().Contains(filters.Origen.ToLower())).ToList();
            }

            if (filters.Destino != null)
            {
                vuelos = vuelos.Where(x => x.Destino.ToLower().Contains(filters.Destino.ToLower())).ToList();
            }

            if (filters.FechaSalida != null)
            {
                vuelos = vuelos.Where(x => x.FechaSalida.ToShortDateString() == filters.FechaSalida?.ToShortDateString()).ToList();
            }

            if (filters.FechaLlegada != null)
            {
                vuelos = vuelos.Where(x => x.FechaLlegada.ToShortDateString() == filters.FechaLlegada?.ToShortDateString()).ToList();
            }

            // Aplicar paginación a los datos a devolver
            var pagedVuelos = PagedList<Vuelo>.Create(vuelos, filters.PageNumber, filters.PageSize);
            return pagedVuelos;
        }
    }
}
