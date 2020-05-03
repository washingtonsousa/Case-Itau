using Application;
using Application.Interfaces;
using Core.Data.EF.Context;
using Core.Data.UnityOfWork;
using Core.Domain.Factories;
using Core.Domain.Interfaces.Concrete.Factories;
using Core.Domain.Interfaces.Concrete.Repository;
using Core.Domain.Repository;
using Core.Domain.Repository.Interfaces;
using Core.Shared.Kernel.Events;
using Core.Shared.Kernel.Handles;
using Core.Shared.Kernel.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Core.Infrastructure
{
    public static class IoCContainer
    {

        public static void InjectAll(this IServiceCollection services)
        {
            InjectScoped(services);
            InjectDataRepositories(services);
            InjectApplicationServices(services);
            InjectScoped(services);
            InjectDataRepositories(services);
            InjectExtensions(services);
            InjectDomainFactories(services);
        }

        public static void InjectScoped(this IServiceCollection services)
        {
            services.AddScoped<DatabaseContext>();
            services.AddScoped<IUnityOfWork, UnityOfWork>();
            services.AddScoped<IDomainNotificationContext<DomainNotification>, DomainNotificationContext>();
            services.AddTransient<IAssertionConcern, AssertionConcern>();
        }

        public static void InjectDataRepositories(this IServiceCollection services)
        {
            services.AddTransient<IEstadoRepository, EstadoRepository>();
            services.AddTransient<ICampeonatoRepository, CampeonatoRepository>();
            services.AddTransient<ITimeRepository, TimeRepository>();
            services.AddTransient<IPosicaoRepository, PosicaoRepository>();
        }

        public static void InjectDomainFactories(this IServiceCollection services)
        {
            services.AddTransient<IClassificacaoFactory, ClassificacaoFactory>();
        }

        public static void InjectApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IImportDataAppService, ImportaDadosAppService>();
            services.AddTransient<IEstatisticasAppService, EstatisticasAppService>();
        }

        public static void InjectExtensions(this IServiceCollection services)
        {           
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        }

    }
}
