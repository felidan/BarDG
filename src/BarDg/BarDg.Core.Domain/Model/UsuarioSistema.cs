namespace BarDg.Core.Domain.Model
{
    public class UsuarioSistema
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public bool SenhaOk { get; set; }
    }
}
