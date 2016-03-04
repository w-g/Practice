using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sediment.Excel
{
    public interface IExcelDocument
    {
        IExcelSheet this[int index] { get; }

        IExcelSheet CreateSheet(string name);
    }
}
