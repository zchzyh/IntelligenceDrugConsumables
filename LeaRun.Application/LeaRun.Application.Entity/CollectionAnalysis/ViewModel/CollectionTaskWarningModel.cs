using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.CollectionAnalysis.ViewModel
{
    /// <summary>
    /// 采集任务预警
    /// </summary>
    public class CollectionTaskWarningModel
    {
        /// <summary>
        /// 任务人
        /// </summary>
        public string NAME { get; set; }
        /// <summary>
        /// 任务内容
        /// </summary>
        public string CJBQM { get; set; }
        /// <summary>
        /// 年度
        /// </summary>
        public decimal ND { get; set; }
        /// <summary>
        /// 月度
        /// </summary>
        public decimal YD { get; set; }
        /// <summary>
        /// 预计开始时间
        /// </summary>
        public DateTime? KSSJ { get; set; }
        /// <summary>
        /// 预计结束时间
        /// </summary>
        public DateTime? JZSJ { get; set; }
        /// <summary>
        /// 倒计天数
        /// </summary>
        public int Days { get; set; }
    }
}