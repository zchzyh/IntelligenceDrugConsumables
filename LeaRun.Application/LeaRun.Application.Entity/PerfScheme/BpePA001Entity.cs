using LeaRun.Application.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfScheme
{
    /// <summary>
    /// 基础方案信息表
    /// </summary>
    public class BpePA001Entity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 方案编号
        /// </summary>
        public string FABH { get; set; }
        /// <summary>
        /// 方案名称
        /// </summary>
        public string FAMC { get; set; }
        /// <summary>
        /// 适用年度
        /// </summary>
        public string SYND { get; set; }
        /// <summary>
        /// 适用对象
        /// </summary>
        public string SYDX { get; set; }
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
        /// 创建日期
        /// </summary>
        public DateTime? CREATEAT { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string MODIFOR { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? MODIFYAT { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string STATUS { get; set; }

        #endregion 实体成员

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            //this.FABH = Guid.NewGuid().ToString().Replace("-", "");
            this.CREATOR = OperatorProvider.Provider.Current().UserName;
            this.CREATEAT = DateTime.Now;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyvalue"></param>
        public override void Modify(string keyvalue)
        {
            this.FABH = keyvalue;
            this.MODIFOR = OperatorProvider.Provider.Current().UserName;
            this.MODIFYAT = DateTime.Now;
        }
        #endregion
    }
}
