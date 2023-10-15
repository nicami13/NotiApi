using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.entities
{
    public class TipoRequirimiento:BaseEntity
    {
        
        public string ? Nombre {get; set;}
        public DateTime FechaCreacion {get; set;}
        public DateTime FechaModificacion {get; set;}

        public ICollection<ModuloNotificaciones> ModuloNotificaciones {get; set;}
    }
}