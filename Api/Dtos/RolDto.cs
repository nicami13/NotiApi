using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class RolDto
    {
        public int Id { get; set; }
        public string ? Nombre {get; set;}
        
        public DateTime FechaCreacion {get; set;}

        public DateTime FechaModificacion {get; set;}
    }
}