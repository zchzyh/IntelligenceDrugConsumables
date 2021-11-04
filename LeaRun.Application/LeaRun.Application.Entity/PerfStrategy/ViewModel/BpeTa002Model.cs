using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfStrategy.ViewModel
{
  public  class BpeTa002Model
    {  /// <summary>
        /// KPI编号    
        /// </summary>
        public string KPIBH { get; set; }

        /// <summary>
        /// 绩效年度编码    
        /// </summary>
        public string JXBM { get; set; }

        /// <summary>
        /// 指标编号    
        /// </summary>
        public string ZBBH { get; set; }
        /// <summary>
        /// 指标名称
        /// </summary>
        public string ZBMC { get; set; }
        /// <summary>
        /// 指标极性(0正/1负)    
        /// </summary>
        public string ZBJX { get; set; }

        /// <summary>
        /// 指标程度    
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
        /// 指标设定目的    
        /// </summary>
        public string ZBSDMD { get; set; }

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
        /// 无    
        /// </summary>
        public string JLDW { get; set; }
    }
}
