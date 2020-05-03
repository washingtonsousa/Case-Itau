using Core.Domain.Entities.Concrete.Database;
using Core.Domain.Entities.Concrete.Files;
using Core.Domain.Queries;
using Core.Shared.Kernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Domain.Specification
{
    public static class ImportacaoDeDadosSpecification
    {

        public static bool Validar(this IList<Classificacao> classificacoes, IAssertionConcern assertionConcern)
        {
            return assertionConcern.IsSatisfiedBy(

                assertionConcern.AssertListLength(classificacoes, 1, "Não foram encontradas classificacoes para importar")

                );
        }

        public static bool JaFoiImportado(this IList<Classificacao> classificacoes, IList<Campeonato> campeonatos, IAssertionConcern assertionConcern)
        {
            return !assertionConcern.IsSatisfiedBy(

                assertionConcern.AssertTrue(classificacoes?.Where(c => campeonatos.Any(cp => cp.Ano == c.Ano)).Count() == campeonatos?.Count(), "Dados já foram importados")

                );
        }
    }
}
