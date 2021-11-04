using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollectionManage
{
    /// <summary>
    /// 实体 采集表列项目管理表
    /// </summary>
    [Serializable]
    public partial class BpcSc003Entity : BaseEntity
    {
        /// <summary>
        /// 序号    
        /// </summary>
        public string XH { get; set; }

        /// <summary>
        /// 绩效年度#JXND    
        /// </summary>
        public string ND { get; set; }

        /// <summary>
        /// 采集表编码#CJBBM    
        /// </summary>
        public string CJBBM { get; set; }

        /// <summary>
        /// 列编码#LBM    
        /// </summary>
        public string LBM { get; set; }

        /// <summary>
        /// 列名称    
        /// </summary>
        public string LMC { get; set; }

        /// <summary>
        /// 字典编码    
        /// </summary>
        public string LCODE { get; set; }

        /// <summary>
        /// 是否可编辑#EDITABLE    
        /// </summary>
        public string EDITABLE { get; set; }

        /// <summary>
        /// 自动宽度#AUTOWIDTH    
        /// </summary>
        public string AUTOWIDTH { get; set; }

        /// <summary>
        /// 宽度#WIDTH    
        /// </summary>
        [DecimalPrecision]
        public decimal? WIDTH { get; set; }

        /// <summary>
        /// 数据类型#TYEP    
        /// </summary>
        public string TYPE { get; set; }

        /// <summary>
        /// 内容布局方式#TEXTALIGN    
        /// </summary>
        public string TEXTALIGN { get; set; }

        /// <summary>
        /// 格式化参数#FORMATSTR    
        /// </summary>
        public string FORMATSTR { get; set; }

        /// <summary>
        /// 是否合并#ISMERGE    
        /// </summary>
        public string ISMERGE { get; set; }

        /// <summary>
        /// 是否显示#VISIBLE    
        /// </summary>
        public string VISIBLE { get; set; }

        /// <summary>
        /// 排序#INDEXNUM    
        /// </summary>
        [DecimalPrecision]
        public decimal? INDEXNUM { get; set; }

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
            this.XH = DateTime.Now.ToString("yyyyMMddHHmmssfff");
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