using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sediment.Counter
{
    /* 为什么要将计数服务独立于各业务模块之外
     * 是有必要的，但我忘记了曾遇到的那个具体业务场景
     */

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
