using AutoMapper;
using WM.Domain.Anuncio.Anuncio.Entities;
using WM.Site.Models;

namespace WM.Site.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            #region Menu
            CreateMap<AnuncioModel, AnuncioViewModel>();
            #endregion
        }
    }
}