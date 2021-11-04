using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfGoal.ViewModel
{
    /// <summary>
    /// 定量指标目标值
    /// </summary>
    public class QuantitativeGoalModel
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
        /// 绩效年度
        /// </summary>
        public string JXND { get; set; }
        /// <summary>
        /// 单位方案编号
        /// </summary>
        public string JGFABH { get; set; }
        /// <summary>
        /// 单位方案名称
        /// </summary>
        public string JGFAMC { get; set; }
        /// <summary>
        /// 科室编码
        /// </summary>
        public string ORGCODE { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        public string MANAGERORGNAME { get; set; }
        /// <summary>
        /// 关键成功因素编号
        /// </summary>
        public string CSFBH { get; set; }
        /// <summary>
        /// 关键成功因素名称
        /// </summary>
        public string CSFMC { get; set; }
        /// <summary>
        /// 维度编号
        /// </summary>
        public string BSCBH { get; set; }
        /// <summary>
        /// 维度名称
        /// </summary>
        public string BSCMC { get; set; }
        /// <summary>
        /// KPI编号
        /// </summary>
        public string KPIBH { get; set; }
        /// <summary>
        /// 一级指标编号
        /// </summary>
        public string FirstZBBH { get; set; }
        /// <summary>
        /// 一级指标名称
        /// </summary>
        public string FirstZBMC { get; set; }
        /// <summary>
        /// 二级指标编号
        /// </summary>
        public string SecZBBH { get; set; }
        /// <summary>
        /// 二级指标名称
        /// </summary>
        public string SecZBMC { get; set; }
        /// <summary>
        /// 三级指标编号
        /// </summary>
        public string ThirdZBBH { get; set; }
        /// <summary>
        /// 三级指标名称
        /// </summary>
        public string ThirdZBMC { get; set; }
        /// <summary>
        /// 合格目标值
        /// </summary>
        [DecimalPrecision]
        public decimal? HGMBZ { get; set; }
        /// <summary>
        /// 优秀目标值
        /// </summary>
        [DecimalPrecision]
        public decimal? YXMBZ { get; set; }
        /// <summary>
        /// 优良目标值
        /// </summary>
        [DecimalPrecision]
        public decimal? YLMBZ { get; set; }
        /// <summary>
        /// 标杆目标值
        /// </summary>
        [DecimalPrecision]
        public decimal? BGMBZ { get; set; }
        /// <summary>
        /// 参考值1
        /// </summary>
        [DecimalPrecision]
        public decimal? CKZ1 { get; set; }
        /// <summary>
        /// 参考值2
        /// </summary>
        [DecimalPrecision]
        public decimal? CKZ2 { get; set; }
        /// <summary>
        /// 参考值3
        /// </summary>
        [DecimalPrecision]
        public decimal? CKZ3 { get; set; }
        /// <summary>
        /// 目标优化比率
        /// </summary>
        [DecimalPrecision]
        public decimal? MBYHL { get; set; }
        /// <summary>
        /// 申请状态(0未申请/1已申请)
        /// </summary>
        public int SQZT { get; set; }
    }
}