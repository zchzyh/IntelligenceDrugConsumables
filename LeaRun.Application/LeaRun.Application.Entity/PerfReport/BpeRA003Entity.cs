using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfReport
{
    /// <summary>
    /// 综合评价等级报告
    /// </summary>
    public partial class BpeRA003Entity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 序号
        /// </summary>
        public string XH { get; set; }
        /// <summary>
        /// 绩效编号
        /// </summary>
        public string JXBM { get; set; }
        /// <summary>
        /// 单位方案编号
        /// </summary>
        public string JGFABH { get; set; }
        /// <summary>
        /// 单位方案名称
        /// </summary>
        public string JGFAMC { get; set; }
        /// <summary>
        /// 单位编号
        /// </summary>
        public string JGBM { get; set; }
        /// <summary>
        /// 等级名称
        /// </summary>
        public string DJMC { get; set; }
        /// <summary>
        /// 等级个数
        /// </summary>
        [DecimalPrecision]
        public decimal? DJGS { get; set; }
        /// <summary>
        /// 占总指标数百分比
        /// </summary>
        [DecimalPrecision]
        public decimal? ZSBFB { get; set; }
        /// <summary>
        /// 是否存在一票否决(0否/1是)
        /// </summary>
        public string SFYPFJ { get; set; }
        /// <summary>
        /// 综合考核等级
        /// </summary>
        public string ZHKHDJ { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        public string REMARK { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CREATEAT { get; set; }
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
        }
        #endregion
    }
}