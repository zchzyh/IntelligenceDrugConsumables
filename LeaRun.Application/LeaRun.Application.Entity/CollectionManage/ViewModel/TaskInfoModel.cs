using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.CollectionManage.ViewModel
{
    /// <summary>
    /// 采集任务生成
    /// </summary>
    public class TaskInfoModel
    {

        public string UserId { get; set; }

        /// <summary>
        /// 任务编号    
        /// </summary>
        public string RWBH { get; set; }

        /// <summary>
        /// 采集表编码    
        /// </summary>
        public string CJBBM { get; set; }

        /// <summary>
        /// 绩效年度编码    
        /// </summary>
        public string JXBM { get; set; }

        /// <summary>
        /// 年度    
        /// </summary>
        public decimal ND { get; set; }

        /// <summary>
        /// 月度    
        /// </summary>
        public decimal YD { get; set; }

        /// <summary>
        /// 填报单位    
        /// </summary>
        public string JGDM { get; set; }

        /// <summary>
        /// 任务开始时间    
        /// </summary>
        public DateTime? KSSJ { get; set; }

        /// <summary>
        /// 任务截止时间    
        /// </summary>
        public DateTime? JZSJ { get; set; }

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
        public DateTime CREATEAT { get; set; }

        /// <summary>
        /// 修改人    
        /// </summary>
        public string MODIFOR { get; set; }

        /// <summary>
        /// 修改时间    
        /// </summary>
        public DateTime? MODIFYAT { get; set; }

        /// <summary>
        /// 状态    
        /// </summary>
        public string STATUS { get; set; }

        /// <summary>
        /// 采集表名称
        /// </summary>
        public string CJBMC { get; set; }

        /// <summary>
        /// 采集频率
        /// </summary>
        public string CJPL { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DeptName { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

 
        /// <summary>
        /// 采集人
        /// </summary>
        public string TaskUserId { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public string AuditorId { get; set; }

        /// <summary>
        /// 采集频率名称
        /// </summary>
        public string CJPLMC { get; set; }
    }
}