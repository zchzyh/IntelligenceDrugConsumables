using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfConfig.ViewModel
{
    /// <summary>
    /// 绩效定量指标设置
    /// </summary>
    public class JxQuantitativeIndicatorsModel
    {
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
        /// 状态
        /// </summary>
        public string STATUS { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string REMARK { get; set; }
        /// <summary>
        /// 目标设定
        /// </summary>
        public string ZBSDMD { get; set; }
    }
}