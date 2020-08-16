using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using BarDg.Core.Domain.Model;
using BarDg.Core.Domain.Repositories;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace BarDg.Infra.Repository.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly string _connectionString;

        public LoginRepository(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionString"];
        }

        public async Task<UsuarioSistema> LoginAsync(UsuarioSistema usuarioSistema)
        {
            using (IDbConnection con = new SqlConnection(_connectionString))
            {
                var query = @"SELECT *, 
                                    pwdCompare(@Senha, DS_SENHA) AS SenhaOk 
                            FROM TbBDG_UsuarioSistema
                            WHERE Upper(DS_LOGIN) = @Login";
                
                var usu = await con.QueryFirstOrDefaultAsync<UsuarioSistema>(query, new
                {
                    usuarioSistema.Senha,
                    usuarioSistema.Login
                });

                return usu;
            }
        }
    }
}
