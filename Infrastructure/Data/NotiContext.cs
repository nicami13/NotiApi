using System.Linq;
using System.Reflection;
using Core.entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;
public class NotiContext : DbContext
{
    public NotiContext(DbContextOptions options) : base(options){
    }

    public DbSet<Auditoria> Auditorias {get; set;}

    public DbSet<BlockChain> BlockChains {get; set;}

    public DbSet<EstadoNotificacion> EstadoNotificacions {get; set;}

    public DbSet<Formatos> Formatos {get; set;}

    public DbSet<HiloRespuestaNotificacion> HiloRespuestaNotificacions {get; set;}

    public DbSet<MaestrovsSubmodulos> MaestrovsSubmodulos {get; set;}

    public DbSet<ModuloMaestro>ModuloMaestros {get; set;}

    public DbSet<PermisosGenericos> permisosGenericos {get; set;}

    public DbSet<Rol> Roles {get; set;}

    public DbSet<RolvsMaestro> rolvsMaestros {get; set;}

    public DbSet<SubModulos> SubModulos {get; set;}

    public DbSet<TipoNotificacion> TipoNotificaciones {get; set;}

    public DbSet<TipoRequerimiento> TipoRequirimientos {get; set;}


    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }

}