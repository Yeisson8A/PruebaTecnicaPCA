using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaPCA.Api.Responses;
using PruebaTecnicaPCA.Core.CustomEntities;
using PruebaTecnicaPCA.Core.Interfaces;

namespace PruebaTecnicaPCA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadisticaController : ControllerBase
    {
        private readonly IEstadisticaService _estadisticaService;

        public EstadisticaController(IEstadisticaService estadisticaService)
        {
            _estadisticaService = estadisticaService;
        }

        // Obtener cantidad de aerolineas registradas
        [HttpGet("cantidadAerolineas")]
        public async Task<IActionResult> ObtenerCantidadAerolineas()
        {
            var conteoAerolineas = await _estadisticaService.ObtenerCantidadAerolineas();
            var response = new ApiResponse<ConteoAerolineas>(conteoAerolineas);
            return Ok(response);
        }

        // Obtener cantidad de reservas por aerolinea
        [HttpGet("reservasPorAerolinea")]
        public async Task<IActionResult> ObtenerReservasPorAerolinea()
        {
            var reservasPorAerolineas = await _estadisticaService.ObtenerReservasPorAerolinea();
            var response = new ApiResponse<List<ReservasPorAerolinea>>(reservasPorAerolineas);
            return Ok(response);
        }
    }
}
