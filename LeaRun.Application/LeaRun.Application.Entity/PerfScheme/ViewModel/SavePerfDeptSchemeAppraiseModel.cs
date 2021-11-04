using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfScheme.ViewModel
{
    /// <summary>
    /// 用于保存时的部门方案评价设置模型
    /// </summary>
    public class SavePerfDeptSchemeAppraiseModel
    {
        /// <summary>
        /// 部门方案编号    
        /// </summary>
        public string JGFABH { get; set; }

        /// <summary>
        /// 评价方法编号    
        /// </summary>
        public string PJFFBH { get; set; }
    }
}
