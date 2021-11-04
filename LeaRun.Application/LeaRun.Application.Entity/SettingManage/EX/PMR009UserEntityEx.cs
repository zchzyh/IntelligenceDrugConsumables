using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.SettingManage
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PMR009UserEntity
    {
        /// <summary>
        /// 性别
        /// </summary>
        [NotMapped]
        public string SEXNAME { get; set; }

        /// <summary>
        ///岗位
        /// </summary>
        [NotMapped]
        public string POSTNAME { get; set; }
    }
}
