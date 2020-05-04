using AutoMapper;
using WM.Site.Models;
using WM.Domain.Anuncio.Anuncio.Entities;

namespace WM.Site.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            #region Anuncio
            CreateMap<AnuncioViewModel, AnuncioModel>();
            #endregion
        }
    }
}