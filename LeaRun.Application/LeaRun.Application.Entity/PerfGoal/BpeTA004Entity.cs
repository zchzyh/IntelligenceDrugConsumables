using LeaRun.Application.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfGoal
{
    /// <summary>
    /// 定量指标目标值
    /// </summary>
    public class BpeTA004Entity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 序号
        /// </summary>	
        public string XH { get; set; }
        /// <summary>
        /// 年度绩效编码
        /// </summary>		
        public string JXBM { get; set; }
        /// <summary>
        /// 单位方案编号
        /// </summary>
        public string JGFABH { get; set; }
        /// <summary>
        /// BSC编号
        /// </summary>
        public string BSCBH { get; set; }
        /// <summary>
        /// BSC名称
        /// </summary>
        public string BSCMC { get; set; }
        /// <summary>
        /// CSF编号
        /// </summary>
        public string CSFBH { get; set; }
        /// <summary>
        /// CSF名称
        /// </summary>
        public string CSFMC { get; set; }
        /// <summary>
        /// KPI编号
        /// </summary>
        public string KPIBH { get; set; }
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
        /// <summary>
        /// 创建人
        /// </summary>		
        public string CREATOR { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>		
        public DateTime? CREATEAT { get; set; }
        /// <summary>
        /// 最后修改人
        /// </summary>		
        public string MODIFOR { get; set; }
        /// <summary>
        /// 最后修改日期
        /// </summary>
        public DateTime? MODIFYAT { get; set; }
        /// <summary>
        /// 状态(0删除/1正常)
        /// </summary>		
        public string STATUS { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.XH = Guid.NewGuid().ToString().Replace("-", "");
            this.CREATOR = OperatorProvider.Provider.Current().UserName;
            this.CREATEAT = DateTime.Now;
            this.STATUS = "1";
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyvalue"></param>
        public override void Modify(string keyvalue)
        {
            this.XH = keyvalue;
            this.MODIFOR = OperatorProvider.Provider.Current().UserName;
            this.MODIFYAT = DateTime.Now;
        }
        #endregion
    }
}