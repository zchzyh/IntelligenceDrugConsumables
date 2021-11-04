using LeaRun.Application.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.CollectionManage
{

    /// <summary>
    /// 任务信息管理表
    /// </summary>
    public class BpcSp002Entity : BaseEntity
    {
        /// <summary>
        /// 任务编号    
        /// </summary>
        public string RWBH { get; set; }

        /// <summary>
        /// 采集表编码    
        /// </summary>
        public string CJBBM { get; set; }

        /// <summary>
        /// 绩效年度编码    
        /// </summary>
        public string JXBM { get; set; }

        /// <summary>
        /// 年度    
        /// </summary>
        public decimal ND { get; set; }

        /// <summary>
        /// 月度    
        /// </summary>
        public decimal YD { get; set; }

        /// <summary>
        /// 填报单位    
        /// </summary>
        public string JGDM { get; set; }

        /// <summary>
        /// 任务开始时间    
        /// </summary>
        public DateTime? KSSJ { get; set; }

        /// <summary>
        /// 任务截止时间    
        /// </summary>
        public DateTime? JZSJ { get; set; }

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

        public override void Create()
        {
            //年度+月度+表名+“-”+填报单位
            this.RWBH = $"{ND.ToString() + YD.ToString() + CJBBM.Substring(CJBBM.Length >= 5 ? CJBBM.Length - 5 : 0) + "-" + JGDM}";// "T"+DateTime.Now.ToString("yyyyMMddHHmmssfff");
            this.CREATOR = OperatorProvider.Provider.Current().UserName;
            this.CREATEAT = DateTime.Now;
        }

        /// <inheritdoc />
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyvalue"></param>
        public override void Modify(string keyvalue)
        {
            this.MODIFOR = OperatorProvider.Provider.Current().UserName;
            this.MODIFYAT = DateTime.Now;
        }

    }

}
