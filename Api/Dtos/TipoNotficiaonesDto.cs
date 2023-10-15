using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class TipoNotficiaonesDto
    {
        public int Id { get; set; }
        public string ? NombreTipo {get; set;} 

        public DateTime FechaCreacion {get; set;}

        public DateTime FechaModificaion {get; set;}
    }
}