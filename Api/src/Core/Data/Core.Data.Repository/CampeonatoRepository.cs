using Core.Data.EF.Context;
using Core.Domain.Entities.Concrete.Database;
using Core.Domain.Interfaces.Concrete.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Domain.Repository
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

        public async Task<IList<Campeonato>> Get()
        {
           return await _context.Campeonatos.ToListAsync();
        }
    }
}
