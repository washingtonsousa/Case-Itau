using Application.Abstractions;
using Application.Helper;
using Application.Interfaces;
using Application.Queries;
using Core.BaseWeb.ViewModel;
using Core.Domain.Interfaces.Concrete.Repository;
using Core.Domain.Repository.Interfaces;
using Core.Domain.Specification;
using Core.Shared.Kernel.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application
{
    public class EstatisticasAppService : ApplicationService, IEstatisticasAppService
    {
        public EstatisticasAppService(IUnityOfWork unityOfWork, IAssertionConcern assertionConcern,
            ITimeRepository timeRepository, IPosicaoRepository posicaoRepository) : base(unityOfWork, assertionConcern)
        {
            _timeRepository = timeRepository;
            _posicaoRepository = posicaoRepository;
        }

        public ITimeRepository _timeRepository { get; }
        public IPosicaoRepository _posicaoRepository { get; }

        public async Task<IList<EstatisticasResultadosViewModel>> ObterEstatisticasPorTime(string nomeTime)
        {
            var posicoes = await _posicaoRepository.ObterLista(nomeTime);

            if (posicoes.TimeNaoEncontradoNasPosicoes(_assertionConcern))
                return null;

            return posicoes.AsQueryable().AsEstatisticasTimeResult().ToList();

        }

        public async Task<IList<EstatisticasResultadosViewModel>> ObterEstatisticasPorTime()
        {
            var posicoes = await _posicaoRepository.ObterLista();

            if (posicoes.DadosNaoExistem(_assertionConcern))
                return null;

            return posicoes.AsQueryable().AsEstatisticasTimeResult().ToList();

        }

        public async Task<IList<EstatisticasResultadosViewModel>> ObterEstatisticasPorEstado()
        {
            var posicoes = await _posicaoRepository.ObterLista();

            if (posicoes.DadosNaoExistem(_assertionConcern))
                return null;

            return posicoes.AsQueryable().AsEstadoStatisticsResult().ToList();
        }

        public async Task<EstatisticasResultadosGeraisViewModel> ObterResultadoGeral()
        {
            var posicoes = await _posicaoRepository.ObterLista();

            if (posicoes.DadosNaoExistem(_assertionConcern))
                return null;

            var resultadoArtilharia = posicoes.AsQueryable().AsResultadoArtilharia().RemoveSelfReference();
            var resultadoDefesa = posicoes.AsQueryable().AsResultadoDefesa().RemoveSelfReference();
            var resultadoVitorias = posicoes.AsQueryable().AsResultadoVitorias(true).RemoveSelfReference();
            var resultadoMenorVitorias = posicoes.AsQueryable().AsResultadoVitorias().RemoveSelfReference();
            var resultadoMaiorMediaVitorias = posicoes.AsQueryable().AsResultadoMediaVitorias(true).RemoveSelfReference();
            var resultadoMenorMediaVitorias = posicoes.AsQueryable().AsResultadoMediaVitorias().RemoveSelfReference();

            var resultado = new EstatisticasResultadosGeraisViewModel(
                resultadoArtilharia, 
                resultadoDefesa, 
                resultadoVitorias, 
                resultadoMenorVitorias, 
                resultadoMaiorMediaVitorias, 
                resultadoMenorMediaVitorias); 


            return resultado;
        }

         
    }
}
