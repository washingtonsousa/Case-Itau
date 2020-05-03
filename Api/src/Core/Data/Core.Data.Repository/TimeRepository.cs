using Core.Data.EF.Context;
using Core.Domain.Entities.Concrete.Database;
using Core.Domain.Interfaces.Concrete.Repository;
using Core.Domain.Queries;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Domain.Repository
{
    public class TimeRepository : Repository, ITimeRepository
    {
        public TimeRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<IList<Time>> Get()
        {

           return await _context.Times.ToListAsync();
        }

        public async Task<Time> Get(string nome)
        {
            return await _context.Times.FirstOrDefaultAsync(t => t.Nome == nome);
        }

        public async Task<Time> Get(int idTime)
        {
            return await _context.Times.FirstOrDefaultAsync(t => t.Id == idTime);
        }
    }
}
