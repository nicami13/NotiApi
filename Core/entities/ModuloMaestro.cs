using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.entities
{
    public class ModuloMaestro:BaseEntity
    {
        public string ? nombreModulo {get; set;}

        public DateTime FechaCreacion {get; set;}

        public DateTime FechaModificacion {get; set;}

        public ICollection<RolvsMaestro> RolvsMaestros {get; set;}

        public ICollection<MaestrovsSubmodulos> MaestrovsSubmodulos {get; set;}
    }
}