using Core.Domain.Entities.Concrete.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Interfaces.Concrete.Repository
{
    public interface IPosicaoRepository
    {

        Task<IList<Posicao>> ObterLista(string nomeTime = null);
        Task<Posicao> Obter(string nomeTime = null);

    }
}
