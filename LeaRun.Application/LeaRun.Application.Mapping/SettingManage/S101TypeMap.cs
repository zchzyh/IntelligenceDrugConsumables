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
    /// 基础数据分类
    /// </summary>
    public class S101TypeMap : EntityTypeConfiguration<S101TypeEntity>
    {
        public S101TypeMap()
        {
            #region 表、主键
            //表
            this.ToTable("S101_TYPE", "BPMS");
            //主键
            this.HasKey(t => t.TYPEID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}