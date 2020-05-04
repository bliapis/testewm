using System;
using System.Collections.Generic;
using WM.Domain.Anuncio.Anuncio.Entities;
using WM.Domain.Anuncio.Repository;

namespace WM.Domain.Anuncio.Anuncio.Interfaces
{
    public interface IAnuncioRepository : IRepository<AnuncioModel>
    {
    }
}