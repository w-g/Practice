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
    public class ExcelRow : IExcelRow
    {
        public IExcelCell CreateCell(int columnNumber)
        {
            throw new NotImplementedException();
        }
    }
}
