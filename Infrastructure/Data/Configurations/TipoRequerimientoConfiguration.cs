using Microsoft.EntityFrameworkCore;
using Core.entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class TipoRequirimientoConfiguration : IEntityTypeConfiguration<TipoRequerimiento>
    {

        public void Configure(EntityTypeBuilder<TipoRequerimiento> builder)
        {
            builder.ToTable("TipoRequerimiento");


            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(80);
                
            builder.Property(p => p.FechaCreacion)
            .HasColumnType("date");

            builder.Property(p => p.FechaModificacion)
                .HasColumnType("date");

        }
    }
}