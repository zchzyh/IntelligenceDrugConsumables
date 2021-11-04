/******************************************
* 模块名称：实体 采集纵向关系表
* 当前版本：1.0
* 开发人员：Administrator
* 生成时间：2020/2/17 星期一
* 版本历史：此代码由 VB/C#.Net实体代码生成工具(EntitysCodeGenerate 4.8) 自动生成。
* 
******************************************/
using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollectionManage
{
	/// <summary>
	/// 实体 采集纵向关系表
	/// </summary>
	[Description("Primary:XH")]
    [Serializable]
	public partial class BpcSc002Entity : BaseEntity
    {
        #region 构造函数
        /// <summary>
        /// 实体 采集纵向关系表
        /// </summary>
        public BpcSc002Entity(){}
        #endregion

        #region 私有变量
        private string _xh = null;
        private string _nd = null;
        private string _hxbm = null;
        private string _cjbbm = null;
        private decimal _px = 0;
        private string _remark = null;
        private string _creator = null;
        private DateTime? _createat;
        private string _modifor = null;
        private DateTime? _modifyat;
        private string _status = null;
        #endregion

        #region 公共属性
        /// <summary>
        /// 主键 序号(NOT NULL)
        /// </summary>
        public string XH
        {
            set{ _xh=value;}
            get{return _xh;}
        }
        /// <summary>
        /// 年度(NOT NULL)
        /// </summary>
        public string ND
        {
            set{ _nd=value;}
            get{return _nd;}
        }
        /// <summary>
        /// 横向编码(NOT NULL)
        /// </summary>
        public string HXBM
        {
            set{ _hxbm=value;}
            get{return _hxbm;}
        }
        /// <summary>
        /// 采集表编码(NOT NULL)
        /// </summary>
        public string CJBBM
        {
            set{ _cjbbm=value;}
            get{return _cjbbm;}
        }
        /// <summary>
        /// 排序
        /// </summary>
        public decimal PX
        {
            set{ _px=value;}
            get{return _px;}
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string REMARK
        {
            set{ _remark=value;}
            get{return _remark;}
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CREATOR
        {
            set{ _creator=value;}
            get{return _creator;}
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CREATEAT
        {
            set{ _createat=value;}
            get{return _createat;}
        }
        /// <summary>
        /// 修改人
        /// </summary>
        public string MODIFOR
        {
            set{ _modifor=value;}
            get{return _modifor;}
        }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? MODIFYAT
        {
            set{ _modifyat=value;}
            get{return _modifyat;}
        }
        /// <summary>
        /// 状态
        /// </summary>
        public string STATUS
        {
            set{ _status=value;}
            get{return _status;}
        }
        #endregion

        public override void Create()
        {
            this.XH = DateTime.Now.ToString("yyyyMMddHHmmssfff");
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
