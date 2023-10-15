using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class HiloRepuestaNotificacionRepository : GenericRepository<HiloRespuestaNotificacion>, IHiloRepuestaNotificacion
    {
        private readonly NotiContext _context;

        public HiloRepuestaNotificacionRepository(NotiContext context) : base(context)
        {
            _context = context;
        }
    }
}