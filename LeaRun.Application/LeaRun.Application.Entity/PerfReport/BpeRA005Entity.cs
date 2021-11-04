using LeaRun.Application.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfReport
{
    /// <summary>
    /// 
    /// </summary>
  public  class BpeRA005Entity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 序号
        /// </summary>
        public string serial_num { get; set; }
        /// <summary>
        /// 年度
        /// </summary>
        public string year_code { get; set; }
        /// <summary>
        /// 战略编码
        /// </summary>
        public string cs { get; set; }
        /// <summary>
        /// 维度编码
        /// </summary>
        public string cd { get; set; }
        /// <summary>
        /// 成功因素编号
        /// </summary>
        public string csf { get; set; }
        /// <summary>
        /// 评定内容
        /// </summary>
        public string assessment { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string creator { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createat { get; set; }
        /// <summary>
        ///修改人
        /// </summary>
        public string modifor { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? modifyat { get; set; }
        /// <summary>
        /// 状态(0删除/1正常)
        /// </summary>		
        public string status { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.serial_num = Guid.NewGuid().ToString().Replace("-", "");
            this.creator = OperatorProvider.Provider.Current().UserName;
            this.createat = DateTime.Now;
            this.status = "1";
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyvalue"></param>
        public override void Modify(string[] keyvalue)
        {
            this.serial_num = keyvalue[0];
            this.modifor = OperatorProvider.Provider.Current().UserName;
            this.modifyat = DateTime.Now;
        }
        #endregion
    }
}
