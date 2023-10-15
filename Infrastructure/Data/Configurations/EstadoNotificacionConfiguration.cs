using Microsoft.EntityFrameworkCore;
using Core.entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class EstadoNotificacionConfiguration : IEntityTypeConfiguration<EstadoNotificacion>
    {

        public void Configure(EntityTypeBuilder<EstadoNotificacion> builder)
        {
            builder.ToTable("EstadoNotificacion");


            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.NombreEstado)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.FechaCreacion)
                .HasColumnType("date");

            builder.Property(p => p.FechaModificacion)
                .HasColumnType("date");
        }
    }
}