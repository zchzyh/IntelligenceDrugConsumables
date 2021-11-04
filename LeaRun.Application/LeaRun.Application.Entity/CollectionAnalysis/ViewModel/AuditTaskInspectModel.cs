using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.CollectionAnalysis.ViewModel
{
    /// <summary>
    /// 审核任务督查
    /// </summary>
    public class AuditTaskInspectModel
    {
        /// <summary>
        /// 审核员
        /// </summary>
        public string NAME { get; set; }
        /// <summary>
        /// 年度
        /// </summary>
        public decimal ND { get; set; }
        /// <summary>
        /// 月度
        /// </summary>
        public decimal YD { get; set; }
        /// <summary>
        /// 采集表数量
        /// </summary>
        public int CjbCount { get; set; }
        /// <summary>
        /// 任务总数量
        /// </summary>
        public int RwCount { get; set; }
        /// <summary>
        /// 未申请任务数
        /// </summary>
        public int Sq0Count { get; set; }
        /// <summary>
        /// 已退回任务数
        /// </summary>
        public int Sq1Count { get; set; }
        /// <summary>
        /// 已申请任务数
        /// </summary>
        public int Sq2Count { get; set; }
        /// <summary>
        /// 未审核任务数
        /// </summary>
        public int Sh0Count { get; set; }
        /// <summary>
        /// 未通过审核任务数
        /// </summary>
        public int Sh1Count { get; set; }
        /// <summary>
        /// 已通过审核任务数
        /// </summary>
        public int Sh2Count { get; set; }
    }
}