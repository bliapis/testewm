using System;
using System.Collections.Generic;
using WM.Domain.Anuncio.Anuncio.Entities;
using WM.Domain.Anuncio.Anuncio.Interfaces;
using WM.Domain.Anuncio.Service;
using WM.Domain.Core.Bus;
using WM.Domain.Core.Interfaces;
using WM.Domain.Core.Notifications;

namespace WM.Domain.Anuncio.Anuncio.Services
{
    public class AnuncioService : ServiceBase, IAnuncioService
    {
        private readonly IBus _bus;
        private readonly IAnuncioRepository _anuncioRepo;

        public AnuncioService(
            IUnitOfWork uow,
            IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications,
            IAnuncioRepository anuncioRepo) : base(uow, bus, notifications)
        {
            _bus = bus;
            _anuncioRepo = anuncioRepo;
        }

        public IEnumerable<AnuncioModel> ObterTodos()
        {
            var anucios = _anuncioRepo.GetAll();
            return anucios;
        }

        public AnuncioModel ObterPorId(int id)
        {
            return _anuncioRepo.GetById(id);
        }

        public void Adicionar(AnuncioModel anuncio)
        {
            if(!ValidAnuncio(anuncio)) return;

            _anuncioRepo.Add(anuncio);

            Commit();
        }

        public void Editar(AnuncioModel anuncio)
        {
            if (!ValidAnuncio(anuncio)) return;

            _anuncioRepo.Update(anuncio);

            Commit();
        }

        public void Remover(int id)
        {
            if (!ChecarAnuncioExistente(id, "2", false)) return;

            _anuncioRepo.Remove(id);

            Commit();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private bool ValidAnuncio(AnuncioModel anuncio)
        {
            if (anuncio.IsValid()) return true;

            NotifyErrorValidation(anuncio.ValidationResult);
            return false;
        }

        private bool ChecarAnuncioExistente(int id, string messageType, bool raiseMsg)
        {
            var menu = _anuncioRepo.GetById(id);

            if (menu != null) return true;

            if (raiseMsg)
                _bus.RaiseEvent(new DomainNotification(messageType, "Anuncio não encontrado."));

            return false;
        }
    }
}