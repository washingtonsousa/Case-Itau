using Core.Shared.Kernel.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Core.Domain.Facade
{
    public static class FileReaderFacade
    {

        public static StreamReader GetStreamReaderFromAppDataDirectory(string fileName)
        {
            string absoluteFilePath =  $@"{ Environment.CurrentDirectory}/AppData/{fileName}";
            return new StreamReader(absoluteFilePath, Encoding.UTF8);
        }

        /// <summary>
        /// Gera uma lista de string por meio de um arquivo de texto localizado na pasta AppData
        /// </summary>
        /// <param name="fileName">Nome do arquivo</param>
        /// <param name="columnSeparator">Separador de coluna</param>
        /// <returns></returns>
        public static IList<string> ObterListaDeStringPorArquivoDeTexto(string fileName, string columnSeparator = ";")
        {
            IList<string> stringList = new List<string>();

            using (var reader = GetStreamReaderFromAppDataDirectory(fileName))
            {
                string line = string.Empty;

                while (!reader.EndOfStream)
                {

                    line = reader.ReadLine();
                    line = FormatLineColumns(line, columnSeparator);

                    if (!string.IsNullOrEmpty(line) && !string.IsNullOrWhiteSpace(line))
                        stringList.Add(line);
                }

            }

            return stringList;
        }

        /// <summary>
        /// Formata cada linha e insere um separador para cada coluna removendo colunas vazias ou nulas
        /// </summary>
        /// <param name="line">linha em formato string</param>
        /// <param name="separator">separador</param>
        /// <returns></returns>
        private static string FormatLineColumns(string line, string separator = ";")
        {
            line = line.Replace("\t", " ");
            var columns = line.Split(" ")
                            .AsEnumerable()
                            .Where(c => !string.IsNullOrEmpty(c.Trim()));

            line = string.Join(separator, columns);

            return line;
        }

    }
}
