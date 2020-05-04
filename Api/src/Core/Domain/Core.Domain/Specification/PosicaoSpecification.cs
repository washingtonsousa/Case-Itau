using Core.Domain.Entities.Concrete.Database;
using Core.Shared.Kernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Specification
{
    public static class PosicaoSpecification
    {


        public static bool DadosNaoExistem(this IList<Posicao> posicoes, IAssertionConcern assertionConcern)
        {
            return !assertionConcern.IsSatisfiedBy(
                
                assertionConcern.AssertListLength(posicoes,1,"Lista de posicoes vazia ou não foram encontradas, você importou os dados?")
                
                );
        }

        public static bool TimeNaoEncontradoNasPosicoes(this IList<Posicao> posicoes, IAssertionConcern assertionConcern)
        {
            return !assertionConcern.IsSatisfiedBy(

                assertionConcern.AssertListLength(posicoes, 1, "Lista de posicoes vazia ou não foram encontradas para este time")

                );
        }


        public static bool ParametroVazioOuNulo(this string nomeTime, IAssertionConcern assertionConcern)
        {
            return !assertionConcern.IsSatisfiedBy(

                assertionConcern.AssertNotEmpty(nomeTime, "Parametro nao pode ser vazio ou nulo")

                );
        }

    }
}
