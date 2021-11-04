using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfConfig
{
    /// <summary>
    /// 
    /// </summary>
    public partial class BpcSM001Entity
    {

        /// <summary>
        /// 二级分类ID
        /// </summary>
        [NotMapped]
        public string FirstCategoryId { get; set; }
        /// <summary>
        /// 一级分类名称
        /// </summary>
        [NotMapped]
        public string FirstCategory { get; set; }


        /// <summary>
        /// 二级分类ID
        /// </summary>
        [NotMapped]
        public string SecondCategoryId { get; set; }

        /// <summary>
        /// 二级分类名称
        /// </summary>
        [NotMapped]
        public string SecondCategory { get; set; }

        /// <summary>
        /// 运行频率名称
        /// </summary>
        [NotMapped]
        public string YxplName { get; set; }

        /// <summary>
        /// 计算单位名称
        /// </summary>
        [NotMapped]
        public string JldwName { get; set; }
    }
}
