using AutoMapper;

using HJR.FinanceControl.WebApp.Models;
using HJR.FinanceControl.WebApp.ViewModels;

namespace HJR.FinanceControl.WebApp.Helpers.AutoMapper.Profiles
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ContaAPagar, ContaAPagarViewModel>();
            CreateMap<ContaAReceber, ContaAReceberViewModel>();
        }
    }
}