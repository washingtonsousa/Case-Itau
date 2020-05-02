using Core.Shared.Kernel.Events;
using Core.Shared.Kernel.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Core.Shared.Kernel.Handles
{
    public class DomainNotificationContext : IDomainNotificationContext<DomainNotification>
    {
        private List<DomainNotification> _notifications = new List<DomainNotification>();

        public void AddNotification(DomainNotification args)
        {
            _notifications.Add(args);
        }

        public void AddNotifications(IList<DomainNotification> args)
        {
            _notifications.AddRange(args);
        }

        public List<DomainNotification> Notify()
        {
            return GetValue();
        }

        private List<DomainNotification> GetValue()
        {
            return _notifications;
        }

        public bool HasNotifications()
        {
            return GetValue().Count > 0;
        }

        public string GetFirstNotification()
        {
            if (HasNotifications())
            {

                return _notifications.OrderBy(x => x.Rank).FirstOrDefault().Value;


            }

            return string.Empty;
        }


    }
}
