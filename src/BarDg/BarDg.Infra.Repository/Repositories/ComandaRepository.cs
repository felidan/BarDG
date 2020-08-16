using BarDg.Core.Domain.Model;
using BarDg.Core.Domain.Repositories;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BarDg.Infra.Repository.Repositories
{
    public class ComandaRepository : IComandaRepository
    {
        private readonly string _connectionString;
        
        public ComandaRepository(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionString"];
        }
        
        public async Task<List<Pedido>> BuscarPedidoPorComandaAsync(int idComanda)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(_connectionString))
                {
                    var query = @"SELECT B.*, A.VL_DESCONTO_APLICADO AS 'Desconto'
                                FROM [TbBDG_ComandaPedido] A 
                                INNER JOIN [TbBDG_Pedidos] B ON A.ID_PEDIDO = B.ID_PEDIDO
                                WHERE A.ID_COMANDA = @idComanda";

                    var pedidos = await con.QueryAsync<Pedido>(query, new { idComanda });

                    return pedidos.AsList();
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Pedido>> BuscarPedidosAsync()
        {
            try
            {
                using (IDbConnection con = new SqlConnection(_connectionString))
                {
                    var query = @"SELECT *
                                FROM [TbBDG_Pedidos]";

                    var pedidos = await con.QueryAsync<Pedido>(query);

                    return pedidos.AsList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task LimparComandaAsync(int idComanda)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(_connectionString))
                {
                    var query = @"DELETE FROM TbBDG_ComandaPedido WHERE ID_COMANDA = @idComanda";

                    await con.ExecuteAsync(query, new
                    {
                        idComanda
                    });
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<int> RegistrarComandaAsync(List<Pedido> pedidos)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(_connectionString))
                {
                    var query = @"INSERT INTO [TbBDG_Comanda] VALUES (GETDATE())
                                  SELECT SCOPE_IDENTITY()";

                    var idComanda = await con.QuerySingleOrDefaultAsync<int>(query);

                    if (idComanda > 0)
                    {
                        foreach (var pedido in pedidos)
                        {
                            query = @"INSERT INTO[TbBDG_ComandaPedido] VALUES(@idComanda, @Id, @Desconto)";

                            await con.ExecuteAsync(query, new
                            {
                                idComanda,
                                pedido.Id,
                                pedido.Desconto
                            });
                        }
                    }

                    return idComanda;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
