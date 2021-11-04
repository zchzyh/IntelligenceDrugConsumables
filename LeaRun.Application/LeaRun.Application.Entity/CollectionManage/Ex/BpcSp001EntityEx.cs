using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace LeaRun.Application.Entity.CollectionManage
{
    /// <summary>
    /// 采集基本信息表
    /// </summary> 
    public partial class BpcSp001Entity
    {
        /// <summary>
        /// 所属类别名称
        /// </summary>
        [NotMapped]
        public string SSLBMC { get; set; }

        /// <summary>
        /// 采集频率名称
        /// </summary>
        [NotMapped]
        public string CJPLMC { get; set; }
    }
}