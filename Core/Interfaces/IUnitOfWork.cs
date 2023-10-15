using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IAuditoria Auditorias {get;}
        IBlockChain BlockChains {get;}
        IEstadoNotificacion EstadoNotificaciones {get;}
        IFormatos Formatos {get;}
        IGenericosvsSubmodulos GenericosvsSubmodulos {get;}
        IHiloRepuestaNotificacion HiloRepuestaNotificaciones {get;}
        IMaestrovsSubmodulos MaestrovsSubmodulos {get;}
        IModulosMaestro ModulosMaestro {get;}
        IModuloNotificaciones ModuloNotificaciones {get;}
        IpermisosGenericos PermisosGenericos {get;}
        IRadicados Radicados {get;}
        IRol Roles {get;}
        IRolvsMaestro RolvsMaestro {get;}
        ITipoNotificaciones TipoNotificaciones {get;}
        ITipoRequerimiento TipoRequerimientos {get;}
        ISubmodulos Submodulos {get;}



    }
}