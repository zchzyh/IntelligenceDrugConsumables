using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollectionManage
{
    /// <summary>
    /// 采集基本信息表   
    /// </summary>
    public partial class BpcSp001Entity : BaseEntity
    {
        /// <summary>
        /// 采集表编码    
        /// </summary>
        public string CJBBM { get; set; }

        /// <summary>
        /// 采集表简称    
        /// </summary>
        public string CJBMC { get; set; }

        /// <summary>
        /// 采集表全名    
        /// </summary>
        public string CJBQM { get; set; }

        /// <summary>
        /// 采集频率    
        /// </summary>
        public string CJPL { get; set; }

        /// <summary>
        /// 采集方式    
        /// </summary>
        public string CJFS { get; set; }

        /// <summary>
        /// 所属类别    
        /// </summary>
        public string SSLB { get; set; }

        /// <summary>
        /// URL地址    
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// 是否必填    
        /// </summary>
        public string SFBT { get; set; }

        /// <summary>
        /// 排序    
        /// </summary>
        [DecimalPrecision]
        public decimal? PX { get; set; }

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

        /// <summary>
        /// 单位获取方式    
        /// </summary>
        public string DWFS { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public override void Create()
        {
            //this.CJBBM = DateTime.Now.ToString("yyyyMMddHHmmssfff");
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