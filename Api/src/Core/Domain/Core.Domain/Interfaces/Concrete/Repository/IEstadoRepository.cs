using Core.Domain.Entities.Concrete.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Domain.Interfaces.Concrete.Repository
{
    public interface IEstadoRepository
    {
        Task<Estado> Get(string uF);
        Task<IList<Estado>> Get();
        Task AddRange(IList<Estado> estados);
    }
}
