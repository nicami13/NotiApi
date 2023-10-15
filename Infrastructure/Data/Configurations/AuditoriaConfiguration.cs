using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Core.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class AuditoriaConfiguration: IEntityTypeConfiguration<Auditoria>
{

public void Configure(EntityTypeBuilder<Auditoria> builder)
{
    builder.ToTable("Auditoria");

    builder.HasKey(e => e.Id);
    builder.Property(e => e.Id);

    builder.Property(p => p.NombreUsuario)
        .IsRequired()
        .HasMaxLength(50);
    
    builder.Property(p => p.DescAccion)
        .IsRequired()
        .HasMaxLength(100);
    
    builder.Property(p => p.FechaCreacion)
        .HasColumnType("date");

    builder.Property(p => p.FechaModificacion)
    .HasColumnType("date");
    

    
    }
}
}