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
