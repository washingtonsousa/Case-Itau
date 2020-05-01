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
        /// 
        /// </summary>
        /// <param name="strArr"></param>
        /// <returns></returns>
        public static IList<string> PrepareTimeColumnForClassificacao(this string[] strArr)
        {
            int classificacaoColumnsNumber = 10;
            int strArrColumnsNumber = strArr.AsQueryable().Count();
            var queryFromArr = strArr.AsQueryable().ToList();
            string nomeTime = queryFromArr[(int)ColumnClassificacaoIndex.TIME]; 

            if (strArrColumnsNumber > classificacaoColumnsNumber)
            {
                int columnsNumberDiference = strArrColumnsNumber - classificacaoColumnsNumber;
                nomeTime += string.Join(" ", queryFromArr.Skip((int)ColumnClassificacaoIndex.TIME + 1).Take(columnsNumberDiference));
                
                queryFromArr.RemoveRange(((int)ColumnClassificacaoIndex.TIME + 1), columnsNumberDiference);
            }

            queryFromArr[(int)ColumnClassificacaoIndex.TIME] = nomeTime.ToUpper().RemoveSpecialChars();
            return queryFromArr;

        }

    }
}
