using Core.Domain.Entities.Concrete.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Interfaces.Concrete.Repository
{
    public interface ICampeonatoRepository
    {

        Task AddRange(IList<Campeonato> campeonatos);

    }
}
