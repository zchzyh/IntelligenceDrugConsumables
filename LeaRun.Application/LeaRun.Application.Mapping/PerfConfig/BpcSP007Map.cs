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
    /// 考核对象管理
    /// </summary>
    public class BpcSP007Map : EntityTypeConfiguration<BpcSP007Entity>
    {
        public BpcSP007Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPC_SP007", "BPMS");
            //主键
            this.HasKey(t => t.XH);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}