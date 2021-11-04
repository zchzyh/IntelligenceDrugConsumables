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
    /// 基础数据版本
    /// </summary>
    public class S102VerMap : EntityTypeConfiguration<S102VerEntity>
    {
        public S102VerMap()
        {
            #region 表、主键
            //表
            this.ToTable("S102_VER", "BPMS");
            //主键
            this.HasKey(t => new { t.TYPEID, t.VERID });
            #endregion

            #region 配置关系
            #endregion
        }
    }
}