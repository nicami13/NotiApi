using Microsoft.EntityFrameworkCore;
using Core.entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class TipoNotificacionConfiguration : IEntityTypeConfiguration<TipoNotificacion>
    {

        public void Configure(EntityTypeBuilder<TipoNotificacion> builder)
        {
            builder.ToTable("TipoNotificaciones");


            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.NombreTipo)
            .IsRequired()
            .HasMaxLength(50);
            builder.Property(p => p.FechaCreacion)
            .HasColumnType("date");

            builder.Property(p => p.FechaModificacion)
                .HasColumnType("date");

        }
    }
}