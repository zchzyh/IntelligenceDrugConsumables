using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.SettingManage
{
    public partial class PMR008OffiecesEntity
    {
        [NotMapped]
        public string OrgName { get; set; }
    }
}
