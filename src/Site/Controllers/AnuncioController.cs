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
using Site.Utils;
using Microsoft.Extensions.Configuration;
using Site.Models;

namespace WM.Site.Controllers
{
    public class AnuncioController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IAnuncioService _service;
        private readonly IConfiguration _configuration;

        public AnuncioController(
            IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications,
            IMapper mapper,
            IAnuncioService service,
            IConfiguration configuration) : base(notifications, bus)
        {
            _service = service;
            _mapper = mapper;
            _configuration = configuration;
        }

        // GET: Anuncio
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<AnuncioViewModel>>(_service.ObterTodos()));
        }

        // GET: Anuncio/Details/5
        public async Task<IActionResult> Details(int? id)
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

            return View(anuncioViewModel);
        }

        // GET: Anuncio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Anuncio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Modelo,Versao,Ano,Quilometragem,Observacao")] AnuncioViewModel anuncioViewModel)
        {
            if (ModelState.IsValid)
            {
                _service.Adicionar(_mapper.Map<AnuncioModel>(anuncioViewModel));
                return RedirectToAction(nameof(Index));
            }
            return View(anuncioViewModel);
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
            return View(anuncioViewModel);
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
            return View(anuncioViewModel);
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

            return View(anuncioViewModel);
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

        [HttpGet]
        public JsonResult GetMarcas()
        {
            var callResult = ServiceApi.Call(_configuration, HttpContext, "Make", ServiceType.GET);
            List<SimpleReturn> marcas = new List<SimpleReturn>();

            if (!callResult.Success)
            {
                return Json(new
                {
                    error = "Ocorreu um erro, não foi possível carregar os dados.",
                    data = new List<SimpleReturn>()
                });
            }

            return Json(new
            {
                data = callResult.Data
            });
        }

        [HttpGet]
        public JsonResult GetModelo(string marcaId)
        {
            var callResult = ServiceApi.Call(_configuration, HttpContext, "Model", ServiceType.GET, marcaId, true, null, "MakeID");
            List <SimpleReturn> marcas = new List<SimpleReturn>();

            if (!callResult.Success)
            {
                return Json(new
                {
                    error = "Ocorreu um erro, não foi possível carregar os dados.",
                    data = new List<SimpleReturn>()
                });
            }

            return Json(new
            {
                data = callResult.Data
            });
        }

        [HttpGet]
        public JsonResult GetVersao(string modeloId)
        {
            var callResult = ServiceApi.Call(_configuration, HttpContext, "Version", ServiceType.GET, modeloId, true, null, "ModelID");
            List<SimpleReturn> marcas = new List<SimpleReturn>();

            if (!callResult.Success)
            {
                return Json(new
                {
                    error = "Ocorreu um erro, não foi possível carregar os dados.",
                    data = new List<SimpleReturn>()
                });
            }

            return Json(new
            {
                data = callResult.Data
            });
        }
    }
}
