using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sediment.Excel
{
    public interface IExcelRow
    {
        IExcelCell CreateCell(int columnNumber);

    }
}
