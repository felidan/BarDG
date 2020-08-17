using AutoMapper;
using BarDg.Api.Dto;
using BarDg.Core.Domain.Model;
using BarDg.Core.Domain.Services;
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

        public PromocaoController(IPromocaoService promocaoService)
        {
            _promocaoService = promocaoService;
        }

        //[Authorize]
        [HttpPost("AplicarPromocao")]
        public async Task<IActionResult> AplicarPromocao([FromBody] List<PedidoDto> pedidos)
        {
            // arrumar o warning
            try
            {
                var pedidosComPromocao = _promocaoService.AplicarPromocao(Mapper.Map<List<Pedido>>(pedidos));
                return StatusCode(200, pedidosComPromocao);
            }
            catch (Exception ex)
            {
                // TODO - Gravar log
                return StatusCode(500, "Ocorreu um erro ao processar a requisição");
            }
        }
    }
}