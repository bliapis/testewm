using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WM.API.ViewModels;
using WM.Domain.Core.Bus;
using WM.Domain.Core.Notifications;
using WM.Domain.Cliente.Clientes.Entities;
using WM.Domain.Cliente.Clientes.Interfaces;

namespace WM.API.Controllers
{
    [ApiController]
    [Route("clientes/")]
    public class ClienteController : BaseController
    {
        private readonly IMapper _mapper;
        IClienteService _clienteService;

        public ClienteController(
            IBus bus,
            IMapper mapper,
            IClienteService clienteService,
            IDomainNotificationHandler<DomainNotification> notifications) : base(notifications, bus)
        {
            _mapper = mapper;
            _clienteService = clienteService;
        }

        [HttpGet] // Obter Todos
        [Route("todos")]
        public IActionResult ClientesGetAll()
        {
            var result = _mapper.Map<IEnumerable<ClienteViewModel>>(_clienteService.ObterTodos());
        
            return Response(result);
        }

        [HttpPost] // Adicionar
        [Route("adicionar")]
        public IActionResult ClientesAdd(ClienteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida();
                return Response(model);
            }
        
            _clienteService.Adicionar(_mapper.Map<ClienteModel>(model));
        
            return Response();
        }
        
        [HttpPut] // Editar
        [Route("editar")]
        public IActionResult ClientesEdit(ClienteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida();
                return Response(model);
            }
        
            _clienteService.Editar(_mapper.Map<ClienteModel>(model));
        
            return Response();
        }
        
        [HttpDelete] // Remover
        [Route("remover/{id}")]
        public IActionResult ClientesRemove(Guid id)
        {
            _clienteService.Remover(id);
        
            return Response();
        }
    }
}