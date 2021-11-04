using LeaRun.Application.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfConfig
{
    /// <summary>
    /// 定量指标库信息
    /// </summary>
    public class BpeTA002Entity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// KPI编号
        /// </summary>
        public string KPIBH { get; set; }
        /// <summary>
        /// 年度绩效编码
        /// </summary>		
        public string JXBM { get; set; }
        /// <summary>
        /// 指标编号
        /// </summary>	
        public string ZBBH { get; set; }
        /// <summary>
        /// 指标极性
        /// </summary>		
        public string ZBJX { get; set; }
        /// <summary>
        /// 指标程度
        /// </summary>		
        public string ZBCD { get; set; }
        /// <summary>
        /// 指标公式包含的元数据列表
        /// </summary>
        public string METCODELIST { get; set; }
        /// <summary>
        /// 指标公式
        /// </summary>		
        public string ZBGS { get; set; }
        /// <summary>
        /// 指标公式描述
        /// </summary>		
        public string ZBGSMS { get; set; }
        /// <summary>
        /// 指标设定目的
        /// </summary>
        public string ZBSDMD { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string JLDW { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        public string REMARK { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CREATOR { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>		
        public DateTime? CREATEAT { get; set; }
        /// <summary>
        /// 最后修改人
        /// </summary>		
        public string MODIFOR { get; set; }
        /// <summary>
        /// 最后修改日期
        /// </summary>
        public DateTime? MODIFYAT { get; set; }
        /// <summary>
        /// 状态(0删除/1正常)
        /// </summary>		
        public string STATUS { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.KPIBH = Guid.NewGuid().ToString().Replace("-", "");
            this.CREATOR = OperatorProvider.Provider.Current().UserName;
            this.CREATEAT = DateTime.Now;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyvalue"></param>
        public override void Modify(string keyvalue)
        {
            this.KPIBH = keyvalue;
            this.MODIFOR = OperatorProvider.Provider.Current().UserName;
            this.MODIFYAT = DateTime.Now;
        }
        #endregion
    }
}