namespace PruebaTecnicaPCA.Core.Entities;

public partial class Vuelo : BaseEntity
{
    public string Origen { get; set; } = null!;

    public string Destino { get; set; } = null!;

    public DateTime FechaSalida { get; set; }

    public DateTime FechaLlegada { get; set; }

    public string Aerolinea { get; set; } = null!;

    public decimal Precio { get; set; }

    public bool Disponible { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
