using AutoMapper;
using BarDg.Api.Dto;
using BarDg.Core.Domain.Model;

namespace BarDg.Api.Config
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<PedidoDto, Pedido>();
            CreateMap<Pedido, PedidoDto>();

            CreateMap<ResultadoDto, Resultado>();
            CreateMap<Resultado, ResultadoDto>();

            CreateMap<UsuarioSistemaDto, UsuarioSistema>();
            CreateMap<UsuarioSistema, UsuarioSistemaDto>();

            CreateMap<ComandaDto, Comanda>();
            CreateMap<Comanda, ComandaDto>();
        }
    }
}
