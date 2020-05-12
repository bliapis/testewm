namespace WM.Test.API
{
    public class ClienteControllerTests
    {
        //public ClienteController clienteController;
        //public Mock<DomainNotificationHandler> mockNotification;
        //public Mock<IMapper> mockMapper;
        //public Mock<IClienteService> mockClienteService;
        //
        //public ClienteControllerTests()
        //{
        //    mockMapper = new Mock<IMapper>();
        //    mockNotification = new Mock<DomainNotificationHandler>();
        //    mockClienteService = new Mock<IClienteService>();
        //    var mockBus = new Mock<IBus>();
        //
        //    clienteController = new ClienteController(
        //        mockBus.Object,
        //        mockMapper.Object,
        //        mockClienteService.Object,
        //        mockNotification.Object);
        //}

        //[Fact]
        //public void TipoPermissao_Add_RetornarComSucesso()
        //{
        //    // Arrange
        //    var clienteViewModel = new ClienteViewModel();
        //    var clienteModel = new ClienteModel("Bruno", 31);
        //
        //    mockMapper.Setup(m => m.Map<ClienteModel>(clienteViewModel)).Returns(clienteModel);
        //    mockNotification.Setup(m => m.GetNotifications()).Returns(new List<DomainNotification>());
        //
        //    // Act
        //    var result = clienteController.ClientesAdd(clienteViewModel);
        //
        //    // Assert
        //    mockClienteService.Verify(m => m.Adicionar(clienteModel), Times.Once);
        //    Assert.IsType<OkObjectResult>(result);
        //}

        //[Fact]
        //public void TipoPermissaoAdd_RetornarComErrosDeModelState()
        //{
        //    // Arrange
        //    var notficationList = new List<DomainNotification> { new DomainNotification("Erro", "ModelError") };
        //
        //    mockNotification.Setup(m => m.GetNotifications()).Returns(notficationList);
        //    mockNotification.Setup(m => m.HasNotifications()).Returns(true);
        //
        //    permissaoController.ModelState.AddModelError("Erro", "ModelErro");
        //
        //    // Act
        //    var result = permissaoController.TipoPermissaoAdd(new TipoPermissaoViewModel());
        //
        //    // Assert
        //    mockTipoPermissaoService.Verify(m => m.Adicionar(It.IsAny<TipoPermissaoModel>()), Times.Never);
        //    Assert.IsType<BadRequestObjectResult>(result);
        //}
        //
        //[Fact]
        //public void TipoPermissaoAdd_RetornarComErrosDeDominio()
        //{
        //    var tipoPermissaoViewModel = new TipoPermissaoViewModel();
        //    var tipoPermissaoModel = new TipoPermissaoModel("Teste");
        //
        //    mockMapper.Setup(m => m.Map<TipoPermissaoModel>(tipoPermissaoViewModel)).Returns(tipoPermissaoModel);
        //
        //    var notficationList = new List<DomainNotification> { new DomainNotification("Erro", "Erro ao adicionar novo Tipo de Permissao") };
        //
        //    mockNotification.Setup(m => m.GetNotifications()).Returns(notficationList);
        //    mockNotification.Setup(m => m.HasNotifications()).Returns(true);
        //
        //    // Act
        //    var result = permissaoController.TipoPermissaoAdd(tipoPermissaoViewModel);
        //
        //    // Assert
        //    mockTipoPermissaoService.Verify(m => m.Adicionar(tipoPermissaoModel), Times.Once);
        //    Assert.IsType<BadRequestObjectResult>(result);
        //}
    }
}
