using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.entities
{
    public class PermisosGenericos:BaseEntity
    {
        public string? NombrePermiso { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaModificacion { get; set; }

        public ICollection<GenericovsSubmodulos> GenericovsSubmodulos { get; set; }
    }
}