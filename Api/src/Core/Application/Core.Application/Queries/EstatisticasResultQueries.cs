using Core.BaseWeb.ViewModel;
using Core.BaseWeb.ViewModel.ValueObject;
using Core.Domain.Entities.Concrete.Database;

using System.Linq;

namespace Application.Queries
{
    public static class EstatisticasResultQueries
    {


        public static IQueryable<EstatisticasResultadosViewModel> AsEstatisticasTimeResult(this IQueryable<Posicao> query)
        {

            return query.GroupBy(p => p.Time)
           .Select((p) =>
            new EstatisticasResultadosViewModel(0, p.Key.Nome,
            p.Sum(x => x.Pontos),
            p.Key.Posicoes.GroupBy(c => c.Campeonato).Count(),
            p.Sum(x => x.Jogos),
            p.Sum(x => x.Vitorias),
            p.Sum(x => x.Empates),
            p.Sum(x => x.Derrotas),
            p.Sum(x => x.GolsPro),
            p.Sum(x => x.GolsContra)))
            .AsOrdemPadraoEstatisticas()
            .Select((p, index) => p.SetPosicaoAndReturnItSelf(index + 1));
        }


        public static IQueryable<EstatisticasResultadosViewModel> AsEstadoEstatisticasResult(this IQueryable<Posicao> query)
        {

            return query.GroupBy(p => p.Time.Estado)

           .Select((p) =>
            new EstatisticasResultadosViewModel(0, p.Key.UF,
            p.Sum(x => x.Pontos),
            ///Obtem o numero de ocorrencias do estado agrupados pelo campeonato
            p.Where(x => p.Key.Times.Any(time => time.Posicoes.Any(pe => pe.Campeonato.Id == x.Campeonato.Id)))
            .GroupBy(group => group.Campeonato).Count(),
            p.Sum(x => x.Jogos),
            p.Sum(x => x.Vitorias),
            p.Sum(x => x.Empates),
            p.Sum(x => x.Derrotas),
            p.Sum(x => x.GolsPro),
            p.Sum(x => x.GolsContra))).
            AsOrdemPadraoEstatisticas()
            .Select((p, index) => p.SetPosicaoAndReturnItSelf(index + 1));
        }

        public static IQueryable<EstatisticasResultadosViewModel> AsOrdemPadraoEstatisticas(this IQueryable<EstatisticasResultadosViewModel> query)
        {

            return query
            .OrderByDescending(p => p.Pontos)
            .ThenByDescending(p => p.Vitorias)
            .ThenByDescending(p => p.SaldoGols)
            .Select((p, index) => p.SetPosicaoAndReturnItSelf(index + 1));
        }


        public static TimeResultado AsResultadoArtilharia(this IQueryable<Posicao> query)
        {

            var resultQuery = query.GroupBy(p => new { p.Time })
                .Select(
                e =>
                 new TimeResultado(e.Key.Time, e.Sum(e => (e.GolsPro / e.Jogos))))
               .OrderByDescending(t => t.Valor).AsQueryable();

            return resultQuery.FirstOrDefault();
        }

        public static TimeResultado AsResultadoDefesa(this IQueryable<Posicao> query)
        {
            var resultQuery = query.GroupBy(p => new { p.Time })
                .Select(
                e =>
                 new TimeResultado(e.Key.Time, e.Sum(e => (e.GolsContra / e.Jogos)))).OrderBy(t => t.Valor).AsQueryable()
               .OrderBy(t => t.Valor).AsQueryable();


            return resultQuery.FirstOrDefault();
        }

        public static TimeResultado AsResultadoVitorias(this IQueryable<Posicao> query, bool decrescente = false)
        {
            var resultQuery = query.GroupBy(p => new { p.Time })
                .Select(
                e =>
                 new TimeResultado(e.Key.Time, e.Sum(e => e.Vitorias)))
                .OrderBy(t => t.Valor)
                .AsQueryable();

            if (decrescente)
                resultQuery = resultQuery.OrderByDescending(t => t.Valor).AsQueryable();


            return resultQuery.FirstOrDefault();
        }

        public static TimeResultado AsResultadoMediaVitorias(this IQueryable<Posicao> query, bool decrescente = false)
        {
            var resultQuery = query.GroupBy(p => new { p.Time})
                .Select(
                e =>
                 new TimeResultado(e.Key.Time, e.Sum(e => e.Vitorias) / query.GroupBy(p => p.Campeonato).Count()))
                .OrderBy(t => t.Valor).AsQueryable();

            if (decrescente)
                resultQuery = resultQuery.OrderByDescending(t => t.Valor).AsQueryable();


            return resultQuery.FirstOrDefault();
        }
    }
}
