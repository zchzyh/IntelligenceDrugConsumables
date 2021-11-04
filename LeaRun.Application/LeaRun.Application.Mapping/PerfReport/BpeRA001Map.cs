using LeaRun.Application.Entity.PerfReport;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Mapping.PerfReport
{
    /// <summary>
    /// 定量指标等级报告
    /// </summary>
    public class BpeRA001Map : EntityTypeConfiguration<BpeRA001Entity>
    {
        public BpeRA001Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPE_RA001", "BPMS");
            //主键
            this.HasKey(t => t.XH);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}