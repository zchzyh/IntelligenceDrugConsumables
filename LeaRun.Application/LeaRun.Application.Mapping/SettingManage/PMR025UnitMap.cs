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
    /// 医疗机构注册
    /// </summary>
    public class PMR025UnitMap : EntityTypeConfiguration<PMR025UnitEntity>
    {
        public PMR025UnitMap()
        {
            #region 表、主键
            //表
            this.ToTable("PMR025_UNIT", "BPMS");
            //主键
            this.HasKey(t => t.UNITID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}