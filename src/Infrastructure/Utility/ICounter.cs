using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sediment.Common
{
    interface ICounter
    {
        long Number { get; }

        long Increase();

        long Decrease();
    }

    class CounterFactory
    {
        static ICounter CreateCounter()
        {
            throw new NotImplementedException();
        }
    }
}
