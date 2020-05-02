using Core.Shared.Kernel.Abstractions;
using Core.Shared.Kernel.Events;
using Core.Shared.Kernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Command
{
    public abstract class Command : Notifiable
    {
        public Command(IDomainNotificationContext<DomainNotification> domainNotification) : base(domainNotification)
        {
        }

        protected abstract Task ExecuteOperation();
        protected abstract void Validate();
        public async Task Execute()
        {
             Validate();

            if (!Invalid)
                await ExecuteOperation();
        }
    }
}
