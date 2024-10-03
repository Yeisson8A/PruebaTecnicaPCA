using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PruebaTecnicaPCA.Api.Responses;
using PruebaTecnicaPCA.Core.CustomEntities;
using PruebaTecnicaPCA.Core.DTOs;
using PruebaTecnicaPCA.Core.Entities;
using PruebaTecnicaPCA.Core.Interfaces;
using PruebaTecnicaPCA.Core.QueryFilters;

namespace PruebaTecnicaPCA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaService _reservaService;
        private readonly IMapper _mapper;

        public ReservaController(IReservaService reservaService, IMapper mapper)
        {
            _reservaService = reservaService;
            _mapper = mapper;
        }

        // Consultar listado de reservas
        [HttpGet]
        public IActionResult ListaReservas([FromQuery] ReservaQueryFilter filters)
        {
            var reservas = _reservaService.ListaReservas(filters);
            var reservasDto = _mapper.Map<List<ReservaDto>>(reservas);
            var metadata = new Metadata
            {
                TotalCount = reservas.TotalCount,
                PageSize = reservas.PageSize,
                CurrentPage = reservas.CurrentPage,
                TotalPages = reservas.TotalPages,
                HasNextPage = reservas.HasNextPage,
                HasPreviousPage = reservas.HasPreviousPage
            };
            var response = new ApiResponse<List<ReservaDto>>(reservasDto)
            {
                Meta = metadata
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }

        // Consultar reserva existente por id
        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarReserva(int id)
        {
            var reserva = await _reservaService.ConsultarReserva(id);
            var reservaDto = _mapper.Map<ReservaDto>(reserva);
            var response = new ApiResponse<ReservaDto>(reservaDto);
            return Ok(response);
        }

        // Insertar una nueva reserva
        [HttpPost]
        public async Task<IActionResult> InsertarReserva(ReservaDto reservaDto)
        {
            var reserva = _mapper.Map<Reserva>(reservaDto);
            await _reservaService.InsertarReserva(reserva);
            reservaDto = _mapper.Map<ReservaDto>(reserva);
            var response = new ApiResponse<ReservaDto>(reservaDto);
            return Ok(response);
        }
    }
}
