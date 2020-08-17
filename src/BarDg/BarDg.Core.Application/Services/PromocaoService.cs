using BarDg.Core.Domain.Enum;
using BarDg.Core.Domain.Model;
using BarDg.Core.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BarDg.Core.Application.Services
{
    public class PromocaoService : IPromocaoService
    {
        public PromocaoService()
        {
            
        }

        public List<Pedido> AplicarPromocao(List<Pedido> pedidos)
        {
            decimal quantidadeCerveja = pedidos.Count(x => x.Id == (int)PedidoEnum.CERVEJA);
            decimal quantidadeConhaque = pedidos.Count(x => x.Id == (int)PedidoEnum.CONHAQUE);
            decimal quantidadeSuco = pedidos.Count(x => x.Id == (int)PedidoEnum.SUCO);
            
            
            decimal descontoPromocaoUm = Math.Truncate(Math.Min(quantidadeCerveja, quantidadeSuco));

            quantidadeConhaque = Math.Truncate(quantidadeConhaque / 3);
            quantidadeCerveja = Math.Truncate(quantidadeCerveja / 2);

            var descontoPromocaoDois = Math.Truncate(Math.Min(quantidadeConhaque, quantidadeCerveja));
            
            pedidos.ForEach(item =>
            {
                item.Desconto = 0;
                // Aplica promoção 1
                if (item.Id == (int)PedidoEnum.CERVEJA && descontoPromocaoUm > 0)
                {
                    item.Desconto = 2;
                    descontoPromocaoUm--;
                }

                // Aplica promoção 2
                if (item.Id == (int)PedidoEnum.AGUA && descontoPromocaoDois > 0)
                {
                    item.Desconto = 70;
                    descontoPromocaoDois--;
                }
            });
            
            return pedidos;
        }
    }
}
