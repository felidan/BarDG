using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BarDg.Core.Domain.Model;
using BarDg.Core.Domain.Repositories;
using BarDg.Core.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BarDg.Core.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IConfiguration _configuration;

        public LoginService(ILoginRepository loginRepository, IConfiguration configuration)
        {
            _loginRepository = loginRepository;
            _configuration = configuration;
        }

        public Resultado GerarToken(UsuarioSistema usuarioSistema)
        {
            if (String.IsNullOrEmpty(usuarioSistema.Login)
                || String.IsNullOrEmpty(usuarioSistema.Id.ToString()))
                return new Resultado(false, "Informações incompletas");

            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtChaveSecreta"]);

            var descriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuarioSistema.Login),
                    new Claim(ClaimTypes.NameIdentifier, usuarioSistema.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(Double.Parse(_configuration["JwtExpiresMinutes"])),
                SigningCredentials = new SigningCredentials
                (
                    new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = handler.CreateToken(descriptor);

            return new Resultado(true, handler.WriteToken(token));
        }

        public async Task<Resultado> LoginAsync(UsuarioSistema usuarioSistema)
        {
            var usu = await _loginRepository.LoginAsync(usuarioSistema);

            if (usu == null)
                return new Resultado(false, "404 - Usuário não localizado.");

            if (usu.Login.ToLower() != usuarioSistema.Login.ToLower())
                return new Resultado(false, "400 - Login incorreto");
            else
            {
                if (!usu.Ativo)
                {
                    return new Resultado(false, "400 - Usuário inativo");
                }
                else
                {
                    if (!usu.SenhaOk)
                        return new Resultado(false, "400 - Senha inválida");
                    else
                    {
                        usuarioSistema.Id = usu.Id;
                        var token = GerarToken(usuarioSistema);
                        
                        return new Resultado(token.Sucesso, token.Mensagem);
                    }
                }
            }
        }
    }
}
