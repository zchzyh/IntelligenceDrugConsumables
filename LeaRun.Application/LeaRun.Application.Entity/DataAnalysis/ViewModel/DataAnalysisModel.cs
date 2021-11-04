using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.DataAnalysis.ViewModel
{
    /// <summary>
    /// 数据分析
    /// </summary>
    public class DataAnalysisModel
    {
        /// <summary>
        /// 序号
        /// </summary>
        public string XH { get; set; }
        /// <summary>
        /// 年度
        /// </summary>
        public decimal ND { get; set; }
        /// <summary>
        /// 月度
        /// </summary>
        public decimal YD { get; set; }
        /// <summary>
        /// 元数据名称
        /// </summary>
        public string METNAME { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        public string Department { get; set; }
        /// <summary>
        /// 数据单位
        /// </summary>
        public string UNITNAME { get; set; }
        /// <summary>
        /// 本期数
        /// </summary>
        [DecimalPrecision]
        public decimal? CurrentPeriodData { get; set; }
        /// <summary>
        /// 上期数
        /// </summary>
        [DecimalPrecision]
        public decimal? LastPeriodData { get; set; }
        /// <summary>
        /// 增长率
        /// </summary>
        [DecimalPrecision]
        public decimal? GrowthRate { get; set; }
        /// <summary>
        /// 本年累计数
        /// </summary>
        [DecimalPrecision]
        public decimal? YearData { get; set; }
        /// <summary>
        /// 本期年占比
        /// </summary>
        [DecimalPrecision]
        public decimal? YearPercent { get; set; }
    }
}