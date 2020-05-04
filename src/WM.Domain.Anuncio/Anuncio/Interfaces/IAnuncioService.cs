using System;
using System.Collections.Generic;
using WM.Domain.Anuncio.Anuncio.Entities;

namespace WM.Domain.Anuncio.Anuncio.Interfaces
{
    public interface IAnuncioService : IDisposable
    {
        IEnumerable<AnuncioModel> ObterTodos();
        void Adicionar(AnuncioModel anuncio);
        AnuncioModel ObterPorId(int id);
        void Editar(AnuncioModel anuncio);
        void Remover(int id);
    }
}