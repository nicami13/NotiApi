using Microsoft.EntityFrameworkCore;
using Core.entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class GenericosvsSubmodulosConfiguration : IEntityTypeConfiguration<GenericovsSubmodulos>
    {

        public void Configure(EntityTypeBuilder<GenericovsSubmodulos> builder)
        {
            builder.ToTable("GenericosSubmodulos");


            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.FechaCreacion)
            .HasColumnType("date");

            builder.Property(p => p.FechaModificacion)
            .HasColumnType("date");

            builder.HasOne(p => p.permisosGenericos)
                .WithMany(e => e.GenericovsSubmodulos)
                .HasForeignKey(f => f.IdGenericos);
            
            builder.HasOne(p => p.MaestrovsSubmodulos)
                .WithMany(e => e.GenericosvsSubmodulos)
                .HasForeignKey(f => f.IdSubmodulo);

        }
    }
}