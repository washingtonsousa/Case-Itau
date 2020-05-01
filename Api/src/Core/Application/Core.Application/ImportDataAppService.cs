using Core.Application.Abstractions;
using Core.Application.Interfaces;
using Core.Domain.Entities.Concrete.Database;
using Core.Domain.Entities.Concrete.Files;
using Core.Domain.Facade;
using Core.Domain.Interfaces.Concrete.Factories;
using Core.Domain.Repository.Interfaces;
using Core.Shared.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Application
{
    public class ImportDataAppService : ApplicationService, IImportDataAppService
    {
        public ImportDataAppService(IUnityOfWork unityOfWork, IClassificacaoFactory classificacaoFactory) : base(unityOfWork)
        {
            _classificacaoFactory = classificacaoFactory;
        }

        public IClassificacaoFactory _classificacaoFactory { get; private set; }

        public void ExecuteDataImport()
        {

            IList<Classificacao> classificacaoList = _classificacaoFactory.CreateClassificacaoListFromFile(Constants.DEFAULT_ETL_FILE_NAME);

            IList<Estado> estados = classificacaoList
                .GroupBy(c => c.Estado)
                .Select(c => new Estado(c.Key)).ToList();

            IList<Time> times = classificacaoList
               .GroupBy(c => c.Time)
               .Select(c => new Time(c.Key)).ToList();

            IList<Brasileirao> anos = classificacaoList
               .GroupBy(c => c.Ano)
               .Select(c => new Brasileirao(c.Key)).ToList();



        }


    }
}
