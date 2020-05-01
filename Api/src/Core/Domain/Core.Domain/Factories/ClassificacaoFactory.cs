using Core.Domain.Entities.Concrete.Files;
using Core.Domain.Facade;
using Core.Domain.Interfaces.Concrete.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Domain.Factories
{
    public class ClassificacaoFactory : IClassificacaoFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public IList<Classificacao> CreateClassificacaoListFromFile(string fileName)
        {
            var strList = FileReaderFacade.GetStringListFromFile(fileName);

            IList<Classificacao> classificacaoList = new List<Classificacao>();

            int campeonatosNumber = strList.Count / 22;

            for (int index = 0; index < campeonatosNumber; index++)
            {

                int currentSkipIndex = (index == 0) ? 0 : index * 22;
                var currentTimesList = strList.Skip(currentSkipIndex + 2).Take(20);
                int currentAno = int.Parse(strList.Skip(currentSkipIndex).FirstOrDefault());

                foreach (string line in currentTimesList)
                {
                    classificacaoList.Add(Classificacao.GenerateClassificacaoFromStringTextLine(currentAno, line));
                }

            }

            return classificacaoList;
        }  


    }
}
