using Microsoft.EntityFrameworkCore;
using Core.entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class HiloRespuestaNotificacionConfiguration : IEntityTypeConfiguration<HiloRespuestaNotificacion>
    {

        public void Configure(EntityTypeBuilder<HiloRespuestaNotificacion> builder)
        {
            builder.ToTable("HiloRepuestaNotificacion");


            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.NombreTipo)
            .IsRequired()
            .HasMaxLength(60);

            builder.Property(p => p.FechaCreacion)
            .HasColumnType("date");

            builder.Property(p => p.FechaModificacion)
                .HasColumnType("date");

        }
    }
}