using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfGoal.ViewModel
{
    /// <summary>
    /// 定量指标目标值审核
    /// </summary>
    public class QuantitativeGoalAuditModel
    {
        /// <summary>
        /// 单位方案编号
        /// </summary>
        public string JGFABH { get; set; }
        /// <summary>
        /// 单位方案名称
        /// </summary>
        public string JGFAMC { get; set; }
        /// <summary>
        /// 年度绩效编码
        /// </summary>		
        public string JXBM { get; set; }
        /// <summary>
        /// 绩效年度
        /// </summary>
        public string JXND { get; set; }
        /// <summary>
        /// 科室编码
        /// </summary>
        public string ORGCODE { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        public string MANAGERORGNAME { get; set; }
        /// <summary>
        /// 审核备注
        /// </summary>
        public string REMARK { get; set; }
        /// <summary>
        /// 审核状态(0未审核/1已审核/2审核退回)
        /// </summary>
        public string STATUS { get; set; }
    }
}