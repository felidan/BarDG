﻿using BarDg.Core.Domain.Model;
using System.Threading.Tasks;

namespace BarDg.Core.Domain.Services
{
    public interface ILoginService
    {
        Task<Resultado> LoginAsync(UsuarioSistema usuarioSistema);
        string GerarToken(UsuarioSistema usuarioSistema);
    }
}
