using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfReport
{
    public partial class BpeRA002Entity
    { 
        /// <summary>
        /// 年度
        /// </summary>
        [NotMapped]
        public string Year { get; set; }

        /// <summary>
        /// 科室名称
        /// </summary>
        [NotMapped]
        public string OfficeName { get; set; }

        /// <summary>
        /// 战略主题
        /// </summary>
        [NotMapped]
        public string ZTMC { get; set; }
    }
}
