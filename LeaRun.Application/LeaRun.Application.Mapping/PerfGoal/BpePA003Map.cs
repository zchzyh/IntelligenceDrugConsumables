using LeaRun.Application.Entity.PerfGoal;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Mapping.PerfGoal
{
    /// <summary>
    /// 单位方案信息
    /// </summary>
    public class BpePA003Map : EntityTypeConfiguration<BpePA003Entity>
    {
        public BpePA003Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPE_PA003", "BPMS");
            //主键
            this.HasKey(t => t.JGFABH);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}