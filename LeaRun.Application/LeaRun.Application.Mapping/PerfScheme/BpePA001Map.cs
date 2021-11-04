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
    /// 绩效方案基础信息表
    /// </summary>
    public class BpePA001Map : EntityTypeConfiguration<BpePA001Entity>
    {
        public BpePA001Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPE_PA001", "BPMS");
            //主键
            this.HasKey(t => t.FABH);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
