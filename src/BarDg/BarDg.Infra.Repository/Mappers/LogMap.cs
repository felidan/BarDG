using BarDg.Core.Domain.Model;
using Dapper.FluentMap.Dommel.Mapping;

namespace BarDg.Infra.Repository.Mappers
{
    class LogMap : DommelEntityMap<Log>, IBaseMap
    {
        public LogMap()
        {
            ToTable("TbBDG_Log");
            Map(x => x.IdLog).ToColumn("ID_LOG");
            Map(x => x.Descricao).ToColumn("DS_LOG");
            Map(x => x.Mensagem).ToColumn("DS_MENSAGEM");
            Map(x => x.StackTrace).ToColumn("DS_STACK_TRACE");
            Map(x => x.Level).ToColumn("DS_LEVEL");
            Map(x => x.DataLog).ToColumn("DT_LOG");
            Map(x => x.Objeto).ToColumn("DS_OBJETO");
        }
    }
}
