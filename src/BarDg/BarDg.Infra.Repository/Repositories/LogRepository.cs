using BarDg.Core.Domain.Model;
using BarDg.Core.Domain.Repositories;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BarDg.Infra.Repository.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly string _connectionString;

        public LogRepository(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionString"];
        }

        public async Task InserirLogErroAsync(Log log)
        {
            using (IDbConnection con = new SqlConnection(_connectionString))
            {
                string objeto = String.Empty;

                if (log.Objeto != null)
                {
                    objeto = JsonSerializer.Serialize(log.Objeto);
                }

                var query = @"INSERT INTO [TbBDG_Log] VALUES (@Descricao, @Mensagem, @StackTrace, @Level, GETDATE(), @objeto)";

                await con.ExecuteAsync(query,
                new
                {
                    log.Descricao,
                    log.Mensagem,
                    log.StackTrace,
                    log.Level,
                    objeto
                });
            }
        }
    }
}
