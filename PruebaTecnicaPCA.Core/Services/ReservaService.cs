using PruebaTecnicaPCA.Core.CustomEntities;
using PruebaTecnicaPCA.Core.Entities;
using PruebaTecnicaPCA.Core.Exceptions;
using PruebaTecnicaPCA.Core.Interfaces;
using PruebaTecnicaPCA.Core.QueryFilters;

namespace PruebaTecnicaPCA.Core.Services
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IVueloRepository _vueloRepository;

        public ReservaService(IReservaRepository reservaRepository, IVueloRepository vueloRepository)
        {
            _reservaRepository = reservaRepository;
            _vueloRepository = vueloRepository;
        }

        // Consultar reserva existente por id
        public async Task<Reserva> ConsultarReserva(int id)
        {
            return await _reservaRepository.ConsultarReserva(id);
        }

        // Insertar una nueva reserva
        public async Task InsertarReserva(Reserva reserva)
        {
            var vuelo = await _vueloRepository.ConsultarVuelo(reserva.IdVuelo);

            if (vuelo == null)
            {
                throw new BusinessException("El vuelo a reservar no existe");
            }
            await _reservaRepository.InsertarReserva(reserva);
        }

        // Consultar listado de reservas
        public PagedList<Reserva> ListaReservas(ReservaQueryFilter filters)
        {
            var reservas = _reservaRepository.ListaReservas();
            // Aplicar paginación a los datos a devolver
            var pagedReservas = PagedList<Reserva>.Create(reservas, filters.PageNumber, filters.PageSize);
            return pagedReservas;
        }
    }
}
