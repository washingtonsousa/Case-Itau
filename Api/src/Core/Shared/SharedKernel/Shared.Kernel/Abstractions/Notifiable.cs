using Core.Shared.Kernel.Events;
using System;
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

        public readonly IList<DomainNotification> Notifications = new List<DomainNotification>();

        protected void AddNotification(params DomainNotification[] notifications)
        {
            var notificationsNotNull = notifications.Where(notification => notification != null).ToList();

            notificationsNotNull.ForEach(notification =>
            {
                Notifications.Add(notification);
            });

        }


        protected void AddNotificationFromException(Exception ex)
        {
            AddNotification(new DomainNotification("AssertException",
               ex.InnerException != null ? ex.InnerException.Message : ex.Message
          ));

        }

    }
}
