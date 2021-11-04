using LeaRun.Application.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfConfig
{
    /// <summary>
    /// 指标等级信息表
    /// </summary>
    public class BpeEA001Entity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 序号    
        /// </summary>
        public string XH { get; set; }

        /// <summary>
        /// 年度    
        /// </summary>
        public string YEAR { get; set; }

        /// <summary>
        /// 等级名称    
        /// </summary>
        public string DJMC { get; set; }

        /// <summary>
        /// 分值下限    
        /// </summary>
        [DecimalPrecision]
        public decimal? FZXX { get; set; }

        /// <summary>
        /// 分值上限    
        /// </summary>
        [DecimalPrecision]
        public decimal? FZSX { get; set; }

        /// <summary>
        /// 创建人    
        /// </summary>
        public string CREATOR { get; set; }

        /// <summary>
        /// 创建时间    
        /// </summary>
        public DateTime? CREATEAT { get; set; }

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

        #endregion 实体成员

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.CREATOR = OperatorProvider.Provider.Current().UserName;
            this.CREATEAT = DateTime.Now;
            this.STATUS = "1";
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyvalues"></param>
        public override void Modify(string[] keyvalues)
        {
            this.XH = keyvalues[0];
            this.MODIFOR = OperatorProvider.Provider.Current().UserName;
            this.MODIFYAT = DateTime.Now;
        }
        #endregion    
    }
}
