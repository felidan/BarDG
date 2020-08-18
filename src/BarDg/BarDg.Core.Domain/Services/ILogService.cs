using System;
using System.Threading.Tasks;

namespace BarDg.Core.Domain.Services
{
    public interface ILogService
    {
        Task InserirLogErroAsync(Exception ex, string level, object obj);
    }
}
