using System;
using System.Collections.Generic;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly NotiContext _context;
        private IAuditoria _Auditorias;
        private IBlockChain _BlockChain;
        private IEstadoNotificacion _EstadoNotificacion;
        private IFormatos _Formatos;
        private IGenericosvsSubmodulos _GenericosvsSubmodulos;
        private IHiloRepuestaNotificacion _HiloRepuestaNotificacion;
        private IMaestrovsSubmodulos _MaestrovsSubmoudlos;
        private IModulosMaestro _ModuloMaestro;
        private IModuloNotificaciones _ModuloNotificaciones;
        private IpermisosGenericos _PermisosGenericos;
        private IRadicados _Radicados;
        private IRol _Rol;
        private IRolvsMaestro _RolvsMaestro;
        private ISubmodulos _Submodulos;
        private ITipoNotificaciones _TipoNotificaciones;
        private ITipoRequerimiento _TipoRequerimiento;

        public UnitOfWork(NotiContext context)
        {
            _context = context;
        }

        public IAuditoria Auditorias
        {
            get
            {
                _Auditorias ??= new AuditoriaRepository(_context);
                return _Auditorias;
            }
        }

        public IBlockChain BlockChains
        {
            get
            {
                _BlockChain ??= new BlockChainRepository(_context);
                return _BlockChain;
            }
        }

        public IEstadoNotificacion EstadoNotificaciones
        {
            get
            {
                _EstadoNotificacion ??= new EstadoNotificacionesRepository(_context);
                return _EstadoNotificacion;
            }
        }

        public IFormatos Formatos
        {
            get
            {
                _Formatos ??= new FormatoRepository(_context);
                return _Formatos;
            }
        }

        public IGenericosvsSubmodulos GenericosvsSubmodulos
        {
            get
            {
                _GenericosvsSubmodulos ??= new GenericovsSubmodulosRepository(_context);
                return _GenericosvsSubmodulos;
            }
        }

        public IHiloRepuestaNotificacion HiloRepuestaNotificaciones
        {
            get
            {
                _HiloRepuestaNotificacion ??= new HiloRepuestaNotificacionRepository(_context);
                return _HiloRepuestaNotificacion;
            }
        }

        public IMaestrovsSubmodulos MaestrovsSubmodulos
        {
            get
            {
                _MaestrovsSubmoudlos ??= new MaestrovsSubmodulosRepository(_context);
                return _MaestrovsSubmoudlos;
            }
        }

        public IModulosMaestro ModulosMaestro
        {
            get
            {
                _ModuloMaestro ??= new ModuloMaestroRepository(_context);
                return _ModuloMaestro;
            }
        }

        public IModuloNotificaciones ModuloNotificaciones
        {
            get
            {
                _ModuloNotificaciones = new ModuloNotificacionesRepository(_context);
                return _ModuloNotificaciones;
            }
        }

        public IpermisosGenericos PermisosGenericos
        {
            get
            {
                _PermisosGenericos ??= new PermisosGenericosRepository(_context);
                return _PermisosGenericos;
            }
        }

        public IRadicados Radicados
        {
            get
            {
                _Radicados ??= new RadicadosRepository(_context);
                return _Radicados;
            }
        }

        public IRol Roles
        {
            get
            {
                _Rol ??= new RolRepository(_context);
                return _Rol;
            }
        }

        public IRolvsMaestro RolvsMaestro
        {
            get
            {
                _RolvsMaestro ??= new RolvsMaestroRepository(_context);
                return _RolvsMaestro;
            }
        }

        public ITipoNotificaciones TipoNotificaciones
        {
            get
            {
                _TipoNotificaciones ??= new TipoNotificacionesRepository(_context);
                return _TipoNotificaciones;
            }
        }

        public ITipoRequerimiento TipoRequerimientos
        {
            get
            {
                _TipoRequerimiento ??= new TipoRequerimientoRepository(_context);
                return _TipoRequerimiento;
            }
        }

        public ISubmodulos Submodulos
        {
            get
            {
                _Submodulos ??= new SubmodulosRepository(_context);
                return _Submodulos;
            }
        }

        public void Dispose()
        {
         _context.Dispose();
        }
        public Task<int> SaveAsync(){
            return _context.SaveChangesAsync();
        }
    }
}
