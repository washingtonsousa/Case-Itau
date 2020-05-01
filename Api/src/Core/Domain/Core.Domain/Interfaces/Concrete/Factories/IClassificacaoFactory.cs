using Core.Domain.Entities.Concrete.Files;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Interfaces.Concrete.Factories
{
    public interface IClassificacaoFactory
    {
        IList<Classificacao> CreateClassificacaoListFromFile(string fileName);
    }
}
