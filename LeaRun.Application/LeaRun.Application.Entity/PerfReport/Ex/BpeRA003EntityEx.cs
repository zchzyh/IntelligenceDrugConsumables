using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfReport
{
    public partial class BpeRA003Entity
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
        /// 是否一票表决显示名称
        /// </summary>
        [NotMapped]
        public string SFYPFJMC { get; set; }
        

    }
}
