namespace PruebaTecnicaPCA.Core.QueryFilters
{
    public class VueloQueryFilter : PaginationQueryFilter
    {
        public string? Origen {  get; set; }

        public string? Destino { get; set; }

        public DateTime? FechaSalida { get; set; }

        public DateTime? FechaLlegada { get; set; }
    }
}
