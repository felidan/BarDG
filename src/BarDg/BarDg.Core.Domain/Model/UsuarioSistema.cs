using System;
using System.Collections.Generic;
using System.Text;

namespace BarDg.Core.Domain.Model
{
    public class UsuarioSistema
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
    }
}
