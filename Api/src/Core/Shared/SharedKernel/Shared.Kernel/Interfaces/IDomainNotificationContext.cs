using Core.Shared.Kernel.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Shared.Kernel.Interfaces
{
    public interface IDomainNotificationContext<T>
    {
        List<DomainNotification> Notify();

        bool HasNotifications();

        string GetFirstNotification();


        void AddNotification(DomainNotification args);


        void AddNotifications(IList<DomainNotification> args);

    }
}
