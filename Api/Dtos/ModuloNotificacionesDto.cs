using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class ModuloNotificacionesDto
    {
        public string? AsuntoNotificacion { get; set; }
        public int IdTipoNotificacion { get; set; }
        public int IdRadicado { get; set; }
        public int IdHiloRepuesta { get; set; }
        public int IdEstado { get; set; }
        public int IdRequerimiento { get; set; }
        public int IdFormato { get; set; }
        public string? TextoNotificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}