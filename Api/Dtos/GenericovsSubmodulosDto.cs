using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class GenericovsSubmodulosDto
    {
        public int Id { get; set; }
        public int IdGenericos { get; set; }

        public int IdSubmodulo { get; set; }

        public int IdRol { get; set; }

        public DateTime FechaCreacion {get; set;}

        public DateTime FechaModificacion {get; set;}    }
}