using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class BlockChainConfiguration : IEntityTypeConfiguration<BlockChain>
    {
        public void Configure(EntityTypeBuilder<BlockChain> builder)
        {
            builder.ToTable("BlockChain");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.HasGenerado)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.FechaCreacion)
                .HasColumnType("date");

            builder.Property(p => p.FechaModificacion)
            .HasColumnType("date");

            builder.HasOne(p => p.TipoNotificacion)
                .WithMany(e => e.BlockChains)
                .HasForeignKey(f => f.IdNotificacion);

            builder.HasOne(p => p.HiloRespuestaNotificacion)
                .WithMany(e => e.BlockChains)
                .HasForeignKey(f => f.IdHiloRepuesta);
            
            builder.HasOne(p => p.Auditoria)
                .WithMany(e => e.BlockChains)
                .HasForeignKey(f => f.IdAuditoria);

        }
    }
}