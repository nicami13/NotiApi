using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.entities
{
    public class GenericovsSubmodulos:BaseEntity
    {
        public int IdGenericos { get; set; }

        public PermisosGenericos permisosGenericos {get; set;}

        public int IdSubmodulo { get; set; }
        public  MaestrovsSubmodulos MaestrovsSubmodulos {get; set;}

        public int IdRol { get; set; }
        public Rol Rol {get; set;}

        public DateTime FechaCreacion {get; set;}

        public DateTime FechaModificacion {get; set;}

        
        
    }
}