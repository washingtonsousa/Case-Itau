using Core.Shared.Kernel.Events;
using Core.Shared.Kernel.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Core.Shared.Kernel.Abstractions
{
    public abstract class Notifiable
    {
        [NotMapped]
        public bool Invalid { get {

                return Notifications?.Count > 0;
            
            } }

        public IDomainNotificationContext<DomainNotification> _domainNotification { get; }

        public readonly IList<DomainNotification> Notifications = new List<DomainNotification>();

        public Notifiable(IDomainNotificationContext<DomainNotification> domainNotification)
        {
            _domainNotification = domainNotification;
        }


        protected void AddNotification(params DomainNotification[] notifications)
        {
            var notificationsNotNull = notifications.Where(notification => notification != null).ToList();

            notificationsNotNull.ForEach(notification =>
            {
                Notifications.Add(notification);
                _domainNotification.AddNotification(notification);
            });

        }

    }
}
