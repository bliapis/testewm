using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using WM.Domain.Core.Bus;
using WM.Domain.Core.Interfaces;
using WM.Domain.Core.Notifications;
using WM.Infra.CrossCutting.Bus;
using WM.Domain.Cliente.Clientes.Interfaces;
using WM.Domain.Cliente.Clientes.Services;
using WM.Infra.Data.Cliente.Context;
using WM.Infra.Data.Cliente.Repository;
using WM.Infra.Data.Cliente.UoW;

namespace WM.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            //ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton(Mapper.Configuration);

            #region Domains

            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();

            #region Domain Anuncio

            services.AddScoped<IClienteService, ClienteService>();

            #endregion

            #endregion

            #region Infra

            //Gerencial Data
            services.AddScoped<ClienteContext>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #endregion

            #region CrossCutting
            //Bus
            services.AddScoped<IBus, InMemoryBus>();
            #endregion
        }
    }
}