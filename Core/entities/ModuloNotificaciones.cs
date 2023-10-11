using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.entities
{
    public class ModuloNotificaciones:BaseEntity
    {
        public string ? AsuntoNotificacion { get; set; }
        public int IdTipoNotificacion { get; set; }

                public TipoNotificacion ? TipoNotificacion {get; set;}
        public int IdRadicado { get; set; }

        public Radicados ? Radicados {get; set;}
        public int IdHiloRepuesta { get; set; }

        public int IdEstado{get; set;}
        public EstadoNotificacion ? EstadoNotificacion { get; set; }

        public int IdRequerimiento {get; set;}

        public TipoRequirimiento ? TipoRequirimiento {get; set;}

        public int IdFormato {get; set;}

        public Formatos ? Formato {get; set;}

        public HiloRespuestaNotificacion ? HiloRespuestaNotificacion{get; set;}

        public string ? TextoNotificacion { get; set; }
        public DateTime FechaCreacion {get; set;}
        public DateTime FechaModificacion {get; set;}
        
    }
}