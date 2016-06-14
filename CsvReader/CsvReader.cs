using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CsvReader
{
    /// <summary>
    /// Класс для чтения текстовых файлов формата .CSV
    /// </summary>
    public class CsvReader : IDisposable
    {
        private Encoding _encoding;
        private FileInfo _file;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="file">Путь к файлов который нужно прочитать.</param>
        /// <param name="encoding">Кодировка файла.</param>
        public CsvReader(string file, Encoding encoding)
        {
            _file = new FileInfo(file);
            _encoding = encoding;
        }

        /// <summary>
        /// Загружаем данные из файла в специальные объекты.
        /// </summary>
        /// <param name="separator">Разделитель полей.</param>
        /// <returns>
        /// Множество кастомных объектов.
        /// </returns>
        public List<CsvRow> GetData(char separator)
        {
            var resultData = new List<CsvRow>();
            var lines = File.ReadAllLines(FilePath, _encoding);
            var headers = lines[0].Split(new [] { separator }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines.Skip(1))
            {
                var values = line.Split(';');
                var valuesLength = values.Length;
                var rowDictionary = new Dictionary<string, string>();
                for (var i = 0; i < valuesLength; i++)
                {
                    rowDictionary[headers[i]] = values[i];
                }
                resultData.Add(new CsvRow(rowDictionary));
            }
            return resultData;
        }

        /// <summary>
        /// Путь к файлу.
        /// </summary>
        public string FilePath => _file.FullName;

        /// <summary>
        /// Выполняет определяемые приложением задачи, связанные с высвобождением или сбросом неуправляемых ресурсов.
        /// </summary>
        public void Dispose()
        {
            _file = null;
            _encoding = null;
        }
    }
}
