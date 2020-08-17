using AutoMapper;
using BarDg.Api.Dto;
using BarDg.Core.Domain.Model;
using BarDg.Core.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarDg.Api.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {
        private readonly IComandaService _comandaService;

        public ComandaController(IComandaService comandaService)
        {
            _comandaService = comandaService;
        }

        [Authorize]
        [HttpGet("AbrirComanda")]
        public async Task<IActionResult> AbrirComandaAsync()
        {
            try
            {
                var idComanda = await _comandaService.AbrirComandaAsync();
                return StatusCode(200, idComanda);
            }
            catch (Exception ex)
            {
                // TODO - Gravar log
                return StatusCode(500, "Ocorreu um erro ao processar a requisição");
            }
        }

        [Authorize]
        [HttpPost("RegistrarComanda")]
        public async Task<IActionResult> RegistrarComandaAsync([FromBody] List<PedidoDto> pedidos)
        {
            try
            {
                var idComanda = await _comandaService.RegistrarComandaAsync(Mapper.Map<List<Pedido>>(pedidos));
                return StatusCode(200, idComanda);
            }
            catch (Exception ex)
            {
                // TODO - Gravar log
                return StatusCode(500, "Ocorreu um erro ao processar a requisição");
            }
        }

        [Authorize]
        [HttpDelete("LimparComanda/{idComanda}")]
        public async Task<IActionResult> LimparComandaAsync(int idComanda)
        {
            try
            {
                await _comandaService.LimparComandaAsync(idComanda);
                return StatusCode(200, idComanda);

            }
            catch (Exception ex)
            {
                // TODO - Gravar log
                return StatusCode(500, "Ocorreu um erro ao processar a requisição");
            }
        }

        [Authorize]
        [HttpGet("GerarNotaFiscal/{idComanda}")]
        public async Task<IActionResult> GerarNotaFiscalAsync(int idComanda)
        {
            try
            {
                var comanda = await _comandaService.GerarNotaFiscalAsync(idComanda);
                return StatusCode(200, comanda);
            }
            catch (Exception ex)
            {
                // TODO - Gravar log
                return StatusCode(500, "Ocorreu um erro ao processar a requisição");
            }
        }

        [Authorize]
        [HttpGet("BuscarTodosPedidos")]
        public async Task<IActionResult> BuscarTodosPedidosAsync()
        {
            try
            {
                var pedidos = Mapper.Map<List<PedidoDto>>(await _comandaService.BuscarTodosPedidosAsync());
                return StatusCode(200, pedidos);
            }
            catch (Exception ex)
            {
                // TODO - Gravar log
                return StatusCode(500, "Ocorreu um erro ao processar a requisição");
            }
        }
    }
}