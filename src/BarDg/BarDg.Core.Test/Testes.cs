using BarDg.Core.Application.Services;
using BarDg.Core.Domain.Model;
using BarDg.Core.Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BarDg.Core.Test
{
    public class Testes
    {
        public Testes()
        {

        }

        #region ComandaService
        
        [Fact]
        public async Task AbrirComandaServiceTest()
        {
            int idComanda = 5;

            var repository = new Mock<IComandaRepository>();
            repository.Setup(s => s.AbrirComandaAsync())
                .Returns(Task.Run(() => idComanda));


            var service = new ComandaService(repository.Object);

            var result = await service.AbrirComandaAsync();
            Assert.Equal(result, idComanda);
        }

        [Fact]
        public async Task BuscarTodosPedidosServiceTest()
        {
            List<Pedido> pedidos = new List<Pedido>();
            pedidos.Add(new Pedido() { Id = 1, Nome = "Cerveja", Preco = 5 });

            var repository = new Mock<IComandaRepository>();
            repository.Setup(s => s.BuscarPedidosAsync())
                .Returns(Task.Run(() => pedidos));
            
            var service = new ComandaService(repository.Object);

            var result = await service.BuscarTodosPedidosAsync();
            Assert.NotNull(result);
            Assert.Equal(pedidos.Count.ToString(), result.Count.ToString());
        }

        [Fact]
        public async Task GerarNotaFiscalServiceTest()
        {
            int idComanda = 5;
            
            List<Pedido> pedidos = new List<Pedido>();
            pedidos.Add(new Pedido() { Id = 1, Nome = "Cerveja", Preco = 5 });

            var repository = new Mock<IComandaRepository>();
            repository.Setup(s => s.BuscarPedidoPorComandaAsync(idComanda))
                .Returns(Task.Run(() => pedidos));
            
            var service = new ComandaService(repository.Object);

            var nota = await service.GerarNotaFiscalAsync(idComanda);

            Assert.NotEqual(0, nota.TotalSemDesconto, 2);
        }

        [Fact]
        public async Task RegistrarComandaServiceTest()
        {
            int idComanda = 5;
            List<Pedido> pedidos = new List<Pedido>();
            pedidos.Add(new Pedido() { Id = 1, Nome = "Cerveja", Preco = 5, Desconto = 2 });
            pedidos.Add(new Pedido() { Id = 2, Nome = "Conhaque", Preco = 20 });

            var repository = new Mock<IComandaRepository>();
            repository.Setup(s => s.RegistrarComandaAsync(pedidos))
                .Returns(Task.Run(() => idComanda));
            
            var service = new ComandaService(repository.Object);

            var result = await service.RegistrarComandaAsync(pedidos);

            Assert.Equal(idComanda.ToString(), result.ToString());
        }

        #endregion

        #region LoginService
        
        [Fact]
        public async Task LoginFalhaServiceTest()
        {
            UsuarioSistema usu = new UsuarioSistema()
            {
                Id = 17,
                Ativo = true,
                Login = "AAA",
                Senha = "111",
                SenhaOk = false
            };

            var repository = new Mock<ILoginRepository>();
            repository.Setup(s => s.LoginAsync(usu))
                .Returns(Task.Run(() => usu));

            var service = new LoginService(repository.Object, Mock.Of<IConfiguration>());

            var result = await service.LoginAsync(usu);
            Assert.False(result.Sucesso);
            Assert.Equal("400 - Senha inválida", result.Mensagem);
        }

        #endregion

        #region PromocaoService

        [Fact]
        public void AplicarPromocaoServiceTest()
        {
            List<Pedido> pedidos = new List<Pedido>();
            pedidos.Add(new Pedido() { Id = 1, Nome = "Cerveja", Preco = 5 });
            pedidos.Add(new Pedido() { Id = 2, Nome = "Conhaque", Preco = 20 });
            
            var service = new PromocaoService();

            var result = service.AplicarPromocao(pedidos);

            Assert.NotEmpty(result);
            Assert.Equal(pedidos.Count.ToString(), result.Count.ToString());
        }

        #endregion
    }
}