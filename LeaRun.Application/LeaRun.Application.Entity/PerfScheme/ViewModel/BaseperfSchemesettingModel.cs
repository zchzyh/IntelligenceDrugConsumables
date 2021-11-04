using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfScheme.ViewModel
{
    /// <summary>
    /// 绩效方案设置
    /// </summary>
    public class BaseperfSchemesettingModel
    {
        #region 实体成员
        /// <summary>
        /// 单位方案编号
        /// </summary>
        public string FABH { get; set; }
        ///<summary>
        ///基础方案名称
        ///</summary>
        public string FAMC { get; set; }
        ///<summary>
        ///机构编码
        ///</summary>
        public string JGBM { get; set; }
        ///<summary>
        ///绩效编码
        ///</summary>
        public string JXBM { get; set; }
        ///<summary>
        ///绩效年度
        ///</summary>
        public string JXND { get; set; }
        ///<summary>
        ///
        ///</summary>
        public string REMARK { get; set; }
        ///<summary>
        ///创建人
        ///</summary>
        public string CREATOR { get; set; }
        ///<summary>
        ///创建时间
        ///</summary>
        public string CREATEAT { get; set; }
        ///<summary>
        ///修改人
        ///</summary>
        public string MODIFOR { get; set; }
        ///<summary>
        ///状态
        ///</summary>
        public string STATUS { get; set; }
        #endregion
    }
}
