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
    /// 元数据库基本表
    /// </summary>
    public class BpeMA001Map : EntityTypeConfiguration<BpeMA001Entity>
    {
        public BpeMA001Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPE_MA001", "BPMS");
            //主键
            this.HasKey(t => new { t.JXND, t.METCODE });
            #endregion

            #region 配置关系
            #endregion
        }
    }
}