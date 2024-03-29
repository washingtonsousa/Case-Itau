using Core.Shared.Kernel.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Core.Shared.Kernel.Events
{
    public class DomainEvent 
    {
        public IServiceProvider ServiceProvider;

        public DomainEvent(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public void Raise<T>(T args) where T : IDomainEvent
        {
           
                foreach (var handler in ServiceProvider.GetServices<IHandler<T>>())
                    ((IHandler<T>)handler).Handle(args);
            
        }

        public void Notify<T>(T args) where T : IDomainEvent
        {
           
                foreach (var handler in ServiceProvider.GetServices<IHandler<T>>())
                    handler.Handle(args);
            
        }


        public void DomainNotify(DomainNotification args)
        {
      
                foreach (var handler in ServiceProvider.GetServices<IDomainNotificationContext<DomainNotification>>())
                    handler.AddNotification(args);
            
        }
    }
}
