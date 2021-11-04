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
    /// 定量指标目标值
    /// </summary>
    public class BpeTA004Map : EntityTypeConfiguration<BpeTA004Entity>
    {
        public BpeTA004Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPE_TA004", "BPMS");
            //主键
            this.HasKey(t => t.XH);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}