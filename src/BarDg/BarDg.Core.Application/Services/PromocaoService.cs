using BarDg.Core.Domain.Enum;
using BarDg.Core.Domain.Model;
using BarDg.Core.Domain.Repositories;
using BarDg.Core.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarDg.Core.Application.Services
{
    public class PromocaoService : IPromocaoService
    {
        private readonly IComandaRepository _comandaRepository;

        public PromocaoService(IComandaRepository comandaRepository)
        {
            _comandaRepository = comandaRepository;
        }

        public async Task<List<Pedido>> AplicarPromocaoAsync(List<Pedido> pedidos)
        {
            var produtos = await _comandaRepository.BuscarPedidosAsync();

            if(pedidos.Count(x => x.Id == (int)PedidoEnum.CERVEJA) > 0)
            {

            }
            throw new NotImplementedException();
        }
    }
}
