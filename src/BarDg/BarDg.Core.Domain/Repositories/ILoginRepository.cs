using BarDg.Core.Domain.Model;
using System.Threading.Tasks;

namespace BarDg.Core.Domain.Repositories
{
    public interface ILoginRepository
    {
        Task<Resultado> LoginAsync(UsuarioSistema usuarioSistema);
    }
}
