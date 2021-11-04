using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfScheme.ViewModel
{
    /// <summary>
    /// 绩效方案权重设置
    /// </summary>
    public class PerfSchemeWeightModel
    {
        /// <summary>
        /// 年度
        /// </summary>
        public string SYND { get; set; }
        /// <summary>
        /// 方案编号
        /// </summary>
        public string FABH { get; set; }
        /// <summary>
        /// 方案名称
        /// </summary>
        public string FAMC { get; set; }
        /// <summary>
        /// 一级指标编号
        /// </summary>
        public string FirstZBBH { get; set; }
        /// <summary>
        /// 一级指标名称
        /// </summary>
        public string FirstZBMC { get; set; }
        /// <summary>
        /// 一级指标名称说明
        /// </summary>
        public string FirstExplain { get; set; }
        /// <summary>
        /// 二级指标编号
        /// </summary>
        public string SecZBBH { get; set; }
        /// <summary>
        /// 二级指标名称
        /// </summary>
        public string SecZBMC { get; set; }
        /// <summary>
        /// 二指标名称说明
        /// </summary>
        public string SecExplain { get; set; }
        /// <summary>
        /// 三级指标编号
        /// </summary>
        public string ThirdZBBH { get; set; }
        /// <summary>
        /// 三级指标名称
        /// </summary>
        public string ThirdZBMC { get; set; }
        /// <summary>
        /// 三级指标名称说明
        /// </summary>
        public string ThirdExplain { get; set; }
        /// <summary>
        /// 权重比值
        /// </summary>
        public int QZBZ { get; set; }
    }
}