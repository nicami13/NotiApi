using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.entities
{
    public class Radicados: BaseEntity
    {
        public DateTime FechaCreacion {get; set;}

        
        public DateTime FechaModificacion {get; set;}
    }
}