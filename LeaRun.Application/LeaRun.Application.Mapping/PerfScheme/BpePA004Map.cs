using LeaRun.Application.Entity.PerfScheme;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Mapping.PerfScheme
{
    /// <summary>
    /// 绩效方案明细表
    /// </summary>
    public class BpePA004Map : EntityTypeConfiguration<BpePA004Entity>
    {
        public BpePA004Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPE_PA004", "BPMS");
            //主键
            this.HasKey(t => t.XH);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
