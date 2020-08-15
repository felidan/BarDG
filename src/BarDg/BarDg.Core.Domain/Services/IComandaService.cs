using BarDg.Core.Domain.Model;
using System.Threading.Tasks;

namespace BarDg.Core.Domain.Services
{
    public interface IComandaService
    {
        Task<int> AbrirComandaAsync();
        Task RegistrarComandaAsync(Pedido pedido);
        Task LimparComandaAsync(int idComanda);
        Task<NotaFiscal> GerarNotaFiscalAsync(int idComanda);

    }
}
