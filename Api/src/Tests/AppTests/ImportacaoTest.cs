using Application;
using Application.Interfaces;
using AppTests.Facades;
using Core.Data.EF.Context;
using Core.Data.UnityOfWork;
using Core.Domain.Entities.Concrete.Database;
using Core.Domain.Entities.Concrete.Files;
using Core.Domain.Factories;
using Core.Domain.Interfaces.Concrete.Factories;
using Core.Domain.Interfaces.Concrete.Repository;
using Core.Domain.Repository;
using Core.Domain.Repository.Interfaces;
using Core.Shared.Kernel.Events;
using Core.Shared.Kernel.Handles;
using Core.Shared.Kernel.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AppTests
{
    public class ImportacaoTest
    {

        private readonly Mock<IUnityOfWork> _mockUnityOfWork = new Mock<IUnityOfWork>();
        private readonly Mock<IEstadoRepository> _mockEstadoRepository = new Mock<IEstadoRepository>();
        private readonly Mock<ICampeonatoRepository> _mockCampeonatoRepository = new Mock<ICampeonatoRepository>();
        private readonly Mock<IClassificacaoFactory> _mockClassificacaoFactory = new Mock<IClassificacaoFactory>();
        private readonly DomainNotificationContext _domain = new DomainNotificationContext();


        //Simula importacao com sucesso
        [Fact]
        public void ProcessoDeImportacaoExecutaComSucesso()
        {


            var assertionConcern = new AssertionConcern(_domain);

            var listaClassificacaoFake = new List<Classificacao>() {

                new Classificacao(1,2019,"CORINTHIANS", "SP", 60,38,20,0,0,60,10)

             };

            _mockUnityOfWork.Setup(e => e.CommitAsync(true)).Returns(Task.FromResult(true));
            _mockUnityOfWork.Setup(e => e.MigrateAsync(false)).Returns(Task.FromResult(true));
            _mockClassificacaoFactory.Setup(e => e.CreateClassificacaoListFromFile("Dados.txt")).Returns(listaClassificacaoFake);

            IList<Campeonato> listaCampeonatoVazia = new List<Campeonato>();

            _mockCampeonatoRepository.Setup(e => e.ObterLista()).Returns(Task.FromResult(listaCampeonatoVazia));

            IImportaDadosAppService importDataAppService = new ImportaDadosAppService(

                _mockUnityOfWork.Object,
                assertionConcern,
                _mockEstadoRepository.Object,
                _mockClassificacaoFactory.Object,
                _mockCampeonatoRepository.Object

            );

            importDataAppService.ExecutarImportacaoDeDados();

            //Processo Gera Notificações?
            Assert.False(_domain.HasNotifications());


        }


        //Simula importacao com sucesso
        [Fact]
        public void ProcessoDeImportacaoGeraFalhaCasoListaClassificacaoRetornadaVazia()
        {

            var assertionConcern = new AssertionConcern(_domain);

            var listaClassificacaoFake = new List<Classificacao>();

            _mockUnityOfWork.Setup(e => e.CommitAsync(true)).Returns(Task.FromResult(true));
            _mockUnityOfWork.Setup(e => e.MigrateAsync(false)).Returns(Task.FromResult(true));
            _mockClassificacaoFactory.Setup(e => e.CreateClassificacaoListFromFile("Dados.txt")).Returns(listaClassificacaoFake);

            IList<Campeonato> listaCampeonatoVazia = new List<Campeonato>();

            _mockCampeonatoRepository.Setup(e => e.ObterLista()).Returns(Task.FromResult(listaCampeonatoVazia));

            IImportaDadosAppService importDataAppService = new ImportaDadosAppService(

                _mockUnityOfWork.Object,
                assertionConcern,
                _mockEstadoRepository.Object,
                _mockClassificacaoFactory.Object,
                _mockCampeonatoRepository.Object

            );

            importDataAppService.ExecutarImportacaoDeDados();

            //Processo Gera Notificações?
            Assert.True(_domain.HasNotifications());


        }


    }
}
