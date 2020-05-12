using AutoMapper;
using WM.API.ViewModels;
using WM.Domain.Cliente.Clientes.Entities;

namespace WM.API.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteViewModel, ClienteModel>()
                .ConstructUsing(c => new ClienteModel(c.Nome, c.Idade));
        }
    }
}
