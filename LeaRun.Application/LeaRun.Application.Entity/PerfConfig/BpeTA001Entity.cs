using LeaRun.Application.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfConfig
{
    /// <summary>
    /// 指标库基本信息
    /// </summary>
    public class BpeTA001Entity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 指标编号
        /// </summary>	
        public string ZBBH { get; set; }
        /// <summary>
        /// 年度绩效编码
        /// </summary>		
        public string JXBM { get; set; }
        /// <summary>
        /// 指标名称
        /// </summary>		
        public string ZBMC { get; set; }
        /// <summary>
        /// 父级指标
        /// </summary>		
        public string FJZB { get; set; }
        /// <summary>
        /// 指标级别
        /// </summary>		
        public string ZBJB { get; set; }
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
        /// <summary>
        /// 备注
        /// </summary>
        public string EXPLAIN { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.CREATOR = OperatorProvider.Provider.Current().UserName;
            this.CREATEAT = DateTime.Now;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyvalues"></param>
        public override void Modify(string[] keyvalues)
        {
            this.ZBBH = keyvalues[0];
            this.JXBM = keyvalues[1];
            this.MODIFOR = OperatorProvider.Provider.Current().UserName;
            this.MODIFYAT = DateTime.Now;
        }
        #endregion
    }
}