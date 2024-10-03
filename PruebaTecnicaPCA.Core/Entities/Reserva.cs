namespace PruebaTecnicaPCA.Core.Entities;

public partial class Reserva : BaseEntity
{
    public int IdVuelo { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string ApellidoUsuario { get; set; } = null!;

    public string CorreoUsuario { get; set; } = null!;

    public virtual Vuelo IdVueloNavigation { get; set; } = null!;
}
