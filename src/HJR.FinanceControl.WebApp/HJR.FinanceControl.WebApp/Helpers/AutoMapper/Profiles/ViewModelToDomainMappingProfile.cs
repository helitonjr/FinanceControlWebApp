using AutoMapper;

using HJR.FinanceControl.WebApp.Models;
using HJR.FinanceControl.WebApp.ViewModels;

namespace HJR.FinanceControl.WebApp.Helpers.AutoMapper.Profiles
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ContaAPagarViewModel, ContaAPagar>();
            CreateMap<ContaAReceberViewModel, ContaAReceber>();
        }
    }
}