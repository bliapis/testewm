using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Moq;
using Xunit;
using WM.API.ViewModels;
using WM.API.Controllers;
using WM.Domain.Core.Bus;
using WM.Domain.Core.Notifications;
using WM.Domain.Cliente.Clientes.Entities;
using WM.Domain.Cliente.Clientes.Interfaces;

namespace WM.Tests.API.UnitTests
{
    public class ClienteControllerTests
    {
        public ClienteController clienteController;
        public Mock<DomainNotificationHandler> mockNotification;
        public Mock<IMapper> mockMapper;
        public Mock<IClienteService> mockClienteService;

        public ClienteControllerTests()
        {
            mockMapper = new Mock<IMapper>();
            mockNotification = new Mock<DomainNotificationHandler>();
            mockClienteService = new Mock<IClienteService>();
            var mockBus = new Mock<IBus>();

            clienteController = new ClienteController(
                mockBus.Object,
                mockMapper.Object,
                mockClienteService.Object,
                mockNotification.Object);
        }

        [Fact]
        public void ClienteAdd_RetornarComSucesso()
        {
            // Arrange
            var clienteViewModel = new ClienteViewModel();
            var clienteModel = new ClienteModel("Bruno", 31);
        
            mockMapper.Setup(m => m.Map<ClienteModel>(clienteViewModel)).Returns(clienteModel);
            mockNotification.Setup(m => m.GetNotifications()).Returns(new List<DomainNotification>());
        
            // Act
            var result = clienteController.ClientesAdd(clienteViewModel);
        
            // Assert
            mockClienteService.Verify(m => m.Adicionar(clienteModel), Times.Once);
            Assert.IsType<OkObjectResult>(result);
        }
    }
}