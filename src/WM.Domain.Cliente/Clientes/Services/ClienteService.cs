using System;
using System.Collections.Generic;
using WM.Domain.Core.Bus;
using WM.Domain.Core.Interfaces;
using WM.Domain.Core.Notifications;
using WM.Domain.Cliente.Clientes.Entities;
using WM.Domain.Cliente.Clientes.Interfaces;
using WM.Domain.Cliente.Service;

namespace WM.Domain.Cliente.Clientes.Services
{
    public class ClienteService : ServiceBase, IClienteService
    {
        private readonly IBus _bus;
        private readonly IClienteRepository _clienteRepo;

        public ClienteService(
            IUnitOfWork uow,
            IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications,
            IClienteRepository clienteRepo) : base(uow, bus, notifications)
        {
            _bus = bus;
            _clienteRepo = clienteRepo;
        }

        public IEnumerable<ClienteModel> ObterTodos()
        {
            var clientes = _clienteRepo.GetAll();
            return clientes;
        }

        public ClienteModel ObterPorId(Guid id)
        {
            return _clienteRepo.GetById(id);
        }

        public void Adicionar(ClienteModel cliente)
        {
            cliente.Id = Guid.NewGuid();
            if (!ValidCliente(cliente)) return;

            _clienteRepo.Add(cliente);

            Commit();
        }

        public void Editar(ClienteModel cliente)
        {
            if (!ValidCliente(cliente)) return;

            _clienteRepo.Update(cliente);

            Commit();
        }

        public void Remover(Guid id)
        {
            if (!ChecarClienteExistente(id, "2", false)) return;

            _clienteRepo.Remove(id);

            Commit();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private bool ValidCliente(ClienteModel cliente)
        {
            if (cliente.IsValid()) return true;

            NotifyErrorValidation(cliente.ValidationResult);
            return false;
        }

        private bool ChecarClienteExistente(Guid id, string messageType, bool raiseMsg)
        {
            var menu = _clienteRepo.GetById(id);

            if (menu != null) return true;

            if (raiseMsg)
                _bus.RaiseEvent(new DomainNotification(messageType, "Cliente não encontrado."));

            return false;
        }
    }
}