namespace PruebaTecnicaPCA.Core.DTOs
{
    public class VueloDto
    {
        public int Id { get; set; }

        public string Origen { get; set; }

        public string Destino { get; set; }

        public DateTime FechaSalida { get; set; }

        public DateTime FechaLlegada { get; set; }

        public string Aerolinea { get; set; }

        public decimal Precio { get; set; }
    }
}
