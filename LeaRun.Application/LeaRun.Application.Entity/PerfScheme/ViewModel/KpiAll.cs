using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfScheme.ViewModel
{
    /// <summary>
    /// 所有指标+指标公式
    /// </summary>
    public class KpiAll
    {
        /// <summary>
        /// 指标表中的状态
        /// </summary>
        public string ZBSTATUS { get; set; }
        /// <summary>
        /// 指标表中的备注说明
        /// </summary>
        public string EXPLAIN { get; set; }
        /// <summary>
        /// 指标类别：0-定量，1-定性
        /// </summary>
        public string ZBLB { get; set; }
        /// <summary>
        /// KPI编号
        /// </summary>
        public string KPIBH { get; set; }
        /// <summary>
        /// 绩效年度编码
        /// </summary>
        public string JXBM { get; set; }
        /// <summary>
        /// 绩效年度
        /// </summary>
        public string JXND { get; set; }
        /// <summary>
        /// 指标编号
        /// </summary>
        public string ThirdZBBH { get; set; }
        /// <summary>
        /// 指标名称
        /// </summary>
        public string ThirdZBMC { get; set; }
        /// <summary>
        /// 二级指标编号
        /// </summary>
        public string SecZBBH { get; set; }
        /// <summary>
        /// 二级指标名称
        /// </summary>
        public string SecZBMC { get; set; }
        /// <summary>
        /// 一级指标编号
        /// </summary>
        public string FirstZBBH { get; set; }
        /// <summary>
        /// 一级指标名称
        /// </summary>
        public string FirstZBMC { get; set; }
        /// <summary>
        /// 指标极性
        /// </summary>		
        public string ZBJX { get; set; }
        /// <summary>
        /// 指标程度(0正/1负)
        /// </summary>		
        public string ZBCD { get; set; }
        /// <summary>
        /// 指标公式
        /// </summary>		
        public string ZBGS { get; set; }
        /// <summary>
        /// 指标公式描述
        /// </summary>		
        public string ZBGSMS { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string JLDW { get; set; }
        /// <summary>
        /// 公式表中的状态
        /// </summary>
        public string STATUS { get; set; }
        /// <summary>
        /// 公式表中的备注
        /// </summary>
        public string REMARK { get; set; }
        /// <summary>
        /// 目标设定
        /// </summary>
        public string ZBSDMD { get; set; }
        /// <summary>
        /// 方案的指标明细表中的主键：序号
        /// </summary>
        public string XH { get; set; }
        /// <summary>
        /// 方案编号
        /// </summary>
        public string FABH { get; set; }
    }
}