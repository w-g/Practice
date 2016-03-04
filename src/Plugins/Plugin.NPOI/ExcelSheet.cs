using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Sediment.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.NPOI
{
    public class ExcelSheet : IExcelSheet
    {
        private ISheet _sheet;

        public ExcelSheet(ISheet sheet)
        {
            _sheet = sheet;
        }

        public IExcelSheet CreateSheet(string name)
        {
            throw new NotImplementedException();
        }

        public IExcelRow CreateRow(int rowNumber)
        {
            throw new NotImplementedException();
        }
    }
}
