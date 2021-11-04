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
    /// 分析器基本信息
    /// </summary>
    public class BpcSM006Map : EntityTypeConfiguration<BpcSM006Entity>
    {
        public BpcSM006Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPC_SM006", "BPMS");
            //主键
            this.HasKey(t => t.FXQBM);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}