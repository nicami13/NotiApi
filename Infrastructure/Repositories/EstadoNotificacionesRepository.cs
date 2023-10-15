using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class EstadoNotificacionesRepository : GenericRepository<EstadoNotificacion>, IEstadoNotificacion
    {
        private readonly NotiContext _context;

        public EstadoNotificacionesRepository(NotiContext context) : base(context)
        {
            _context = context;
        }
    }
}