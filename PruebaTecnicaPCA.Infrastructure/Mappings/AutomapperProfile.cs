using AutoMapper;
using PruebaTecnicaPCA.Core.DTOs;
using PruebaTecnicaPCA.Core.Entities;

namespace PruebaTecnicaPCA.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            // Mapeo de la clase Vuelo a la clase Vuelo DTO
            CreateMap<Vuelo, VueloDto>();
            // Mapeo de la clase Reserva a la clase Reserva DTO
            CreateMap<Reserva, ReservaDto>();
            // Mapeo de la clase Vuelo DTO a la clase Vuelo
            CreateMap<VueloDto, Vuelo>();
            // Mapeo de la clase Reserva DTO a la clase Reserva
            CreateMap<ReservaDto, Reserva>();
        }
    }
}
