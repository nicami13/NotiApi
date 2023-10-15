using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class PermisosGenericosRepository : GenericRepository<PermisosGenericos>, IpermisosGenericos
    {
        private readonly NotiContext _context;

        public PermisosGenericosRepository(NotiContext context) : base(context)
        {
            _context = context;
        }
    }
}