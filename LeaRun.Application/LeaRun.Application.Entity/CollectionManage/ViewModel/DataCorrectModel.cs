using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.CollectionManage.ViewModel
{
    /// <summary>
    /// 保存系数修正法
    /// </summary>
    public class DataCorrectModel
    {
        /// <summary>
        /// 序号
        /// </summary>
        public string XH { get; set; }

        /// <summary>
        /// 系数值
        /// </summary>
        [DecimalPrecision]
        public decimal XSVALUE { get; set; }

        /// <summary>
        /// 补录值
        /// </summary>
        [DecimalPrecision]
        public decimal BLVALUE { get; set; }

        /// <summary>
        /// 实际值
        /// </summary>
        [DecimalPrecision]
        public decimal? SJVALUE { get; set; }
    }
}
