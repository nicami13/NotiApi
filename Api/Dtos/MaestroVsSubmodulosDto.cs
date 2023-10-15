using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class MaestroVsSubmodulosDto
    {
                public int Id { get; set; }
        public int IdMaestro { get; set; }

        public int IdSubmodulo { get; set; }
        public DateTime FechaModificacion {get; set;}

         public DateTime FechaCreacion {get; set;}

    }
}