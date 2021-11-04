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
    /// 指标库基本信息
    /// </summary>
    public class BpeTA001Map : EntityTypeConfiguration<BpeTA001Entity>
    {
        public BpeTA001Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPE_TA001", "BPMS");
            //主键
            this.HasKey(t => new { t.ZBBH, t.JXBM });
            #endregion

            #region 配置关系
            #endregion
        }
    }
}