using LeaRun.Application.Entity.PerfReport;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Mapping.PerfReport
{
  public  class BpeRA005Map: EntityTypeConfiguration<BpeRA005Entity>
    {
        public BpeRA005Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPE_RA005", "BPMS");
            //主键
            this.HasKey(t => t.serial_num);
            #endregion

            #region 配置关系

            #endregion
        }
    }
}
