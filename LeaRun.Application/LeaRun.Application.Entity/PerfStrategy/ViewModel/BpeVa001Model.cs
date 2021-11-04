using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfStrategy.ViewModel
{ 
  public class BpeVa001Model
  {
      /// <summary>
      /// 使命编号    
      /// </summary>
      public string SMBH { get; set; }

      /// <summary>
      /// 使命陈述    
      /// </summary>
      public string SMCS { get; set; }

      /// <summary>
      /// 远景陈述    
      /// </summary>
      public string YJCS { get; set; }

      /// <summary>
      /// 价值观陈述    
      /// </summary>
      public string JZGCS { get; set; }

      /// <summary>
      /// 战略总目标    
      /// </summary>
      public string ZLZMB { get; set; }

      /// <summary>
      /// 绩效编码    
      /// </summary>
      public string JXBM { get; set; }

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
        /// 绩效年度
        /// </summary>
      public string Year { get; set; }

  }
}
