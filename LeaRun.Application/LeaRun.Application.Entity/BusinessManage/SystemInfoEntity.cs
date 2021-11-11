using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.BusinessManage
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SystemInfoEntity:BaseEntity
    {
        /// <summary>
        /// 无    
        /// </summary>
        public string Sys_Code { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string Sys_Name { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string Sys_Comment { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public DateTime? Sys_BigenDate { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public DateTime? Sys_EndDate { get; set; }

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            //this.CREATOR = OperatorProvider.Provider.Current().UserName;
            //this.CREATEAT = DateTime.Now;
            //this.STATUS = "1";
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyvalue"></param>
        public override void Modify(string keyvalue)
        {
            //this.JCSJBM = keyvalue;
            //this.MODIFOR = OperatorProvider.Provider.Current().UserName;
            //this.MODIFYAT = DateTime.Now;
        }
        #endregion
    }
}
