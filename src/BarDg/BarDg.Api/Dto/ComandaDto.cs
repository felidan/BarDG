using System.Collections.Generic;

namespace BarDg.Api.Dto
{
    public class ComandaDto
    {
        public ComandaDto()
        {
            Pedidos = new List<PedidoDto>();
        }
        List<PedidoDto> Pedidos { get; set; }
        public int IdComanda { get; set; }
    }
}
