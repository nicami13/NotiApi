using Microsoft.EntityFrameworkCore;
using Core.entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class ModuloMaestroConfiguration : IEntityTypeConfiguration<ModuloMaestro>
    {

        public void Configure(EntityTypeBuilder<ModuloMaestro> builder)
        {
            builder.ToTable("ModuloMaestros");


            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.nombreModulo)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.FechaCreacion)
                    .HasColumnType("date");

            builder.Property(p => p.FechaModificacion)
                .HasColumnType("date");

        }
    }
}