using Core.Data.EF.Context;
using Core.Domain.Entities.Concrete.Database;
using Core.Domain.Interfaces.Concrete.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Repository
{
    public class CampeonatoRepository : Repository, ICampeonatoRepository
    {
        public CampeonatoRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task AddRange(IList<Campeonato> campeonatos)
        {
            await _context.AddRangeAsync(campeonatos);
        }
    }
}
