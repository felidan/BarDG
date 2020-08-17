using BarDg.Core.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarDg.Core.Domain.Services
{
    public interface IComandaService
    {
        Task<int> RegistrarComandaAsync(List<Pedido> pedidos);
        Task LimparComandaAsync(int idComanda);
        Task<NotaFiscal> GerarNotaFiscalAsync(int idComanda);
        Task<List<Pedido>> BuscarTodosPedidosAsync();
        Task<int> AbrirComandaAsync();

    }
}
