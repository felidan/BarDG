using BarDg.Core.Domain.Model;
using System.Collections.Generic;

namespace BarDg.Core.Domain.Services
{
    public interface IPromocaoService
    {
        List<Pedido> AplicarPromocao(List<Pedido> pedidos);
    }
}
