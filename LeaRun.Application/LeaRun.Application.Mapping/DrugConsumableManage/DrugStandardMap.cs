using LeaRun.Application.Entity.DrugConsumableManage;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Mapping.DrugConsumableManage
{
    public class DrugStandardMap : EntityTypeConfiguration<DrugStandardEntity>
    {
        public DrugStandardMap()
        {
            #region 表、主键
            //表
            this.ToTable("Drug_Standard","dbo");
            //主键
            this.HasKey(t => t.Drug_Code);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
