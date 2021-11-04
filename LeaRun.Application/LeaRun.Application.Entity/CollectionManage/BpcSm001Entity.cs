/******************************************
* 模块名称：实体 数据项基本信息表
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
	/// 实体 数据项基本信息表
	/// </summary>
	[Description("Primary:JCSJBM")]
    [Serializable]
	public partial class BpcSm001Entity : BaseEntity
    {
        #region 构造函数
        /// <summary>
        /// 实体 数据项基本信息表
        /// </summary>
        public BpcSm001Entity(){}
        #endregion

        #region 私有变量
        private string _jcsjbm = null;
        private string _jcsjmc = null;
        private string _jldw = null;
        private string _yxpl = null;
        private decimal _tjxs =0;
        private string _typeid = null;
        private string _cjbbm = null;
        private decimal _px = 0;
        private string _remark = null;
        private string _creator = null;
        private DateTime? _createat;
        private string _modifor = null;
        private DateTime? _modifyat ;
        private string _status = null;
        private string _fxqbm = null;
        #endregion

        #region 公共属性
        /// <summary>
        /// 主键 基础数据编码(NOT NULL)
        /// </summary>
        public string JCSJBM
        {
            set{ _jcsjbm=value;}
            get{return _jcsjbm;}
        }
        /// <summary>
        /// 基础数据名称(NOT NULL)
        /// </summary>
        public string JCSJMC
        {
            set{ _jcsjmc=value;}
            get{return _jcsjmc;}
        }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string JLDW
        {
            set{ _jldw=value;}
            get{return _jldw;}
        }
        /// <summary>
        /// 运行频率
        /// </summary>
        public string YXPL
        {
            set{ _yxpl=value;}
            get{return _yxpl;}
        }
        /// <summary>
        /// 调节系数
        /// </summary>
        public decimal TJXS
        {
            set{ _tjxs=value;}
            get{return _tjxs;}
        }
        /// <summary>
        /// 分类编码
        /// </summary>
        public string TYPEID
        {
            set{ _typeid=value;}
            get{return _typeid;}
        }
        /// <summary>
        /// 表单编码
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
        /// 创建人(NOT NULL)
        /// </summary>
        public string CREATOR
        {
            set{ _creator=value;}
            get{return _creator;}
        }
        /// <summary>
        /// 创建时间(NOT NULL)
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
        /// 状态(NOT NULL)
        /// </summary>
        public string STATUS
        {
            set{ _status=value;}
            get{return _status;}
        }
        /// <summary>
        /// 分析器编码
        /// </summary>
        public string FXQBM
        {
            set{ _fxqbm=value;}
            get{return _fxqbm;}
        }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.JCSJBM = DateTime.Now.ToString("yyyyMMddHHmmssfff");
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
