using LeaRun.Application.Entity.SettingManage;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Mapping.SettingManage
{
    /// <summary>
    /// 维度基本信息
    /// </summary>
    public class BpeVA002Map : EntityTypeConfiguration<BpeVA002Entity>
    {
        public BpeVA002Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPE_VA002", "BPMS");
            //主键
            this.HasKey(t => t.BSCBH);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}