using LeaRun.Application.Entity.SettingManage;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Mapping.SettingManage
{
    public class PMR009UserMap : EntityTypeConfiguration<PMR009UserEntity>
    {
        public PMR009UserMap()
        {
            #region 表、主键
            //表
            this.ToTable("PMR009_USER", "BPMS");
            //主键
            this.HasKey(t => t.ID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
