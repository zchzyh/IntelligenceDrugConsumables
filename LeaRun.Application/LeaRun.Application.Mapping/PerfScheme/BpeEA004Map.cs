using LeaRun.Application.Entity.PerfScheme;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Mapping.PerfScheme
{
    /// <summary>
    /// 评价方法明细
    /// </summary>
    public class BpeEA004Map : EntityTypeConfiguration<BpeEA004Entity>
    {
        public BpeEA004Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPE_EA004", "BPMS");
            //主键
            this.HasKey(t => t.XH);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
