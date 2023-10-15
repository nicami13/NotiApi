using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.entities
{
    public class MaestrovsSubmodulos:BaseEntity
    {   
        public int IdMaestro { get; set; }
        public ModuloMaestro Maestro{get; set;}
        public int IdSubmodulo { get; set; }
        public DateTime FechaCreacion {get; set;}
        public DateTime FechaModificacion {get; set;}
        public SubModulos SubModulos {get; set;}
        public ICollection<GenericovsSubmodulos> GenericosvsSubmodulos {get; set;}
    }
}