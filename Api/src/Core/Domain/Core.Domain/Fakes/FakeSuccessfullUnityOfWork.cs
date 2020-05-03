using Core.Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Fakes
{
    public class FakeSuccessfullUnityOfWork : IUnityOfWork
    {
        public bool Commit(bool mandatory = true)
        {
            return true;
        }

        public Task<bool> CommitAsync(bool mandatory = true)
        {
            return Task.FromResult(true);
        }

        public bool Migrate(bool mandatory = true)
        {
            return true;
        }

        public Task<bool> MigrateAsync(bool mandatory = true)
        {
            return Task.FromResult(true);
        }
    }
}
