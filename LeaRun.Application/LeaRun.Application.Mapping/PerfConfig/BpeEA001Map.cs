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
    /// 指标等级表
    /// </summary>
    public class BpeEA001Map : EntityTypeConfiguration<BpeEA001Entity>
    {
        public BpeEA001Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPE_EA001", "BPMS");
            //主键
            this.HasKey(t => t.XH);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
