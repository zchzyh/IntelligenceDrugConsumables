using LeaRun.Application.Entity.BusinessManage;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Mapping.BusinessManage
{
    public class PantientInfoMap : EntityTypeConfiguration<PantientInfoEntity>
    {
        public PantientInfoMap()
        {
            #region 表，主键
            //表
            this.ToTable("PantientInfo", "dbo");
            //主键
            this.HasKey(t => t.CASE_NUM);
            #endregion
        }

    }
}
