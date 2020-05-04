using Core.Domain.Entities.Concrete.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Domain.Interfaces.Concrete.Repository
{
    public interface ICampeonatoRepository
    {

        Task AddRange(IList<Campeonato> campeonatos);
        Task<IList<Campeonato>> ObterLista();

    }
}
