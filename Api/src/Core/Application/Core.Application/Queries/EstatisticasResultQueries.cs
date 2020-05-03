using Core.BaseWeb.ViewModel;
using Core.Domain.Entities.Concrete.Database;

using System.Linq;

namespace Application.Queries
{
    public static class EstatisticasResultQueries
    {


        public static IQueryable<EstatisticasResultViewModel> AsEstatisticasTimeResult(this IQueryable<Posicao> query)
        {

            return query.GroupBy(p => p.Time)
           .Select((p) =>
            new EstatisticasResultViewModel(0, p.Key.Nome,
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


        public static IQueryable<EstatisticasResultViewModel> AsEstadoStatisticsResult(this IQueryable<Posicao> query)
        {

            return query.GroupBy(p => p.Time.Estado)

           .Select((p) =>
            new EstatisticasResultViewModel(0, p.Key.UF,
            p.Sum(x => x.Pontos),
            ///Obtem o numero de ocorrencias do estado agrupados pelo campeonato
            p.Where(x =>  p.Key.Times.Any(time => time.Posicoes.Any(pe => pe.Campeonato.Id == x.Campeonato.Id)))
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

        public static IQueryable<EstatisticasResultViewModel> AsOrdemPadraoEstatisticas(this IQueryable<EstatisticasResultViewModel> query)
        {

            return query
            .OrderByDescending(p => p.Pontos)
            .ThenByDescending(p => p.Vitorias)
            .ThenByDescending(p => p.SaldoGols)
            .Select((p, index) => p.SetPosicaoAndReturnItSelf(index + 1));
        }
    }
}
