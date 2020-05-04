using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using WM.Domain.Anuncio.Anuncio.Interfaces;
using WM.Domain.Anuncio.Anuncio.Services;
using WM.Domain.Core.Bus;
using WM.Domain.Core.Interfaces;
using WM.Domain.Core.Notifications;
using WM.Infra.CrossCutting.Bus;
using WM.Infra.Data.Anuncio.Context;
using WM.Infra.Data.Anuncio.Repository;
using WM.Infra.Data.Anuncio.UoW;
using Microsoft.AspNetCore.Http;

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

            services.AddScoped<IAnuncioService, AnuncioService>();

            #endregion

            #endregion

            #region Infra

            //Gerencial Data
            services.AddScoped<AnuncioContext>();
            services.AddScoped<IAnuncioRepository, AnuncioRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #endregion

            #region CrossCutting
            //Bus
            services.AddScoped<IBus, InMemoryBus>();
            #endregion
        }
    }
}