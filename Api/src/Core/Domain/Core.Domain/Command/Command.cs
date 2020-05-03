using Core.Shared.Kernel.Abstractions;
using System.Threading.Tasks;

namespace Core.Domain.Command
{
    public abstract class Command : Notifiable
    {
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
