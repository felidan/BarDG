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
    public class PromocaoController : ControllerBase
    {
        private readonly IPromocaoService _promocaoService;
        private readonly ILogService _logService;

        public PromocaoController(IPromocaoService promocaoService, ILogService logService)
        {
            _promocaoService = promocaoService;
            _logService = logService;
        }

        [Authorize]
        [HttpPost("AplicarPromocao")]
        public async Task<IActionResult> AplicarPromocao([FromBody] List<PedidoDto> pedidos)
        {
            try
            {
                var pedidosComPromocao = _promocaoService.AplicarPromocao(Mapper.Map<List<Pedido>>(pedidos));
                return StatusCode(200, pedidosComPromocao);
            }
            catch (Exception ex)
            {
                await _logService.InserirLogErroAsync(ex, "ERRO", pedidos);
                return StatusCode(500, "Ocorreu um erro ao processar a requisição");
            }
        }
    }
}