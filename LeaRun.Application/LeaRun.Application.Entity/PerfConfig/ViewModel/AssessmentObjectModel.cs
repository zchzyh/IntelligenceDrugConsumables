using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfConfig.ViewModel
{
    /// <summary>
    /// 考核对象
    /// </summary>
    public class AssessmentObjectModel
    {
        /// <summary>
        /// 序号
        /// </summary>	
        public string XH { get; set; }
        /// <summary>
        /// 年度绩效编码
        /// </summary>
        public string JXBM { get; set; }
        /// <summary>
        /// 机构编码
        /// </summary>
        public string ORGCODE { get; set; }
        /// <summary>
        /// 总院（医疗机构）
        /// </summary>
        public string PARENTORG { get; set; }
        /// <summary>
        /// 机构名称
        /// </summary>		
        public string MANAGERORGNAME { get; set; }
        /// <summary>
        /// 机构名称简称
        /// </summary>		
        public string SHORTNAME { get; set; }
        /// <summary>
        /// 科室ID
        /// </summary>
        public string DEPTID { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        public string DEPTNAME { get; set; }
    }
}