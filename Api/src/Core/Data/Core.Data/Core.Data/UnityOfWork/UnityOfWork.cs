using Core.Domain.Repository.Interfaces;
using Core.Data.EF.Context;
using System;
using System.Threading.Tasks;
using Core.Shared.Kernel.Events;
using Core.Shared.Kernel.Abstractions;
using Core.Shared.Kernel.Interfaces;

namespace Core.Data.UnityOfWork
{
    public class UnityOfWork : Notifiable, IUnityOfWork
    {

        private DatabaseContext Context;

        public UnityOfWork(DatabaseContext context, IDomainNotificationContext<DomainNotification> domainNotificationContext) : base (domainNotificationContext)
        {
            Context = context;
        }

        public void Commit()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                OnError(ex);
            }
        }

        public async Task CommitAsync()
        {
            try
            {
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                OnError(ex);
            }

        }

        private void OnError(Exception ex)
        {
            AddNotification(new DomainNotification("AssertException",
                 ex.InnerException != null ? ex.InnerException.Message : ex.Message
            ));
        }
    }
}
