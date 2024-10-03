using Microsoft.EntityFrameworkCore;
using PruebaTecnicaPCA.Core.Entities;

namespace PruebaTecnicaPCA.Infrastructure.Data;

public partial class PruebaTecnicaPcaContext : DbContext
{
    public PruebaTecnicaPcaContext()
    {
    }

    public PruebaTecnicaPcaContext(DbContextOptions<PruebaTecnicaPcaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Vuelo> Vuelos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.ToTable("Reserva");

            entity.Property(e => e.ApellidoUsuario)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CorreoUsuario)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdVueloNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdVuelo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reserva_Vuelo");
        });

        modelBuilder.Entity<Vuelo>(entity =>
        {
            entity.ToTable("Vuelo");

            entity.Property(e => e.Aerolinea)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Destino).IsUnicode(false);
            entity.Property(e => e.FechaLlegada).HasColumnType("datetime");
            entity.Property(e => e.FechaSalida).HasColumnType("datetime");
            entity.Property(e => e.Origen).IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Disponible).HasColumnType("bit")
                .HasDefaultValueSql("1");
        });
    }
}
