using AutoMapper;
using VoteMelhor.Domain.Entities;
using VoteMelhor.WebApi.ViewModels;

namespace VoteMelhor.WebApi.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cargo, CargoViewModel>();
        }
    }
}
