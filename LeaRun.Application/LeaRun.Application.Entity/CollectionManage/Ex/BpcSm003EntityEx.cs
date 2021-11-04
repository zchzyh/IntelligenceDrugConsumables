using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.CollectionManage
{
    public partial class BpcSm003Entity
    {
        /// <summary>
        /// 频率名称
        /// </summary>
        [NotMapped]
        public string PLMC { get; set; }
    }
}
