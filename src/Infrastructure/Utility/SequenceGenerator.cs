using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sediment.Common.Utility
{
    public class IdGenerator
    {
        public static long Next()
        {
            // 生成的序列长度
            int length = 10;

            // 用于计算偏移量的参考日期
            DateTime reference = new DateTime(2000, 10, 1);

            // 自参考日期的分钟偏移量
            // 将来并发量大导致瓶颈时，可考虑级别更高的偏移量（秒或毫秒），并增加Id长度
            long offset = (DateTime.Now.Ticks / 600000000) - (reference.Ticks / 600000000);

            // 使用随机数补全位数
            var randomLength = length - offset.ToString().Length;

            int randomMin = 1 * (int)Math.Pow(10, randomLength - 1);
            int randomMax = 1 * (int)Math.Pow(10, randomLength) - 1;

            Random random = new Random();
            var suffix = random.Next(randomMin, randomMax);

            long result = offset * (long)Math.Pow(10, randomLength) + suffix;

            return result;
        }   
    }
}
