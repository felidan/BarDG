using BarDg.Core.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarDg.Core.Domain.Repositories
{
    public interface IComandaRepository
    {
        Task<int> RegistrarComandaAsync(List<Pedido> pedidos);
        Task LimparComandaAsync(int idComanda);
        Task<List<Pedido>> BuscarPedidoPorComandaAsync(int idComanda);
        Task<List<Pedido>> BuscarPedidosAsync();
    }
}
