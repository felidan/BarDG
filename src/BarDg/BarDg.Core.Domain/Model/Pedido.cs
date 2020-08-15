namespace BarDg.Core.Domain.Model
{
    public class Pedido
    {
        public int Id { get; set; }
        public int IdComanda { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public decimal Desconto { get; set; }
    }
}
