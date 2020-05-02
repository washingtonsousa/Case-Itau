using Core.Data.EF.Context;
using Core.Domain.Entities.Concrete.Database;
using Core.Domain.Interfaces.Concrete.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Repository
{
    public class EstadoRepository : Repository, IEstadoRepository
    {
        public EstadoRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task AddRange(IList<Estado> estados)
        {
            await _context.Estados.AddRangeAsync(estados);
        }

        public async Task<Estado> Get(string uF)
        {
            return await _context.Estados.AsNoTracking().FirstOrDefaultAsync(e => e.UF == uF);
        }

        public async Task<IList<Estado>> Get()
        {
            return await _context.Estados.AsNoTracking().ToListAsync();
        }
    }
}
