using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestReader
{

    /// <summary>
    /// Тестовый класс прверки ридера.
    /// </summary>
    [TestClass]
    public class TestCsvReader
    {

        /// <summary>
        /// Тест чтения данных из файла .Csv;
        /// </summary>
        [TestMethod]
        public void Read()
        {
            using (var reader = new CsvReader.CsvReader("Data.csv", Encoding.Default))
            {
                var data = reader.GetData(';');
                Assert.AreEqual(4, data.Count);
            }
        }
    }
}
