using Application;
using Application.Interfaces;
using AppTests.Facades;
using Core.BaseWeb.ViewModel;
using Core.Data.EF.Context;
using Core.Data.UnityOfWork;
using Core.Domain.Fakes;
using Core.Domain.Repository;
using Core.Domain.Repository.Interfaces;
using Core.Shared.Kernel.Events;
using Core.Shared.Kernel.Handles;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace AppTests
{

    public class EstatisticasTest
    {
        private readonly Mock<IUnityOfWork> _mockUnityOfWork = new Mock<IUnityOfWork>();


        [Fact]
        public void EstatisticasPorTimeQueNaoExisteRetornaVazio()
        {

            IEstatisticasAppService appService = new EstatisticasAppService(
                _mockUnityOfWork.Object, 
                new AssertionConcern(new DomainNotificationContext()), 
                new PosicaoRepository(new DatabaseContext(ConfigurationFacade.BuildConfiguraion())));

            IList<EstatisticasResultadosViewModel> resultado =
                appService.ObterEstatisticasPorTime("Time que não existe").GetAwaiter().GetResult();


            Assert.Null(resultado);
        }


        [Fact]
        public void EstatisticasPorTimeRetornamTodosOsTimes()
        {

            IEstatisticasAppService appService = new EstatisticasAppService(
                _mockUnityOfWork.Object,
                new AssertionConcern(new DomainNotificationContext()),
                new PosicaoRepository(new DatabaseContext(ConfigurationFacade.BuildConfiguraion())));

            IList<EstatisticasResultadosViewModel> resultado =
                appService.ObterEstatisticasPorTime().GetAwaiter().GetResult();


            Assert.NotNull(resultado);
        }

        [InlineData("CORINTHIANS")]
        [InlineData("santos")]
        [InlineData("Avai")]
        [Theory]
        public void EstatisticasPorTimeRetornaTimeSelecionado(string nomeTime)
        {

            IEstatisticasAppService appService = new EstatisticasAppService(
                _mockUnityOfWork.Object,
                new AssertionConcern(new DomainNotificationContext()),
                new PosicaoRepository(new DatabaseContext(ConfigurationFacade.BuildConfiguraion())));

            IList<EstatisticasResultadosViewModel> resultado = 
                appService.ObterEstatisticasPorTime(nomeTime).GetAwaiter().GetResult();


            Assert.NotNull(resultado);
        }


        [Fact]
        public void EstatisticasPorEstadosRetornaEstados()
        {

            IEstatisticasAppService appService = new EstatisticasAppService(
                _mockUnityOfWork.Object,
                new AssertionConcern(new DomainNotificationContext()),
                new PosicaoRepository(new DatabaseContext(ConfigurationFacade.BuildConfiguraion())));

            IList<EstatisticasResultadosViewModel> resultado = 
                appService.ObterEstatisticasPorEstado().GetAwaiter().GetResult();


            Assert.NotNull(resultado);
        }


        [Fact]
        public void EstatisticasRetornamResultadosGerais()
        {

            IEstatisticasAppService appService = new EstatisticasAppService(
                _mockUnityOfWork.Object,
                new AssertionConcern(new DomainNotificationContext()),
                new PosicaoRepository(new DatabaseContext(ConfigurationFacade.BuildConfiguraion())));

            EstatisticasResultadosGeraisViewModel resultado = 
                appService.ObterResultadoGeral().GetAwaiter().GetResult();


            Assert.NotNull(resultado);
        }

    }
}
