using BarDg.Core.Domain.Model;
using System.Threading.Tasks;

namespace BarDg.Core.Domain.Repositories
{
    public interface ILogRepository
    {
        Task InserirLogErroAsync(Log log);
    }
}
