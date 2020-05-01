using Core.Shared.Kernel.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Core.Shared.Kernel.Events
{
  public class DomainEvent : IDomainEventContainer
  {
    private static IServiceProvider _serviceProvider;

    public DomainEvent(IServiceProvider serviceProvider)
    {
      _serviceProvider = serviceProvider;
    }

    public void Raise<T>(T args) where T : IDomainEvent
    {
      if (_serviceProvider != null)
      {
        foreach (var handler in _serviceProvider.GetServices<IHandler<T>>())
          ((IHandler<T>)handler).Handle(args);
      }
    }

    public void Notify<T>(T args) where T : IDomainEvent
    {
      if (_serviceProvider != null)
      {
        foreach (var handler in _serviceProvider.GetServices<IDomainNotificationHandler<T>>())
          handler.Handle(args);
      }
    }


    public static void DomainNotify(DomainNotification args)
    {
      if (_serviceProvider != null)
      {
        foreach (var handler in _serviceProvider.GetServices<IDomainNotificationHandler<DomainNotification>>())
          handler.Handle(args);
      }
    }
  }
}
