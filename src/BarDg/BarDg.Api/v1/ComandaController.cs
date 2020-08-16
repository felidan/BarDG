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
        [HttpPost("RegistrarComanda")]
        public async Task<IActionResult> RegistrarComandaAsync([FromBody] List<PedidoDto> pedidos)
        {
            try
            {
                if (pedidos.Count > 0)
                {
                    var idComanda = await _comandaService.RegistrarComandaAsync(Mapper.Map<List<Pedido>>(pedidos));
                    return StatusCode(200, new { idComanda });
                }

                return StatusCode(204, "Pedido inválido");
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
                return StatusCode(200, "Ok");

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
    }
}