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
    /// 数据项基本信息
    /// </summary>
    public class BpcSM001Map : EntityTypeConfiguration<BpcSM001Entity>
    {
        public BpcSM001Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPC_SM001", "BPMS");
            //主键
            this.HasKey(t => t.JCSJBM);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}