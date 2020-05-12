using System;
using System.Collections.Generic;
using WM.Domain.Cliente.Clientes.Entities;

namespace WM.Domain.Cliente.Clientes.Interfaces
{
    public interface IClienteService : IDisposable
    {
        IEnumerable<ClienteModel> ObterTodos();
        void Adicionar(ClienteModel anuncio);
        ClienteModel ObterPorId(Guid id);
        void Editar(ClienteModel anuncio);
        void Remover(Guid id);
    }
}