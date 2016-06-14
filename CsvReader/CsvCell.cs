using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvReader
{

    /// <summary>
    /// Ячейка которая содержит значение из поля файла, в строковом представлении.
    /// </summary>
    public class CsvCell
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public CsvCell()
        {

        }

        /// <summary>
        /// Строковое представление значения.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Заголовок колонки.
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Возвращает строку, представляющую текущий объект.
        /// </summary>
        /// <returns>
        /// Строка, представляющая текущий объект.
        /// </returns>
        public override string ToString()
        {
            return $"{Header} - {Value}";
        }
    }
}
