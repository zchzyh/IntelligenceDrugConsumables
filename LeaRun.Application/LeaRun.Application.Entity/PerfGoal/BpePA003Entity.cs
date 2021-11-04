using LeaRun.Application.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfGoal
{
    /// <summary>
    /// 单位方案信息
    /// </summary>
    public class BpePA003Entity : BaseEntity
    {
        #region 实体成员
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
        /// 方案编号
        /// </summary>
        public string FABH { get; set; }
        /// <summary>
        /// 绩效编号
        /// </summary>
        public string JXBM { get; set; }
        /// <summary>
        /// 审核备注
        /// </summary>
        public string REMARK { get; set; }
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
        /// 状态(0未审核/1未审核/2审核退回)
        /// </summary>		
        public string STATUS { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.JGFABH = Guid.NewGuid().ToString().Replace("-", "");
            this.CREATOR = OperatorProvider.Provider.Current().UserName;
            this.CREATEAT = DateTime.Now;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyvalue"></param>
        public override void Modify(string keyvalue)
        {
            this.JGFABH = keyvalue;
            this.MODIFOR = OperatorProvider.Provider.Current().UserName;
            this.MODIFYAT = DateTime.Now;
        }
        #endregion
    }
}