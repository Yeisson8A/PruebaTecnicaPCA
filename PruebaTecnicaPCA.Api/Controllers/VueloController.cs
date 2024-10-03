using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
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
    public class VueloController : ControllerBase
    {
        private readonly IVueloService _vueloService;
        private readonly IMapper _mapper;

        public VueloController(IVueloService vueloService, IMapper mapper)
        {
            _vueloService = vueloService;
            _mapper = mapper;
        }

        // Consultar listado de vuelos
        [HttpGet]
        public IActionResult ListaVuelos([FromQuery] VueloQueryFilter filters)
        {
            var vuelos = _vueloService.ListaVuelos(filters);
            var vuelosDto = _mapper.Map<List<VueloDto>>(vuelos);
            var metadata = new Metadata
            {
                TotalCount = vuelos.TotalCount,
                PageSize = vuelos.PageSize,
                CurrentPage = vuelos.CurrentPage,
                TotalPages = vuelos.TotalPages,
                HasNextPage = vuelos.HasNextPage,
                HasPreviousPage = vuelos.HasPreviousPage
            };
            var response = new ApiResponse<List<VueloDto>>(vuelosDto)
            {
                Meta = metadata
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }

        // Consultar vuelo existente por id
        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarVuelo(int id)
        {
            var vuelo = await _vueloService.ConsultarVuelo(id);
            var vueloDto = _mapper.Map<VueloDto>(vuelo);
            var response = new ApiResponse<VueloDto>(vueloDto);
            return Ok(response);
        }

        // Insertar un nuevo vuelo
        [HttpPost]
        public async Task<IActionResult> InsertarVuelo(VueloDto vueloDto)
        {
            var vuelo = _mapper.Map<Vuelo>(vueloDto);
            await _vueloService.InsertarVuelo(vuelo);
            vueloDto = _mapper.Map<VueloDto>(vuelo);
            var response = new ApiResponse<VueloDto>(vueloDto);
            return Ok(response);
        }

        // Actualizar vuelo existente
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarVuelo(int id, VueloDto vueloDto)
        {
            var vuelo = _mapper.Map<Vuelo>(vueloDto);
            vuelo.Id = id;
            var result = await _vueloService.ActualizarVuelo(vuelo);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        // Eliminar vuelo existente
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarVuelo(int id)
        {
            var result = await _vueloService.EliminarVuelo(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
