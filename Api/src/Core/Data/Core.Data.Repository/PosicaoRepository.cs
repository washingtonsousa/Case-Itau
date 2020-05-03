using Core.Data.EF.Context;
using Core.Domain.Entities.Concrete.Database;
using Core.Domain.Interfaces.Concrete.Repository;
using Core.Domain.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Repository
{
    public class PosicaoRepository : Repository, IPosicaoRepository
    {
        public PosicaoRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<Posicao> Obter(string nomeTime = null)
        {
            var query = _context.Posicoes.AsQueryable().AsFullJoin().AsDefaultQuery(nomeTime);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IList<Posicao>> ObterLista(string nomeTime = null)
        {
            var query = _context.Posicoes.AsQueryable().AsFullJoin().AsDefaultQuery(nomeTime);

            return await query.ToListAsync();
        }
    }
}
