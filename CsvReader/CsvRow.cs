using System;
using System.Collections.Generic;
using System.Linq;

namespace CsvReader
{

    /// <summary>
    /// Объект кастомной строки.
    /// </summary>
    public class CsvRow
    {

        /// <summary>
        /// Конструтктор
        /// </summary>
        /// <param name="dictionary">Словарь для создания кастомной строки.</param>
        public CsvRow(Dictionary<string, string> dictionary)
        {
            Key = Guid.NewGuid();
            Cells = new List<CsvCell>();
            foreach (var item in dictionary)
            {
                Cells.Add(new CsvCell { Value = item.Value, Header = item.Key });
            }
        }

        /// <summary>
        /// Ячейки кастомной строки.
        /// </summary>
        public ICollection<CsvCell> Cells { get; set; }

        /// <summary>
        /// Уникальный ключ для строки.
        /// </summary>
        public Guid Key { get; set; }

        /// <summary>
        ///     Возвращает строку, представляющую текущий объект.
        /// </summary>
        /// <returns>
        ///     Строка, представляющая текущий объект.
        /// </returns>
        public override string ToString()
        {
            return string.Join(";", Cells.Select(x => $"{x.Header} - {x.Value}"));
        }
    }
}
