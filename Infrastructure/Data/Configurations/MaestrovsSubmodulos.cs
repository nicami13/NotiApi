using Microsoft.EntityFrameworkCore;
using Core.entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class MaestrovsSubmodulosConfiguration : IEntityTypeConfiguration<MaestrovsSubmodulos>
    {

        public void Configure(EntityTypeBuilder<MaestrovsSubmodulos> builder)
        {
            builder.ToTable("MaestrovsSubmodulos");


            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.FechaCreacion)
            .HasColumnType("date");

            builder.Property(p => p.FechaModificacion)
            .HasColumnType("date");

            builder.HasOne(p => p.Maestro)
                .WithMany(e => e.MaestrovsSubmodulos)
                .HasForeignKey(f => f.IdMaestro);
            
            builder.HasOne(p => p.SubModulos)
                .WithMany(e => e.MaestrovsSubmodulos)
                .HasForeignKey(f => f.IdSubmodulo);

        }
    }
}