using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfReport.ViewModel
{
   public class SchemeWeightModel
    {

        /// <summary>
        /// 绩效编码
        /// </summary>
        public string JXBM { get; set; }

        /// <summary>
        /// 年度
        /// </summary>
        public string ND { get; set; }


        public string OfficeName { get; set; }
        
        /// <summary>
        /// 单位编号
        /// </summary>
        public string JGBM { get; set; }

        /// <summary>
        /// 单位方案编号
        /// </summary>
        public string JGFABH { get; set; }

        /// <summary>
        /// 单位方案名称
        /// </summary>
        public string JGFAMC { get; set; }
        
        /// <summary>
        /// 方案编号
        /// </summary>
        public string FABH { get; set; }


        /// <summary>
        /// 一级指标名称
        /// </summary>
        public string FirstZBMC { get; set; }
        /// <summary>
        /// 一级指标
        /// </summary>
        public string FirstZBBH { get; set; }


        /// <summary>
        /// 二级指标名称
        /// </summary>
        public string SecZBMC { get; set; }

        /// <summary>
        /// 二级指标
        /// </summary>
        public string SecZBBH { get; set; }

        /// <summary>
        /// 三级指标名称
        /// </summary>
        public string ThirdZBMC { get; set; }
        

        /// <summary>
        /// 指标级别
        /// </summary>
        public string Level { get; set; }
        
        /// <summary>
        /// 得分
        /// </summary>
        public decimal Score { get; set; }

        /// <summary>
        /// 权重比值
        /// </summary>
        public decimal QZBZ { get; set; }
        

    }
}
