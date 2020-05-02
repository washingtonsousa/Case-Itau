using Core.Application.Abstractions;
using Core.Application.Interfaces;
using Core.Domain.Command;
using Core.Domain.Entities.Concrete.Database;
using Core.Domain.Entities.Concrete.Files;
using Core.Domain.Facade;
using Core.Domain.Interfaces.Concrete.Factories;
using Core.Domain.Interfaces.Concrete.Repository;
using Core.Domain.Queries;
using Core.Domain.Repository.Interfaces;
using Core.Shared.Data;
using Core.Shared.Kernel.Events;
using Core.Shared.Kernel.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application
{
    public class ImportDataAppService : ApplicationService, IImportDataAppService
    {
        public ImportDataAppService(IUnityOfWork unityOfWork, 
            IEstadoRepository estadoRepository, 
            IClassificacaoFactory classificacaoFactory, 
            ICampeonatoRepository campeonatoRepository) : base(unityOfWork)
        {
            _classificacaoFactory = classificacaoFactory;
            _estadoRepository = estadoRepository;
            _campeonatoRepository = campeonatoRepository;
        }

        private  IClassificacaoFactory _classificacaoFactory { get; }
        private  IEstadoRepository _estadoRepository { get; }
        private  ICampeonatoRepository _campeonatoRepository { get; }
        private IList<Classificacao> classificacaoList;

        public async Task ExecuteDataImport()
        {

            classificacaoList = _classificacaoFactory.CreateClassificacaoListFromFile(Constants.DEFAULT_ETL_FILE_NAME);

            var estados = classificacaoList.GetEstados();
            var campeonatos = classificacaoList.GetCampeonatos();

            foreach(var estado in estados)
             estado.AddTimes(classificacaoList.GetTimesByEstado(estado.UF));

            await _estadoRepository.AddRange(estados);

            foreach(var classificacao in classificacaoList)
            {

                var estado = estados.FirstOrDefault(e => e.UF == classificacao.Estado);
                var time = estado.Times.FirstOrDefault(t => classificacao.Time == t.Nome);
                var campeonato = campeonatos.FirstOrDefault(e => e.Ano == classificacao.Ano);

                campeonato.AddPosicao(new Posicao(time, campeonato, classificacao.Pontos, classificacao.Jogos, classificacao.Vitorias,
                                        classificacao.Empates, classificacao.Derrotas, classificacao.GolsPro, classificacao.GolsContra, 
                                        classificacao.Posicao));

            }

            await _campeonatoRepository.AddRange(campeonatos);

            await _unityOfWork.CommitAsync();

        }


    }
}
