using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class AuditoriaDto
    {
        public int Id { get; set; }
        public string ? NombreUsuario { get; set; }
        public int DescAccion { get; set; }

        public DateTime FechaCreacion {get; set;}

        public DateTime FechaModificaion {get; set;}
    }
}