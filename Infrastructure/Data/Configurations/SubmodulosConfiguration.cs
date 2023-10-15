using Microsoft.EntityFrameworkCore;
using Core.entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class SubModulosConfiguration : IEntityTypeConfiguration<SubModulos>
    {

        public void Configure(EntityTypeBuilder<SubModulos> builder)
        {
            builder.ToTable("SubModulos");


            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.nombreSubmodulo)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(p => p.FechaCreacion)
                    .HasColumnType("date");

            builder.Property(p => p.FechaModificacion)
                .HasColumnType("date");

        }
    }
}