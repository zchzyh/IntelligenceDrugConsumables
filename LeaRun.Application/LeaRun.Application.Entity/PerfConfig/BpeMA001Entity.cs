using LeaRun.Application.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfConfig
{
    /// <summary>
    /// 元数据库基本表
    /// </summary>
    public class BpeMA001Entity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 绩效年度
        /// </summary>	
        public string JXND { get; set; }
        /// <summary>
        /// 元数据编码
        /// </summary>		
        public string METCODE { get; set; }
        /// <summary>
        /// 元数据名称
        /// </summary>		
        public string METNAME { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>		
        public string UNIT { get; set; }
        /// <summary>
        /// 运行频率
        /// </summary>		
        public string RUNFRE { get; set; }
        /// <summary>
        /// 统计规则
        /// </summary>
        public string TJGZ { get; set; }
        /// <summary>
        /// 分类编码
        /// </summary>
        public string TYPEID { get; set; }
        /// <summary>
        /// 分析器编码
        /// </summary>
        public string FXQBM { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public decimal? PX { get; set; }
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
            this.CREATOR = OperatorProvider.Provider.Current().UserName;
            this.CREATEAT = DateTime.Now;
            this.STATUS = "1";
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyvalues"></param>
        public override void Modify(string[] keyvalues)
        {
            this.JXND = keyvalues[0];
            this.METCODE = keyvalues[1];
            this.MODIFOR = OperatorProvider.Provider.Current().UserName;
            this.MODIFYAT = DateTime.Now;
        }
        #endregion
    }
}