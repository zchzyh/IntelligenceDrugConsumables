using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.CollectionManage.ViewModel
{
    /// <summary>
    /// 我的审核任务
    /// </summary>
    public class MyTaskAuditModel
    {
        /// <summary>
        /// 序号
        /// </summary>
        public string XH { get; set; }

        /// <summary>
        /// 任务编号
        /// </summary>
        public string RWBH { get; set; }

        /// <summary>
        /// 采集表编码
        /// </summary>
        public string CJBBM { get; set; }

        /// <summary>
        /// 采集表全名
        /// </summary>
        public string CJBQM { get; set; }

        /// <summary>
        /// 采集频率
        /// </summary>
        public string CJPL { get; set; }

        /// <summary>
        /// 采集频率名称
        /// </summary>
        public string CJPLNAME { get; set; }

        /// <summary>
        /// 科室代码
        /// </summary>
        public string OFFICECODE { get; set; }

        /// <summary>
        /// 科室名称
        /// </summary>
        public string OFFICENAME { get; set; }

        /// <summary>
        /// 年度
        /// </summary>
        public decimal ND { get; set; }

        /// <summary>
        /// 月度
        /// </summary>
        public decimal YD { get; set; }

        /// <summary>
        /// 任务开始时间
        /// </summary>
        public DateTime? KSSJ { get; set; }

        /// <summary>
        /// 任务截止时间
        /// </summary>
        public DateTime? JZSJ { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        public string USERID { get; set; }

        /// <summary>
        /// 个人姓名
        /// </summary>
        public string NAME { get; set; }

        /// <summary>
        /// 任务采集状态(0未采集/1已进行/2已采集)
        /// </summary>
        public string RWCD { get; set; }

        /// <summary>
        /// 申请状态(0未申请/1已退回/2已申请)
        /// </summary>
        public string SQZT { get; set; }

        /// <summary>
        /// 审核状态(0未审核/1未通过/2已通过)
        /// </summary>
        public string SHZT { get; set; }
    }
}
