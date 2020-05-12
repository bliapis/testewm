using AutoMapper;
using WM.API.ViewModels;
using WM.Domain.Cliente.Clientes.Entities;

namespace WM.API.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ClienteModel, ClienteViewModel>();
        }
    }
}
