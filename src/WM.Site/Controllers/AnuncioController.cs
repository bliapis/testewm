using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WM.Site.Models;
using WM.Domain.Anuncio.Anuncio.Interfaces;
using WM.Domain.Core.Notifications;
using WM.Domain.Core.Bus;
using WM.Domain.Anuncio.Anuncio.Entities;
using System.Linq;

namespace WM.Site.Controllers
{
    [Controller]
    public class AnuncioController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IAnuncioService _service;

        public AnuncioController(
            IDomainNotificationHandler<DomainNotification> notifications,
            IBus bus,
            IMapper mapper,
            IAnuncioService service) : base(notifications, bus)
        {
            _service = service;
        }

        // GET: Anuncio
        [Route("[action]")]
        public async Task<IActionResult> Index()
        {
            var result = _service.ObterTodos(); 
            return View(result.Any() ? _mapper.Map<IEnumerable<AnuncioViewModel>>(result) : new List<AnuncioViewModel>());
        }

        // GET: Anuncio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncioViewModel = _service.ObterPorId((int)id);
            if (anuncioViewModel == null)
            {
                return NotFound();
            }

            return View(new AnuncioViewModel());
        }

        // GET: Anuncio/Create
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Anuncio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public async Task<IActionResult> Create([Bind("Id,Marca,Modelo,Versao,Ano,Quilometragem,Observacao")] AnuncioViewModel anuncioViewModel)
        {
            if (ModelState.IsValid)
            {
                _service.Adicionar(_mapper.Map<AnuncioModel>(anuncioViewModel));
                return RedirectToAction(nameof(Index));
            }
            return View(new AnuncioViewModel());
        }

        // GET: Anuncio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncioViewModel = _mapper.Map<AnuncioViewModel>(_service.ObterPorId((int)id));
            if (anuncioViewModel == null)
            {
                return NotFound();
            }
            return View(new AnuncioViewModel());
        }

        // POST: Anuncio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Marca,Modelo,Versao,Ano,Quilometragem,Observacao")] AnuncioViewModel anuncioViewModel)
        {
            if (id != anuncioViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _service.Editar(_mapper.Map<AnuncioModel>(anuncioViewModel));
                return RedirectToAction(nameof(Index));
            }
            return View(new AnuncioViewModel());
        }

        // GET: Anuncio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncioViewModel = _mapper.Map<AnuncioViewModel>(_service.ObterPorId((int)id));
            if (anuncioViewModel == null)
            {
                return NotFound();
            }

            return View(new AnuncioViewModel());
        }

        // POST: Anuncio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _service.Remover((int)id);
            return RedirectToAction(nameof(Index));
        }
    }
}
