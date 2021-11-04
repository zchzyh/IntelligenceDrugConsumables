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
    /// 采集存储值表
    /// </summary>
    public class BpcSC004Map : EntityTypeConfiguration<BpcSC004Entity>
    {
        public BpcSC004Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPC_SC004", "BPMS");
            //主键
            this.HasKey(t => t.XH);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
