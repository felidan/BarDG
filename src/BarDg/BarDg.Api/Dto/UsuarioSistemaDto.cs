using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarDg.Api.Dto
{
    public class UsuarioSistemaDto
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
    }
}
