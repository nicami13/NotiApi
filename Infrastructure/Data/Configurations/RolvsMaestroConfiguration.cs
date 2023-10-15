using Microsoft.EntityFrameworkCore;
using Core.entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class RolvsMaestroConfiguration : IEntityTypeConfiguration<RolvsMaestro>
    {

        public void Configure(EntityTypeBuilder<RolvsMaestro> builder)
        {
            builder.ToTable("RolvsMaestro");


            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasOne(p => p.Rol)
                .WithMany(e => e.RolvsMaestros)
                .HasForeignKey(f => f.IdRol);

            builder.HasOne(p => p.Maestro)
                .WithMany(e => e.RolvsMaestros)
                .HasForeignKey(f => f.IdMaestro);

            builder.Property(p => p.FechaCreacion)
                .HasColumnType("date");

            builder.Property(p => p.FechaModificacion)
                .HasColumnType("date");
        }
    }
}