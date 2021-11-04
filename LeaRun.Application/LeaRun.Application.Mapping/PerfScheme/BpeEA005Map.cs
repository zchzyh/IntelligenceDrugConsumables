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
    /// 指标权重设置
    /// </summary>
    public class BpeEA005Map : EntityTypeConfiguration<BpeEA005Entity>
    {
        public BpeEA005Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPE_EA005", "BPMS");
            //主键
            this.HasKey(t => t.XH);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
