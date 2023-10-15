using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class ModulosMaestrosDto
    {
        public int Id { get; set; }

        public string ? NombreModulo {get; set;} 

        public DateTime FechaCreacion {get; set;}

        public DateTime FechaModificacion {get; set;}
    }
}