using Core.Domain.Entities.Concrete.Files;
using Core.Domain.Facade;
using Core.Domain.Interfaces.Concrete.Factories;
using Core.Shared.Kernel.Abstractions;
using Core.Shared.Kernel.Events;
using Core.Shared.Kernel.Helpers;
using Core.Shared.Kernel.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Core.Shared.Data;
using Core.Domain.Helpers;
using Core.Domain.Enums;

namespace Core.Domain.Factories
{
    public class ClassificacaoFactory : IClassificacaoFactory
    {

        public ClassificacaoFactory(ILogger<ClassificacaoFactory> logger, IDomainNotificationContext<DomainNotification> domainNotificationContext)
        {
            _domainNotificationContext = domainNotificationContext;
            _logger = logger;
        }

        private IDomainNotificationContext<DomainNotification> _domainNotificationContext { get; }
        public ILogger<ClassificacaoFactory> _logger { get; }

        /// <summary>
        /// Executa um processo de extração de dados de um arquivo de texto em memória para o tipo Classificacao a partir de um arquivo
        /// formatado que obedeça as especificações de linha e coluna desenhados no documento do case
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Retorna uma lista de classificacoes, caso ocorra erro irá retornar uma lista vazia e adicionará uma notificação</returns>
        public IList<Classificacao> CreateClassificacaoListFromFile(string fileName)
        {
            IList<Classificacao> classificacaoList = new List<Classificacao>();

            _logger.LogInformation(1002, "Iniciando processo de importação de dados de arquivo para a memória");

            try
            {
                var strList = FileReaderFacade.ObterListaDeStringPorArquivoDeTexto(fileName);

                int campeonatosNumber = strList.Count / 22;

                for (int index = 0; index < campeonatosNumber; index++)
                {

                    int skipIndex = (index == 0) ? 0 : index * 22;
                    var timesList = strList.Skip(skipIndex + 2).Take(20);
                    int ano = int.Parse(strList.Skip(skipIndex).FirstOrDefault());

                    foreach (string line in timesList)
                    {
                        var columnsList = line.Split(Constants.DEFAULT_ETL_COLUMN_SEPARATOR).PrepararColunaTimeParaClassificacao();

                        classificacaoList.Add(new Classificacao(
                        int.Parse(columnsList[(int)ColumnClassificacaoIndex.POSICAO].Trim()),
                        ano,
                        columnsList[(int)ColumnClassificacaoIndex.TIME].Trim(),
                        columnsList[(int)ColumnClassificacaoIndex.ESTADO].Trim(),
                        int.Parse(columnsList[(int)ColumnClassificacaoIndex.PONTOS].Trim()),
                        int.Parse(columnsList[(int)ColumnClassificacaoIndex.JOGOS].Trim()),
                        int.Parse(columnsList[(int)ColumnClassificacaoIndex.VITORIAS].Trim()),
                        int.Parse(columnsList[(int)ColumnClassificacaoIndex.EMPATES].Trim()),
                        int.Parse(columnsList[(int)ColumnClassificacaoIndex.DERROTAS].Trim()),
                        int.Parse(columnsList[(int)ColumnClassificacaoIndex.GOLSPRO].Trim()),
                        int.Parse(columnsList[(int)ColumnClassificacaoIndex.GOLSCONTRA].Trim())
                        ));

                    }
                }
            }
            catch (Exception ex)
            {

                _domainNotificationContext.AddNotification(ex.AsNotification());
                _logger.LogError(0, ex, "Ocorreu erro crítico durante tentativa de alocação de dados de arquivo para memória");
            }

            return classificacaoList;
        }


    }
}
