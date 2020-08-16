using BarDg.Core.Domain.Model;
using Dapper.FluentMap.Dommel.Mapping;

namespace BarDg.Infra.Repository.Mappers
{
    public class PedidoMap : DommelEntityMap<Pedido>, IBaseMap
    {
        public PedidoMap()
        {
            ToTable("TbBDG_Pedidos");
            Map(x => x.Id).ToColumn("ID_PEDIDO");
            Map(x => x.Nome).ToColumn("NM_PEDIDO");
            Map(x => x.Preco).ToColumn("VL_PEDIDO");
        }
    }
}
