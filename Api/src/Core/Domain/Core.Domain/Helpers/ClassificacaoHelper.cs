using Core.Domain.Entities.Concrete.Database;
using Core.Domain.Entities.Concrete.Files;
using Core.Domain.Enums;
using Core.Shared.Kernel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Domain.Helpers
{
    public static class ClassificacaoHelper
    {

        /// <summary>
        /// Corrige eventuais problemas nos nomes de times por conta da separação inicial por espaço em branco
        /// Caso o número de colunas seja maior que a requerida são unificadas as colunas a mais após a coluna do indexador aonde se inicia o nome do time
        /// </summary>
        /// <param name="strArr"></param>
        /// <returns>Uma Lista de string a partir de um array de string</returns>
        public static IList<string> PrepararColunaTimeParaClassificacao(this string[] strArr)
        {
            int classificacaoColumnsNumber = 10;
            int strArrColumnsNumber = strArr.AsQueryable().Count();
            var queryFromArr = strArr.AsQueryable().ToList();
            string nomeTime = queryFromArr[(int)ColumnClassificacaoIndex.TIME];

            if (strArrColumnsNumber > classificacaoColumnsNumber)
            {
                int columnsNumberDiference = strArrColumnsNumber - classificacaoColumnsNumber;
                nomeTime += $@" {string.Join(" ", queryFromArr.Skip((int)ColumnClassificacaoIndex.TIME + 1).Take(columnsNumberDiference))}";                
                queryFromArr.RemoveRange(((int)ColumnClassificacaoIndex.TIME + 1), columnsNumberDiference);
            }

            queryFromArr[(int)ColumnClassificacaoIndex.TIME] = nomeTime.ToUpper().RemoveSpecialChars();
            return queryFromArr;

        }

        /// <summary>
        /// Cria uma lista de Estados a partir de uma lista de classificacoes
        /// </summary>
        /// <param name="classificacao"></param>
        /// <returns></returns>
        public static IList<Estado> AsEstados(this IList<Classificacao> classificacao) => classificacao.GroupBy(c => c.Estado)
                .Select(c => new Estado(c.Key)).ToList();
      

        /// <summary>
        /// Cria uma lista de Times a partir de uma lista de classificacoes filtradas pelo estado
        /// </summary>
        /// <param name="classificacao"></param>
        /// <returns></returns>
        public static IList<Time> AsTimesPorEstado(this IList<Classificacao> classificacao, string uF) => classificacao.Where(c => c.Estado == uF).GroupBy(c => c.Time)
                .Select(c => new Time(c.Key)).ToList();
        

        /// <summary>
        /// Cria uma lista de Campeonatos a partir de uma lista de classificacoes
        /// </summary>
        /// <param name="classificacao"></param>
        /// <returns></returns>
        public static IList<Campeonato> AsCampeonatos(this IList<Classificacao> classificacao) => classificacao.GroupBy(c => c.Ano)
                .Select(c => new Campeonato(c.Key)).ToList();
        

    }
}
