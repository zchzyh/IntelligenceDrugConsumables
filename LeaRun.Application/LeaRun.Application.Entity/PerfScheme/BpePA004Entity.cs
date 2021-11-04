using LeaRun.Application.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfScheme
{
    /// <summary>
    /// 科室绩效明细表
    /// </summary>
    public class BpePA004Entity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 序号    
        /// </summary>
        public string XH { get; set; }

        /// <summary>
        /// 单位方案编号    
        /// </summary>
        public string JGFABH { get; set; }

        /// <summary>
        /// KPI编号    
        /// </summary>
        public string KPIBH { get; set; }

        /// <summary>
        /// 指标类型    
        /// </summary>
        public string ZBLX { get; set; }

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
