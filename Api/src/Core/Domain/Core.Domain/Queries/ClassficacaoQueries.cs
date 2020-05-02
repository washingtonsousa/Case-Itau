using Core.Domain.Entities.Concrete.Database;
using Core.Domain.Entities.Concrete.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.Domain.Queries
{
    public static class ClassficacaoQueries
    {
        public static IList<Estado>  GetEstados(this IList<Classificacao> classificacao) {

            return classificacao.GroupBy(c => c.Estado)
                .Select(c => new Estado(c.Key)).ToList(); 
        }

        public static IList<Time> GetTimesByEstado(this IList<Classificacao> classificacao, string uF)
        {
            return classificacao.Where(c => c.Estado == uF).GroupBy(c => c.Time)
                .Select(c => new Time(c.Key)).ToList();
        }

        public static IList<Campeonato> GetCampeonatos(this IList<Classificacao> classificacao)
        {
            return classificacao.GroupBy(c => c.Ano)
                .Select(c => new Campeonato(c.Key)).ToList();
        }

    }
}
