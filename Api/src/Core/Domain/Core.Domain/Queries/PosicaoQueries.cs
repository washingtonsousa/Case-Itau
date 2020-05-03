using Core.Domain.Entities.Concrete.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.Domain.Queries
{
    public static class PosicaoQueries
    {

        public static IQueryable<Posicao> AsDefaultQuery(this IQueryable<Posicao> query, string nomeTime)
        {
            if (!string.IsNullOrEmpty(nomeTime))
                query = query.Where(q => q.Time.Nome == nomeTime).AsQueryable();

            return query;
        }

   

    }
}
