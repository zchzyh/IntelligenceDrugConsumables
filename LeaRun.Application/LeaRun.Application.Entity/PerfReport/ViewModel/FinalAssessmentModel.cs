using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfReport.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
  public  class FinalAssessmentModel
    {
        /// <summary>
        /// 序号
        /// </summary>
        public string serial_num { get; set; }
        /// <summary>
        /// 年度编码
        /// </summary>
        public string year_code { get; set; }
        /// <summary>
        /// 年度
        /// </summary>
        public string year { get; set; }
        /// <summary>
        /// 战略名称
        /// </summary>
        public string sname { get; set; }
        /// <summary>
        /// 维度名称
        /// </summary>
        public string dname { get; set; }
        /// <summary>
        /// 成功因素
        /// </summary>
        public  string sfname { get; set; }
        /// <summary>
        /// 评定内容
        /// </summary>
        public string assessment { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string status { get; set; }
    }
}
