using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfImprove.ViewModel
{
    /// <summary>
    /// 横向比较法分析
    /// </summary>
    public class HorizontalComparisonModel
    {
        /// <summary>
        /// BSC编号
        /// </summary>
        public string BSCBH { get; set; }

        /// <summary>
        /// BSC名称
        /// </summary>
        public string BSCMC { get; set; }

        /// <summary>
        /// CSF编号
        /// </summary>
        public string CSFBH { get; set; }

        /// <summary>
        /// CSF名称
        /// </summary>
        public string CSFMC { get; set; }

        /// <summary>
        /// KPI编号
        /// </summary>
        public string KPIBH { get; set; }

        /// <summary>
        /// KPI名称
        /// </summary>
        public string KPIMC { get; set; }

        /// <summary>
        /// 第一科室
        /// </summary>
        [DecimalPrecision]
        public decimal? DYKS { get; set; }

        /// <summary>
        /// 第二科室
        /// </summary>
        [DecimalPrecision]
        public decimal? DEKS { get; set; }

        /// <summary>
        /// 横向量化分
        /// </summary>
        [DecimalPrecision]
        public decimal? HXLHF { get; set; }
    }
}
