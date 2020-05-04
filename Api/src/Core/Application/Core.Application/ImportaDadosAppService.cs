using Application.Abstractions;
using Application.Interfaces;
using Core.Domain.Entities.Concrete.Database;
using Core.Domain.Entities.Concrete.Files;
using Core.Domain.Helpers;
using Core.Domain.Interfaces.Concrete.Factories;
using Core.Domain.Interfaces.Concrete.Repository;
using Core.Domain.Repository.Interfaces;
using Core.Domain.Specification;
using Core.Shared.Data;
using Core.Shared.Kernel.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application
{
    public class ImportaDadosAppService : ApplicationService, IImportaDadosAppService
    {
        public ImportaDadosAppService(IUnityOfWork unityOfWork,
            IAssertionConcern assertionConcern,
            IEstadoRepository estadoRepository,
            IClassificacaoFactory classificacaoFactory,
            ICampeonatoRepository campeonatoRepository) : base(unityOfWork, assertionConcern)
        {
            _classificacaoFactory = classificacaoFactory;
            _estadoRepository = estadoRepository;
            _campeonatoRepository = campeonatoRepository;
        }

        private IClassificacaoFactory _classificacaoFactory { get; }
        private IEstadoRepository _estadoRepository { get; }
        private ICampeonatoRepository _campeonatoRepository { get; }


        /// <summary>
        /// Executa o processo inicial de importação de dados e caso a base de dados não exista já realiza a migração inicial
        /// </summary>
        /// <returns>TASK VOID</returns>
        public async Task<bool> ExecutarImportacaoDeDados()
        {

            await _unityOfWork.MigrateAsync(false);

            var campeonatosFromDb = await _campeonatoRepository.ObterLista();

            IList<Classificacao> classificacaoList = _classificacaoFactory.CreateClassificacaoListFromFile(Constants.DEFAULT_ETL_FILE_NAME);

            if (!classificacaoList.Validar(_assertionConcern))
                return false;

            if (classificacaoList.JaFoiImportado(campeonatosFromDb, _assertionConcern))
                return false;

            classificacaoList = classificacaoList.Where(c => !campeonatosFromDb.Any(cp => cp.Ano == c.Ano)).ToList();

            var estados = classificacaoList.AsEstados();
            var campeonatos = classificacaoList.AsCampeonatos();

            foreach (var estado in estados)
                estado.SetTimes(classificacaoList.AsTimesPorEstado(estado.UF));

            await _estadoRepository.AddRange(estados);

            AddPosicoesForCampeonatos(classificacaoList, estados, campeonatos);

            await _campeonatoRepository.AddRange(campeonatos);
            
            return await _unityOfWork.CommitAsync();


        }

        private static void AddPosicoesForCampeonatos(IList<Classificacao> classificacaoList, IList<Estado> estados, IList<Campeonato> campeonatos)
        {
            foreach (var classificacao in classificacaoList)
            {

                var estado = estados.FirstOrDefault(e => e.UF == classificacao.Estado);
                var time = estado.Times.FirstOrDefault(t => classificacao.Time == t.Nome);
                var campeonato = campeonatos.FirstOrDefault(e => e.Ano == classificacao.Ano);

                campeonato.AddPosicao(new Posicao(time, campeonato, classificacao.Pontos, classificacao.Jogos, classificacao.Vitorias,
                                        classificacao.Empates, classificacao.Derrotas, classificacao.GolsPro, classificacao.GolsContra,
                                        classificacao.Posicao));

            }
        }
    }
}
