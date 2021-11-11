using LeaRun.Application.Entity.BusinessManage;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Mapping.BusinessManage
{
    public class SystemParameterMap: EntityTypeConfiguration<SystemParameterEntity>
    {
        public SystemParameterMap()
        {
            this.ToTable("SystemParameter", "dbo");
            this.HasKey(T => T.Par_Code);
        }
    }
}
