﻿using System.Collections.Generic;

namespace BarDg.Core.Domain.Model
{
    public class NotaFiscal
    {
        public int IdComanda { get; set; }
        public List<Pedido> Pedidos { get; set; }
        public decimal TotalSemDesconto { get; set; }
        public decimal TotalComDesconto { get; set; }
    }
}
