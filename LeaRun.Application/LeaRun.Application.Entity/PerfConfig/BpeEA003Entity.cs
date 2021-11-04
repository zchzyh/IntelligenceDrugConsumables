using LeaRun.Application.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfConfig
{
    /// <summary>
    /// 评价方法信息表
    /// </summary>
    public class BpeEA003Entity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 评价方法编号
        /// </summary>
        public string PJFFBH { get; set; }
        /// <summary>
        /// 评价方法名称
        /// </summary>
        public string PJFFMC { get; set; }
        /// <summary>
        /// 评价方法规则
        /// </summary>
        public string PJFFGZ { get; set; }
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
            this.PJFFBH = keyvalues[0];
            this.MODIFOR = OperatorProvider.Provider.Current().UserName;
            this.MODIFYAT = DateTime.Now;
        }
        #endregion    
    }
}
