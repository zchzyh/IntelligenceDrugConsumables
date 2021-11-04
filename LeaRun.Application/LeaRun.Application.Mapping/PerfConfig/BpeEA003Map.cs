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
    /// 评价方法表
    /// </summary>
    public class BpeEA003Map : EntityTypeConfiguration<BpeEA003Entity>
    {
        public BpeEA003Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPE_EA003", "BPMS");
            //主键
            this.HasKey(t => t.PJFFBH);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}