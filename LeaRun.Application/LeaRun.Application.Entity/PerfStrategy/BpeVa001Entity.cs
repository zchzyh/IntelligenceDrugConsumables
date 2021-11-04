using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.PerfStrategy
{
    /// <summary>
    /// 使命远景信息表
    /// </summary>
    public class BpeVa001Entity : BaseEntity
    {
        /// <summary>
        /// 使命编号    
        /// </summary>
        public string SMBH { get; set; }

        /// <summary>
        /// 使命陈述    
        /// </summary>
        public string SMCS { get; set; }

        /// <summary>
        /// 远景陈述    
        /// </summary>
        public string YJCS { get; set; }

        /// <summary>
        /// 价值观陈述    
        /// </summary>
        public string JZGCS { get; set; }

        /// <summary>
        /// 战略总目标    
        /// </summary>
        public string ZLZMB { get; set; }

        /// <summary>
        /// 绩效编码    
        /// </summary>
        public string JXBM { get; set; }

        /// <summary>
        /// 备注信息    
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

        public override void Create()
        {
            this.SMBH = Guid.NewGuid().ToString().Replace("-","");// DateTime.Now.ToString("yyyyMMddHHmmssfff");
            this.CREATOR = OperatorProvider.Provider.Current().UserName;
            this.CREATEAT = DateTime.Now;
            this.STATUS = "1";
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