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
    public class SystemParameterEntity:BaseEntity
    {
        /// <summary>
        /// 无    
        /// </summary>
        public decimal ID { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string Par_Code { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string Par_Name { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string Par_Coment { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string Par_Value_Key { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string Par_Value_Defult_Value { get; set; }

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