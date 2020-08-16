using BarDg.Core.Domain.Model;
using BarDg.Core.Domain.Repositories;
using BarDg.Core.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarDg.Core.Application.Services
{
    public class ComandaService : IComandaService
    {
        private readonly IComandaRepository _comandaRepository;

        public ComandaService(IComandaRepository comandaRepository)
        {
            _comandaRepository = comandaRepository;
        }
        
        public async Task<NotaFiscal> GerarNotaFiscalAsync(int idComanda)
        {
            NotaFiscal notaFiscal = new NotaFiscal();

            var pedidos = await _comandaRepository.BuscarPedidoPorComandaAsync(idComanda);

            if(pedidos.Count > 0)
            {
                notaFiscal.Pedidos = pedidos;
                notaFiscal.TotalSemDesconto = pedidos.Sum(x => x.Preco);
                notaFiscal.TotalComDesconto = pedidos.Sum(x => (x.Preco - x.Desconto));
            }

            return notaFiscal;
        }

        public async Task LimparComandaAsync(int idComanda)
        {
            await _comandaRepository.LimparComandaAsync(idComanda);
        }

        public async Task<int> RegistrarComandaAsync(List<Pedido> pedidos)
        {
            return await _comandaRepository.RegistrarComandaAsync(pedidos);
        }
    }
}
