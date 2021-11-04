using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.CollectionManage
{
    /// <summary>
    /// 采集任务参数表 
    /// </summary>
    public class BpcSp008Entity : BaseEntity
    {
        /// <summary>
        /// 采集表编码    
        /// </summary>
        public string CJBBM { get; set; }

        /// <summary>
        /// 单位生成类型    
        /// </summary>
        public string DWSCLX { get; set; }

        /// <summary>
        /// 单位生成编码    
        /// </summary>
        public string DWCSBM { get; set; }

        /// <summary>
        /// 医疗机构ID
        /// </summary>
        public string OrgId { get; set; }
    }
}