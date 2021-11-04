using LeaRun.Application.Entity.PerfConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Mapping.PerfConfig
{
    /// <summary>
    /// 绩效年度配置
    /// </summary>
    public class BpeSC001Map : EntityTypeConfiguration<BpeSC001Entity>
    {
        public BpeSC001Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPE_SC001", "BPMS");
            //主键
            this.HasKey(t => t.JXBM);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
