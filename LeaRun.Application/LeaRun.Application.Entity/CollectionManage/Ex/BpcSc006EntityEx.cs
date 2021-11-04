using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.CollectionManage
{
    /// <summary>
    /// 
    /// </summary>
    public partial class BpcSc006Entity
    {
        /// <summary>
        /// 采集表名称
        /// </summary>
        [NotMapped]
        public string CJBMC { get; set; }
    }
}