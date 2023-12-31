using Api.Dtos;
using AutoMapper;
using Core.entities;

namespace Api.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Auditoria, AuditoriaDto>().ReverseMap();
        CreateMap<BlockChain, BlockChainDto>().ReverseMap();
        CreateMap<EstadoNotificacion, EstadoNotificacionDto>().ReverseMap();
        CreateMap<Formatos, FormatoDto>().ReverseMap();
        CreateMap<GenericovsSubmodulos, GenericovsSubmodulosDto>().ReverseMap();
        CreateMap<HiloRespuestaNotificacion,HiloRespuestaNotificaionDto>().ReverseMap();
        CreateMap<MaestrovsSubmodulos, MaestroVsSubmodulosDto>().ReverseMap();
        CreateMap<ModuloNotificaciones, ModuloNotificacionesDto>().ReverseMap();
        CreateMap<ModuloMaestro, ModuloMaestro>().ReverseMap();
        CreateMap<PermisosGenericos, PermisosGenericosDto>().ReverseMap();
        CreateMap<Radicados, RadicadosDto>().ReverseMap();
        CreateMap<RolvsMaestro, RolvsMaestroDto>().ReverseMap();
        CreateMap<RolvsMaestro, RolvsMaestroDto>().ReverseMap();
        CreateMap<SubModulos, SubmodulosDto>().ReverseMap();
        CreateMap<TipoNotificacion, TipoNotficiaonesDto>().ReverseMap();
        CreateMap<TipoRequerimiento, TipoRequerimientoDto>().ReverseMap();

       

    }
}

