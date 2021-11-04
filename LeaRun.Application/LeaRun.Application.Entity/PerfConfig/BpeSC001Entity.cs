using LeaRun.Application.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfConfig
{
    /// <summary>
    /// 绩效年度配置
    /// </summary>
    public class BpeSC001Entity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 序号
        /// </summary>	
        public string JXBM { get; set; }
        /// <summary>
        /// 绩效区域
        /// </summary>		
        public string JXQY { get; set; }
        /// <summary>
        /// 绩效年度
        /// </summary>		
        public string JXND { get; set; }
        /// <summary>
        /// 有效起始时间
        /// </summary>		
        public DateTime? KSSJ { get; set; }
        /// <summary>
        /// 有效截止时间
        /// </summary>		
        public DateTime? JZSJ { get; set; }
        /// <summary>
        /// 服务状态(0正常绩效/1历年绩效)
        /// </summary>		
        public string FWZT { get; set; }
        /// <summary>
        /// 运行状态(0未启动/1已启动)
        /// </summary>		
        public string YXZT { get; set; }
        /// <summary>
        /// 备注
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
            this.JXBM = Guid.NewGuid().ToString().Replace("-", "");
            this.YXZT = "0";
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
            this.JXBM = keyvalue;
            this.MODIFOR = OperatorProvider.Provider.Current().UserName;
            this.MODIFYAT = DateTime.Now;
        }
        #endregion
    }
}