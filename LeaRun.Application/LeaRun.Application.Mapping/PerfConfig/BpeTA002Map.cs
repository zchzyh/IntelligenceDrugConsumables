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
    /// 定量指标库信息
    /// </summary>
    public class BpeTA002Map : EntityTypeConfiguration<BpeTA002Entity>
    {
        public BpeTA002Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPE_TA002", "BPMS");
            //主键
            this.HasKey(t => t.KPIBH);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
