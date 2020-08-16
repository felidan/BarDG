using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarDg.Api.Dto
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public int IdComanda { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public decimal Desconto { get; set; }
    }
}
