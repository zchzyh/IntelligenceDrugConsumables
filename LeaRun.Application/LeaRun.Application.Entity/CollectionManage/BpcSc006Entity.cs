using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollectionManage
{
    /// <summary>
    ///  采集表逻辑配置   
    /// </summary>
    public partial class BpcSc006Entity : BaseEntity
    {
        /// <summary>
        /// 无    
        /// </summary>
        public string YWGZ { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public DateTime? CREATEAT { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string STATUS { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string XH { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string MODIFOR { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string REMARK { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string CREATOR { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string CJBBM { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public DateTime? MODIFYAT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public override void Create()
        {
            this.XH = Guid.NewGuid().ToString().Replace("-", "");// DateTime.Now.ToString("yyyyMMddHHmmssfff");
            this.CREATOR = OperatorProvider.Provider.Current().UserName;
            this.CREATEAT = DateTime.Now;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.MODIFOR = OperatorProvider.Provider.Current().UserName;
            this.MODIFYAT = DateTime.Now;
        }
    }
}