using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class EstadoNotificacionDto
    {
        public int Id { get; set; }
        public string ? NombreEstado {get; set;}
        public DateTime FechaCreacion {get; set;}
        public DateTime FechaModificacion {get; set;}
    }
}