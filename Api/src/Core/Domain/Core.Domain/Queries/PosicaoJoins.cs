using Core.Domain.Entities.Concrete.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Domain.Queries
{
    public static class PosicaoJoins
    {
        public static IIncludableQueryable<Posicao, object> AsFullJoin(this IQueryable<Posicao> timeQueryable)
        {
            return timeQueryable.Include(t => t.Time).ThenInclude(t => t.Estado).Include(t => t.Campeonato);
        }

    }
}
