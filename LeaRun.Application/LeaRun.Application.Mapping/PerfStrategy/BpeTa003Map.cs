using LeaRun.Application.Entity.PerfReport;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.Entity.PerfStrategy;

namespace LeaRun.Application.Mapping.PerfStrategy
{
    /// <summary>
    /// 定量指标等级报告
    /// </summary>
    public class BpeTa003Map : EntityTypeConfiguration<BpeTa003Entity>
    {
        public BpeTa003Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPE_TA003", "BPMS");
            //主键
            this.HasKey(t => t.XH);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}