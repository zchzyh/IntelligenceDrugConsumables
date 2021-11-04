using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfImprove.ViewModel
{
    /// <summary>
    /// 目标比较法分析
    /// </summary>
    public class TargetComparisonModel
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
        /// KPI目标值
        /// </summary>
        [DecimalPrecision]
        public decimal? KPIMBZ { get; set; }

        /// <summary>
        /// KPI实际值
        /// </summary>
        [DecimalPrecision]
        public decimal? KPISJZ { get; set; }

        /// <summary>
        /// KPI量化分
        /// </summary>
        [DecimalPrecision]
        public decimal? KPILHF { get; set; }
    }
}
