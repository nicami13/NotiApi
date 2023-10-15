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
        CreateMap<Formato, FormatoDto>().ReverseMap();
        CreateMap<GenericovsSubmodulos, GenericovsSubmodulosDto>().ReverseMap();
        CreateMap<HiloRespuestaNotificacion, HiloRespuestaNotificacionDto>().ReverseMap();
        CreateMap<MaestrovsSubmodulos, MaestroVsSubmodulosDto>().ReverseMap();
        CreateMap<ModuloNotificaciones, ModuloNotificacionesDto>().ReverseMap()
        CreateMap<ModuloMaestro, ModuloMaestroDto>().ReverseMap();
        CreateMap<PermisosGenericos, PermisosGenericosDto>().ReverseMap();
        CreateMap<Radicados, RadicadosDto>().ReverseMap();
        CreateMap<RolvsMaestro, RolvsMaestroDto>().ReverseMap();
        CreateMap<RolvsMaestro, RolvsMaestroDto>().ReverseMap();
        CreateMap<Submodulos, SubmodulosDto>().ReverseMap();
        CreateMap<TipoNotificacion, TipoNotificacionesDto>().ReverseMap();
        CreateMap<TipoRequerimiento, TipoRequerimientoDto>().ReverseMap();

       

    }
}