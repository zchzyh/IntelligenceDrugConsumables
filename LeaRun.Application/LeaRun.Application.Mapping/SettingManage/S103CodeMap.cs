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
    /// 基础数据编码
    /// </summary>
    public class S103CodeMap : EntityTypeConfiguration<S103CodeEntity>
    {
        public S103CodeMap()
        {
            #region 表、主键
            //表
            this.ToTable("S103_CODE", "BPMS");
            //主键
            this.HasKey(t => new { t.TYPEID, t.VERID, t.CODE });
            #endregion

            #region 配置关系
            #endregion
        }
    }
}