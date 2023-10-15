using Microsoft.EntityFrameworkCore;
using Core.entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class ModuloNotificacionesConfiguration : IEntityTypeConfiguration<ModuloNotificaciones>
    {

        public void Configure(EntityTypeBuilder<ModuloNotificaciones> builder)
        {
            builder.ToTable("ModuloNotificaciones");


            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.AsuntoNotificacion)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(p => p.TextoNotificacion)
                .IsRequired()
                .HasMaxLength(2000);


            builder.Property(p => p.FechaCreacion)
            .HasColumnType("date");      

            builder.Property(p => p.FechaModificacion)
                .HasColumnType("date");

            builder.HasOne(p => p.TipoNotificacion)
                .WithMany(e => e.ModuloNotificaciones)
                .HasForeignKey(f => f.IdTipoNotificacion);
            
            builder.HasOne(p => p.Radicados)
                .WithMany(e => e.ModuloNotificaciones)
                .HasForeignKey(f => f.IdRadicado);
            
            builder.HasOne(p => p.EstadoNotificacion)
                .WithMany(e => e.ModuloNotificaciones)
                .HasForeignKey(f => f.IdEstadoNotificacion);
            
            builder.HasOne(p => p.HiloRespuestaNotificacion)
                .WithMany(e => e.ModuloNotificaciones)
                .HasForeignKey(f => f.IdHiloRepuesta);
            
            builder.HasOne(p => p.Formato)
                .WithMany(e => e.ModuloNotificaciones)
                .HasForeignKey(f => f.IdFormato);
            
            builder.HasOne(p => p.TipoRequirimiento)
                .WithMany(e => e.ModuloNotificaciones)
                .HasForeignKey(f => f.IdRequerimiento);

        }
    }
}