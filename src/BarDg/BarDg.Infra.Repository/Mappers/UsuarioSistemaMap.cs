using BarDg.Core.Domain.Model;
using Dapper.FluentMap.Dommel.Mapping;

namespace BarDg.Infra.Repository.Mappers
{
    public class UsuarioSistemaMap : DommelEntityMap<UsuarioSistema>, IBaseMap
    {
        public UsuarioSistemaMap()
        {
            ToTable("TbBDG_UsuarioSistema");
            Map(x => x.Id).ToColumn("ID_USUARIO_SISTEMA");
            Map(x => x.Login).ToColumn("DS_LOGIN");
            Map(x => x.Ativo).ToColumn("FL_ATIVO");
        }
    }
}
