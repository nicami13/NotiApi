using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.entities
{
    public class Auditoria:BaseEntity
    {
        public string ? NombreUsuario { get; set; }
        public int DescAccion { get; set; }
        public DateTime FechaCreacion {get; set;}
        public DateTime FechaModificacion {get; set;}
        public ICollection<BlockChain> BlockChains {get; set;}
    }
}