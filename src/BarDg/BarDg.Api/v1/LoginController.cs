using AutoMapper;
using BarDg.Api.Dto;
using BarDg.Core.Domain.Model;
using BarDg.Core.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace BarDg.Api.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IConfiguration _configuration;

        public LoginController(ILoginService loginService, IConfiguration configuration)
        {
            _loginService = loginService;
            _configuration = configuration;
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UsuarioSistemaDto usuario)
        {
            try
            {
                var login = Mapper.Map<ResultadoDto>(await _loginService.LoginAsync(Mapper.Map<UsuarioSistema>(usuario)));

                if (login.Sucesso)
                    return StatusCode(200, new { token = login, validade = _configuration["JwtExpiresMinutes"] });
                else
                    return StatusCode(400, login);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao processar a requisição");
            }
        }

    }
}