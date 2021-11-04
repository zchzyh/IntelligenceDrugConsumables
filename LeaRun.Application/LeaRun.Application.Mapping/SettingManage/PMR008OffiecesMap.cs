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
    public class PMR008OffiecesMap : EntityTypeConfiguration<PMR008OffiecesEntity>
    {
        public PMR008OffiecesMap()
        {
            #region 表、主键
            //表
            this.ToTable("PMR008_OFFIECES", "BPMS");
            //主键
            this.HasKey(t => t.ID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}