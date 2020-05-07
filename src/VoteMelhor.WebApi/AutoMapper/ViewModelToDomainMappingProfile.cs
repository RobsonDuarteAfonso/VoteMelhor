using AutoMapper;
/* using VoteMelhor.Domain.Entities;
using VoteMelhor.WebApi.ViewModels; */

namespace VoteMelhor.WebApi.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
/*             CreateMap<CargoViewModel, Cargo>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Atual, opt => opt.MapFrom(src => src.Atual))
                .ForMember(dest => dest.Politico, opt => opt.MapFrom(src => src.Politico))
                .ForMember(dest => dest.PoliticoId, dest => dest.Ignore())
                .ReverseMap();

            CreateMap<ClassificacaoViewModel, Classificacao>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Rate))
                .ForMember(dest => dest.Politico, opt => opt.MapFrom(src => src.Politico))
                .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.Usuario))
                .ForMember(dest => dest.UsuarioId, dest => dest.Ignore())
                .ForMember(dest => dest.PoliticoId, dest => dest.Ignore())
                .ReverseMap();

            CreateMap<PartidoViewModel, Partido>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Numero, opt => opt.MapFrom(src => src.Numero))
                .ForMember(dest => dest.Sigla, opt => opt.MapFrom(src => src.Sigla))
                .ForMember(dest => dest.Imagem, opt => opt.MapFrom(src => src.Imagem))
                .ForMember(dest => dest.PoliticoPartidos, opt => opt.MapFrom(src => src.PoliticoPartidos))
                .ReverseMap();

            CreateMap<PoliticoViewModel, Politico>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado))
                .ForMember(dest => dest.Imagem, opt => opt.MapFrom(src => src.Imagem))
                .ForMember(dest => dest.Cargos, opt => opt.MapFrom(src => src.Cargos))
                .ForMember(dest => dest.PoliticoPartidos, opt => opt.MapFrom(src => src.PoliticoPartidos))
                .ForMember(dest => dest.Processos, opt => opt.MapFrom(src => src.Processos))
                .ForMember(dest => dest.Classificacoes, opt => opt.MapFrom(src => src.Classificacoes))
                .ForMember(dest => dest.Votacoes, opt => opt.MapFrom(src => src.Votacoes))
                .ReverseMap();

            CreateMap<PoliticoPartidoViewModel, PoliticoPartido>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Atual, opt => opt.MapFrom(src => src.Atual))
                .ForMember(dest => dest.Politico, opt => opt.MapFrom(src => src.Politico))
                .ForMember(dest => dest.Partido, opt => opt.MapFrom(src => src.Partido))
                .ForMember(dest => dest.PartidoId, dest => dest.Ignore())
                .ForMember(dest => dest.PoliticoId, dest => dest.Ignore())
                .ReverseMap();

            CreateMap<ProcessoViewModel, Processo>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Resumo, opt => opt.MapFrom(src => src.Resumo))
                .ForMember(dest => dest.Detalhe, opt => opt.MapFrom(src => src.Detalhe))
                .ForMember(dest => dest.DtAtualizacao, opt => opt.MapFrom(src => src.DtAtualizacao))
                .ForMember(dest => dest.DtPublicacao, opt => opt.MapFrom(src => src.DtPublicacao))
                .ForMember(dest => dest.Situacao, opt => opt.MapFrom(src => src.Situacao))
                .ForMember(dest => dest.PoliticoId, dest => dest.Ignore())
                .ReverseMap();

            CreateMap<PropostaViewModel, Proposta>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CasaLegislativa, opt => opt.MapFrom(src => src.CasaLegislativa))
                .ForMember(dest => dest.TipoProposta, opt => opt.MapFrom(src => src.TipoProposta))
                .ForMember(dest => dest.Numeracao, opt => opt.MapFrom(src => src.Numeracao))
                .ForMember(dest => dest.Resumo, opt => opt.MapFrom(src => src.Resumo))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
                .ForMember(dest => dest.DtProposta, opt => opt.MapFrom(src => src.DtProposta))
                .ReverseMap();

            CreateMap<UsuarioViewModel, Usuario>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => src.Senha))
                .ForMember(dest => dest.StatusUsuario, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.CodigoConfirmacao, opt => opt.MapFrom(src => src.CodigoConfirmacao))
                .ForMember(dest => dest.Perfil, opt => opt.MapFrom(src => src.Perfil))
                .ForMember(dest => dest.Classificacoes, opt => opt.MapFrom(src => src.Classificacoes))
                .ReverseMap();

            CreateMap<VotacaoViewModel, Votacao>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Voto, opt => opt.MapFrom(src => src.Voto))
                .ForMember(dest => dest.DtVotacao, opt => opt.MapFrom(src => src.DtVotacao))
                .ForMember(dest => dest.Politico, opt => opt.MapFrom(src => src.Politico))
                .ForMember(dest => dest.Proposta, opt => opt.MapFrom(src => src.Proposta))
                .ForMember(dest => dest.PropostaId, dest => dest.Ignore())
                .ForMember(dest => dest.PoliticoId, dest => dest.Ignore())
                .ReverseMap(); */
        }
    }
}