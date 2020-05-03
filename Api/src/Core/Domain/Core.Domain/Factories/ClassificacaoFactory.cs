using Core.Domain.Entities.Concrete.Files;
using Core.Domain.Facade;
using Core.Domain.Interfaces.Concrete.Factories;
using Core.Shared.Kernel.Abstractions;
using Core.Shared.Kernel.Events;
using Core.Shared.Kernel.Helpers;
using Core.Shared.Kernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Domain.Factories
{
    public class ClassificacaoFactory : IClassificacaoFactory
    {

        public ClassificacaoFactory(IDomainNotificationContext<DomainNotification> domainNotificationContext)
        {
            _domainNotificationContext = domainNotificationContext;
        }

        private IDomainNotificationContext<DomainNotification> _domainNotificationContext { get; }

        /// <summary>
        /// Executa um processo de extração de dados de um arquivo de texto em memória para o tipo Classificacao a partir de um arquivo
        /// formatado que obedeça as especificações de linha e coluna desenhados no documento do case
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Retorna uma lista de classificacoes, caso ocorra erro irá retornar uma lista vazia e adicionará uma notificação</returns>
        public IList<Classificacao> CreateClassificacaoListFromFile(string fileName)
        {
            IList<Classificacao> classificacaoList = new List<Classificacao>();

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
                        classificacaoList.Add(Classificacao.CriarClassificacaoPorLinha(ano, line));
                    }
                }
            }
            catch (Exception ex)
            {

                _domainNotificationContext.AddNotification(ex.AsNotification());
            }

            return classificacaoList;
        }  


    }
}
