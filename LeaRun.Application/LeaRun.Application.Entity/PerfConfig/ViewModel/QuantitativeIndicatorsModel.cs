using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfConfig.ViewModel
{
    /// <summary>
    /// 定量指标设置
    /// </summary>
    public class QuantitativeIndicatorsModel
    {
        /// <summary>
        /// 指标编号
        /// </summary>
        public string ZBBH { get; set; }
        /// <summary>
        /// 年度绩效编码
        /// </summary>
        public string JXBM { get; set; }
        /// <summary>
        /// 绩效年度
        /// </summary>
        public string JXND { get; set; }
        /// <summary>
        /// 指标名称
        /// </summary>
        public string ZBMC { get; set; }
        /// <summary>
        /// 父级指标
        /// </summary>
        public string FJZB { get; set; }
        /// <summary>
        /// 指标级别
        /// </summary>		
        public string ZBJB { get; set; }
        /// <summary>
        /// 状态(0删除/1正常)
        /// </summary>		
        public string STATUS { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string EXPLAIN { get; set; }
    }
}