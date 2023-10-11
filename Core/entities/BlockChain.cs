using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.entities
{
    public class BlockChain:BaseEntity
    {
        public int IdNotificacion { get; set; }

        public TipoNotificacion ? TipoNotificacion {get; set;}
        public int IdHiloRepuesta { get; set; }

        public HiloRespuestaNotificacion ? HiloRespuestaNotificacion{get; set;}

        public int HasGenerado { get; set; }
        public DateTime FechaCreacion {get; set;}
        public DateTime FechaModificacion {get; set;}
    }
}