using Excel;
using System.Data;
using System.IO;
using System.Text;

namespace BigDataSmartSolutions.Models
{
    public class ConversorDeArquivos
    {
        public static string ConverterArquivo(string pathFile)
        {
            var stream = new FileStream(pathFile, FileMode.Open);
            var excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            var dataSet = excelReader.AsDataSet();
            var pathFileCsv = Path.Combine(Path.GetDirectoryName(pathFile), "arquivo.csv");
            var arquivo = new StreamWriter(pathFileCsv, true, Encoding.ASCII);
            foreach (DataTable table in dataSet.Tables)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    for (int j = 0; j < table.Columns.Count; j++)
                        arquivo.Write(table.Rows[i].ItemArray[j] + ";");
                    arquivo.WriteLine();
                }
            }
            excelReader.Close();
            arquivo.Close();
            var conteudoArquivo = File.ReadAllText(pathFileCsv);
            File.Delete(pathFileCsv);
            return conteudoArquivo;
        }

    }
}