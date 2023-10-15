using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.entities;

namespace Persistencia.Data.Configuration
{
    public class RadicadosConfiguration : IEntityTypeConfiguration<Radicados>
    {

        public void Configure(EntityTypeBuilder<Radicados> builder)
        {
            builder.ToTable("Radicados");


            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.FechaCreacion)
            .HasColumnType("date");

            builder.Property(p => p.FechaModificacion)
            .HasColumnType("date");

        }
    }
}