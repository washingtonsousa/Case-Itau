using Core.Domain.Repository.Interfaces;
using Core.Data.EF.Context;
using System;
using System.Threading.Tasks;
using Core.Shared.Kernel.Events;

namespace Core.Domain.Repository.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork
    {

        private DatabaseContext Context;

        public UnityOfWork(DatabaseContext context)
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
            DomainEvent.DomainNotify(new DomainNotification("AssertException",
                 ex.InnerException != null ? ex.InnerException.Message : ex.Message
            ));
        }
    }
}
