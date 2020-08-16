using BarDg.Core.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarDg.Core.Domain.Services
{
    public interface IPromocaoService
    {
        Task<List<Pedido>> AplicarPromocaoAsync(List<Pedido> pedidos);
    }
}
