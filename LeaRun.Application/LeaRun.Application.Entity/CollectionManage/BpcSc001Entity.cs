using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollectionManage
{
	/// <summary>
	/// 行项目信息管理表
	/// </summary>
    [Serializable]
	public partial class BpcSc001Entity : BaseEntity
    {
        /// <summary>
        /// 横向编码    
        /// </summary>
        public string HXBM { get; set; }

        /// <summary>
        /// 横向名称    
        /// </summary>
        public string NAME { get; set; }

        /// <summary>
        /// 是否字典    
        /// </summary>
        public string SFZD { get; set; }

        /// <summary>
        /// 字典编码    
        /// </summary>
        public string HCODE { get; set; }

        /// <summary>
        /// 上级编码    
        /// </summary>
        public string PARENT { get; set; }

        /// <summary>
        /// 级别    
        /// </summary>
        public string GRADE { get; set; }

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


        public override void Create()
        {
            this.HXBM = DateTime.Now.ToString("yyyyMMddHHmmssfff");
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
