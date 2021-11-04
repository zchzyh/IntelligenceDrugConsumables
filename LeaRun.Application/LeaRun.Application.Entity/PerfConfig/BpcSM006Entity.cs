using LeaRun.Application.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfConfig
{
    /// <summary>
    /// 分析器基本信息
    /// </summary>
    public class BpcSM006Entity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 分析器编码
        /// </summary>	
        public string FXQBM { get; set; }
        /// <summary>
        /// 分析器名称
        /// </summary>		
        public string FXQMC { get; set; }
        /// <summary>
        /// 分析器注解
        /// </summary>		
        public string FXQZJ { get; set; }
        /// <summary>
        /// 分析器语句
        /// </summary>		
        public string FXQSQL { get; set; }
        /// <summary>
        /// 分析器类型(0元数据分析器/1数据项分析器)
        /// </summary>		
        public string FXQLX { get; set; }
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
        /// 状态
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
        /// <param name="keyvalue"></param>
        public override void Modify(string keyvalue)
        {
            this.FXQBM = keyvalue;
            this.MODIFOR = OperatorProvider.Provider.Current().UserName;
            this.MODIFYAT = DateTime.Now;
        }
        #endregion
    }
}