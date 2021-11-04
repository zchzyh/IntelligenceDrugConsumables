using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfScheme.ViewModel
{
    /// <summary>
    /// 单位绩效评价设置
    /// </summary>
    public class PerfDeptSchemeAppraisedataModel
    {
        /// <summary>
        /// 部门方案编号
        /// </summary>
        public string JGFABH { get; set; }
        /// <summary>
        /// 部门方案名称
        /// </summary>
        public string JGFAMC { get; set; }
        /// <summary>
        /// 年度
        /// </summary>
        public string SYND { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string Department { get; set; }
        /// <summary>
        /// 评价方法编号
        /// </summary>
        public string PJFFBH { get; set; }
        /// <summary>
        /// 评价方法名称
        /// </summary>
        public string PJFFMC { get; set; }
        /// <summary>
        /// 服务状态
        /// </summary>
        public string FWZT { get; set; }
        /// <summary>
        /// 是否可编辑
        /// </summary>
        public bool IsEnable { get; set; }
    }
}