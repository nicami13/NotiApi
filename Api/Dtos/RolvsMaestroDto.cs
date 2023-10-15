using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class RolvsMaestroDto
    {
        public int Id { get; set; }

        public int IdRol { get; set; }

        public int IdMaestro { get; set; }

        public DateTime FechaCreacion {get; set;}

        public DateTime FechaModificaion {get; set;} 
    }
}