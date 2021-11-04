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
    /// 综合评价等级报告
    /// </summary>
    public class BpeRA003Map : EntityTypeConfiguration<BpeRA003Entity>
    {
        public BpeRA003Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPE_RA003", "BPMS");
            //主键
            this.HasKey(t => t.XH);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}