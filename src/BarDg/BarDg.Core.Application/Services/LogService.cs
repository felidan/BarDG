using BarDg.Core.Domain.Model;
using BarDg.Core.Domain.Repositories;
using BarDg.Core.Domain.Services;
using System;
using System.Threading.Tasks;

namespace BarDg.Core.Application.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }
        
        public async Task InserirLogErroAsync(Exception ex, string level, object obj)
        {
            Log log = new Log();

            log.Descricao = "Erro no sistema";
            log.Mensagem = ex.Message;
            log.StackTrace = ex.StackTrace;
            log.Objeto = obj;
            log.Level = level;

            await _logRepository.InserirLogErroAsync(log);
        }
    }
}
