using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.CollectionManage { 
   public partial class  BpcSm002Entity
    {
        /// <summary>
        /// 上级名称
        /// </summary>
        [NotMapped]
        public  string ParentName { get; set; }
    }
}
