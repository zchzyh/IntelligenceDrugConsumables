using LeaRun.Application.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.CollectionManage
{
    /// <summary>
    /// 采集日常监控表
    /// </summary>
    public class BpcSP006Entity : BaseEntity
    {
        #region 实体成员

        /// <summary>
        /// 序号
        /// </summary>
        public string XH { get; set; }

        /// <summary>
        /// 任务编号
        /// </summary>
        public string RWBH { get; set; }

        /// <summary>
        /// 任务采集人
        /// </summary>
        public string USERID { get; set; }

        /// <summary>
        /// 任务采集时间
        /// </summary>
        public DateTime RWSJ { get; set; }

        /// <summary>
        /// 任务采集状态(0未采集/1已采集/2已进行)
        /// </summary>
        public string RWCD { get; set; }

        /// <summary>
        /// 申请状态(0未提交/1已申请/2已退回)
        /// </summary>
        public string SQZT { get; set; }
        
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime? SQSJ { get; set; }

        /// <summary>
        /// 申请人员
        /// </summary>
        public string SQR { get; set; }

        /// <summary>
        /// 审核状态(0未审核/1已通过/2未通过)
        /// </summary>
        public string SHZT { get; set; }
        
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? SHSJ { get; set; }

        /// <summary>
        /// 审核人员
        /// </summary>
        public string SHR { get; set; }

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
        /// 状态(0删除/1正常)
        /// </summary>
        public string STATUS { get; set; }

        #endregion


        #region 扩展操作
        /// <summary>
        /// 
        /// </summary>
        public override void Create()
        {
            this.XH = Guid.NewGuid().ToString().Replace("-", "");// DateTime.Now.ToString("yyyyMMddHHmmssfff");
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
            this.XH = keyValue;
            this.MODIFOR = OperatorProvider.Provider.Current().UserName;
            this.MODIFYAT = DateTime.Now;
        }


        #endregion
    }
}
