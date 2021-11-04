using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfStrategy.ViewModel
{
    public class BpeVa003Model
    { /// <summary>
      /// 主题编号    
      /// </summary>
        public string ZTBH { get; set; }

        /// <summary>
        /// 主题名称    
        /// </summary>
        public string ZTMC { get; set; }

        /// <summary>
        /// BSC编号    
        /// </summary>
        public string BSCBH { get; set; }


        /// <summary>
        /// BSC名称
        /// </summary>
        public string BSCMC { get; set; }


        /// <summary>
        /// 使命编号    
        /// </summary>
        public string SMBH { get; set; }

        /// <summary>
        /// 备注信息    
        /// </summary>
        public string REMARK { get; set; }

        /// <summary>
        /// 创建人    
        /// </summary>
        public string CREATOR { get; set; }

        /// <summary>
        /// 创建时间    
        /// </summary>
        public DateTime CREATEAT { get; set; }

        /// <summary>
        /// 修改人    
        /// </summary>
        public string MODIFOR { get; set; }

        /// <summary>
        /// 修改时间    
        /// </summary>
        public DateTime? MODIFYAT { get; set; }

        /// <summary>
        /// 状态    
        /// </summary>
        public string STATUS { get; set; }


        /// <summary>
        /// 年度
        /// </summary>
        public string JXND { get; set; }

        /// <summary>
        /// 绩效编码
        /// </summary>
        public string JXBM { get; set; }

        /// <summary>
        /// 战略总目标
        /// </summary>
        public string ZLZMB { get; set; }


    }
}
