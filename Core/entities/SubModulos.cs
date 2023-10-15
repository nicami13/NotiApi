using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.entities
{
    public class SubModulos:BaseEntity
    {
        public string ? nombreSubmodulo {get; set;}
        public DateTime FechaCreacion {get; set;}

        public DateTime FechaModificacion {get; set;}
        public ICollection<MaestrovsSubmodulos> MaestrovsSubmodulos {get; set;}
        
    }
}