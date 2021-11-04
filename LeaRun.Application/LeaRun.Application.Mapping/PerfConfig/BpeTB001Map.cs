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
    /// 定性指标库
    /// </summary>
    public class BpeTB001Map : EntityTypeConfiguration<BpeTB001Entity>
    {
        public BpeTB001Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPE_TB001", "BPMS");
            //主键
            this.HasKey(t => new { t.ZBBH, t.JXBM });
            #endregion

            #region 配置关系
            #endregion
        }
    }
}