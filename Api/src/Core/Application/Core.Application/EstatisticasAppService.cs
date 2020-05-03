using Application.Abstractions;
using Application.Interfaces;
using Application.Queries;
using Core.BaseWeb.ViewModel;
using Core.Domain.Interfaces.Concrete.Repository;
using Core.Domain.Repository.Interfaces;
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

        public async Task<IList<EstatisticasResultViewModel>> ObterEstatisticasPorTime(string nomeTime)
        {
            var posicoes = await _posicaoRepository.ObterLista(nomeTime);
            return posicoes.AsQueryable().AsEstatisticasTimeResult().ToList();

        }

        public async Task<IList<EstatisticasResultViewModel>> ObterEstatisticasPorTime()
        {
            var posicoes = await _posicaoRepository.ObterLista();

            return posicoes.AsQueryable().AsEstatisticasTimeResult().ToList();

        }

        public async Task<IList<EstatisticasResultViewModel>> ObterEstatisticasPorEstado()
        {
            var posicoes = await _posicaoRepository.ObterLista();
            return posicoes.AsQueryable().AsEstadoStatisticsResult().ToList();
        }
    }
}
