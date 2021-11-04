using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollectionManage
{
    /// <summary>
    /// 年度采集表管理   
    /// </summary>
    public class BpcSp003Entity : BaseEntity
    {
        /// <summary>
        /// 序号    
        /// </summary>
        public string XH { get; set; }

        /// <summary>
        /// 采集表编码    
        /// </summary>
        public string CJBBM { get; set; }

        /// <summary>
        /// 年度    
        /// </summary>
        public string ND { get; set; }

        /// <summary>
        /// 备注    
        /// </summary>
        public string REMARK { get; set; }

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

        #region 扩展操作

        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.XH = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            this.CREATOR = OperatorProvider.Provider.Current().UserName;
            this.CREATEAT = DateTime.Now;
        }

        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyvalue"></param>
        public override void Modify(string keyvalue)
        {
            this.MODIFOR = OperatorProvider.Provider.Current().UserName;
            this.MODIFYAT = DateTime.Now;
        }

        #endregion
    }
}