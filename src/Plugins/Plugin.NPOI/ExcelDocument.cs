using NPOI.XSSF.UserModel;
using Sediment.Excel;
using System.IO;

namespace Plugin.NPOI
{
    public class ExcelDocument : IExcelDocument
    {
        private XSSFWorkbook _workbook;

        public ExcelDocument()
        {
            _workbook = new XSSFWorkbook();
        }

        public ExcelDocument(string path)
        {
            var stream = File.Open(path, FileMode.Open); // stream 占用的资源何时释放
            _workbook = new XSSFWorkbook(stream);
        }

        public IExcelSheet this[int index]
        {
            get
            {
                return new ExcelSheet(_workbook[index]);
            }
        }

        public IExcelSheet CreateSheet(string name)
        {
            return new ExcelSheet(_workbook.CreateSheet(name));
        }
    }
}
