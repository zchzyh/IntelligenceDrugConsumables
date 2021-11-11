using LeaRun.Application.Entity.BusinessManage;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Mapping.BusinessManage
{
    public class EditionInfoMap: EntityTypeConfiguration<EditionInfoEntity>
    {
        public EditionInfoMap()
        {
            #region 表，主键
            //表
            this.ToTable("EditionInfo","dbo");
            //主键
            this.HasKey(t => t.Edition_Code);
            #endregion
        }

    }
}
