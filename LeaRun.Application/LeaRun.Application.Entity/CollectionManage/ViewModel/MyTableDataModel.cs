using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.CollectionManage.ViewModel
{
    /// <summary>
    /// 采集表数据
    /// </summary>
    public class MyTableDataModel
    {
        /// <summary>
        /// 序号
        /// </summary>
        public string XH { get; set; }

        /// <summary>
        /// 列
        /// </summary>
        public string LCODE { get; set; }

        /// <summary>
        /// 行
        /// </summary>
        public string HCODE { get; set; }

        /// <summary>
        /// 存储值
        /// </summary>
        [DecimalPrecision]
        public decimal CCVALUE { get; set; }
    }
}
