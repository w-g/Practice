using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sediment.Common.Module
{
    class OperationLog
    {
        // 根据5W2H分析法得来的设计

        public long Id { get; set; }

        // WHO
        public string Username { get; set; }

        // WHAT
        public string Url { get; set; }

        //public string Action { get; set; }

        //public string Controller { get; set; }

        // HOW
        public string Arguments { get; set; }

        // WHERE
        public string IP { get; set; }

        // WHEN
        public DateTime CreateDate { get; set; }

        // WHY 是分析数据的结果

        // HOW MUCH 是数据统计的结果
    }
}
