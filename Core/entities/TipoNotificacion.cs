using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.entities
{
    public class TipoNotificacion: BaseEntity
    {
        public string ? NombreTipo {get; set;}
        public DateTime FechaCreacion {get; set;}
        public DateTime FechaModificacion {get; set;}
    }
}