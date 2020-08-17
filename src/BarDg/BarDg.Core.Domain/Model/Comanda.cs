using System.Collections.Generic;

namespace BarDg.Core.Domain.Model
{
    public class Comanda
    {
        public Comanda()
        {
            Pedidos = new List<Pedido>();
        }
        public List<Pedido> Pedidos { get; set; }
        public int IdComanda { get; set; }
    }
}
