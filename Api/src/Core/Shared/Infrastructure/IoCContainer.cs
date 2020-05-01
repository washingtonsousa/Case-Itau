using AutoMapper;
using Core.Application;
using Core.Application.Interfaces;
using Core.Domain.Singleton;
using Core.BaseWeb.AutoMapper;
using Core.Data.EF.Context;
using Core.Data.Repository;
using Core.Domain.Repository.Interfaces.Concrete;
using Core.Domain.Interfaces;
using Core.Domain.Repository;
using Core.Domain.Repository.Interfaces;
using Core.Domain.Repository.UnityOfWork;
using Core.Shared.Kernel.Events;
using Core.Shared.Kernel.Handles;
using Core.Shared.Kernel.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Core.Domain.Interfaces.Concrete.Services;
using Core.Domain.Services;
using Core.Domain.Interfaces.Concrete.Repository;
using System;

namespace Core.Infrastructure
{
  public static class IoCContainer
  {

    public static void InjectAll(this IServiceCollection services)
    {
      InjectScoped(services);
      InjectDataRepositories( services);
      InjectApplicationServices( services);
      InjectDomainServices(services);
      InjectDomainSpecifications(services);
      InjectScoped( services);
      InjectDataRepositories(services);
      InjectExtensions(services);
    }

    public static void InjectScoped(this IServiceCollection services)
    {
      services.AddScoped<DatabaseContext, DatabaseContext>();
      services.AddScoped<IUnityOfWork, UnityOfWork>();
      services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
    }

    public static void InjectDataRepositories(this IServiceCollection services)
    {
      services.AddTransient<ICategoriaRepository, CategoriaRepository>();
      services.AddTransient<IDadosLojaRepository, DadosLojaRepository>();
      services.AddTransient<IUsuarioRepository, UsuarioRepository>();
      services.AddTransient<IApplicationModuleRepository, ApplicationModuleRepository>();
    }

    public static void InjectDomainSpecifications(this IServiceCollection services)
    {
    }

    public static void InjectApplicationServices(this IServiceCollection services)
    {

    }

    public static void InjectDomainServices(this IServiceCollection services)
    {
    }

    public static void InjectExtensions(this IServiceCollection services)
    {

      services.AddSingleton(new MapperConfiguration(mc =>
      {
        mc.AddProfile(new DefaultMappingProfile());
      }).CreateMapper());

      services.AddScoped<IDomainEventContainer, DomainEvent>();
      services.AddSingleton(services.BuildServiceProvider());
      services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

    }

    public static IServiceProvider BuildAppServiceProvider(this IServiceCollection services)
    {

      IServiceProvider provider = services.BuildServiceProvider();

      services.AddSingleton(provider);

      return provider;

    }

  }
}
