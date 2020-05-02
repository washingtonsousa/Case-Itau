using Core.Shared.Kernel.Events;
using Core.Shared.Kernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Command
{
    public class InsertPosicoesCommand : Command
    {
        public InsertPosicoesCommand(IDomainNotificationContext<DomainNotification> domainNotification) : base(domainNotification)
        {
        }

        protected override Task ExecuteOperation()
        {
            throw new NotImplementedException();
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
