using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfStrategy.ViewModel
{
    public class BpeTa003Model
    {
        /// <summary>
        /// 序号    
        /// </summary>
        public string XH { get; set; }

        /// <summary>
        /// KPI编号    
        /// </summary>
        public string KPIBH { get; set; }

        /// <summary>
        /// CSF编号    
        /// </summary>
        public string CSFBH { get; set; }

        /// <summary>
        /// 关键成功因素名称
        /// </summary>
        public string CSFMC { get; set; }


        /// <summary>
        /// 指标编号
        /// </summary>
        public string ZBBH { get; set; }

        /// <summary>
        /// 指标名称
        /// </summary>
        public string ZBMC { get; set; }

        /// <summary>
        /// 维度名称
        /// </summary>
        public string BSCMC { get; set; }

        /// <summary>
        /// 主题名称
        /// </summary>
        public string ZTMC { get; set; }


        /// <summary>
        /// 绩效编码    
        /// </summary>
        public string JXBM { get; set; }

        /// <summary>
        /// 绩效年度
        /// </summary>
        public string JXND { get; set; }


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
    }
}