using LeaRun.Application.Entity.CollectionManage;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Mapping.CollectionManage
{
    /// <summary>
    /// 采集日常监控表
    /// </summary>
    public class BpcSP006Map : EntityTypeConfiguration<BpcSP006Entity>
    {
        public BpcSP006Map()
        {
            #region 表、主键

            //表
            this.ToTable("BPC_SP006", "BPMS");
            //主键
            this.HasKey(t => t.XH);

            #endregion

            #region 配置关系

            #endregion
        }
    }
}
