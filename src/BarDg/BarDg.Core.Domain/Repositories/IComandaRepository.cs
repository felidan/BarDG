using BarDg.Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BarDg.Core.Domain.Repositories
{
    public interface IComandaRepository
    {
        Task<int> AbrirComandaAsync();
        Task RegistrarComandaAsync(Pedido pedido);
        Task LimparComandaAsync(int idComanda);
        Task<NotaFiscal> GerarNotaFiscalAsync(int idComanda);
    }
}
