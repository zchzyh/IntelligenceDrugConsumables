using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfReport
{
    /// <summary>
    /// 定性指标等级报告
    /// </summary>
    public partial class BpeRA002Entity : BaseEntity
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
        /// KPI名称
        /// </summary>
        public string KPIMC { get; set; }
        /// <summary>
        /// 是否发生(0否/1是)
        /// </summary>
        public string SFFS { get; set; }
        /// <summary>
        /// 描述内容
        /// </summary>
        public string BZ { get; set; }

        /// <summary>
        /// KPI量化分
        /// </summary>
        [DecimalPrecision]
        public decimal? KPILHF { get; set; }
        /// <summary>
        /// KPI等级
        /// </summary>
        public string KPIDJ { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CREATEAT { get; set; }
        /// <summary>
        /// 等级判定
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