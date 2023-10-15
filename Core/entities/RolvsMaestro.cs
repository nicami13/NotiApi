using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.entities
{
    public class RolvsMaestro:BaseEntity
    {
        public int IdRol { get; set; }

        public Rol ? Rol {get; set;} 
        
        public ModuloMaestro ? Maestro {get; set;}


    }
}