
using Core.Domain.Entities.Concrete.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Domain.Interfaces.Concrete.Repository
{
    public interface ITimeRepository
    {

        Task<IList<Time>> Get();

        Task<Time> Get(string nome);

        Task<Time> Get(int idTime);

    }
}
