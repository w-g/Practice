using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sediment.IoC
{
    public interface ISearcherFactory<T>
    {
        ISearcher<T> CreateSearcher();
    }
}
