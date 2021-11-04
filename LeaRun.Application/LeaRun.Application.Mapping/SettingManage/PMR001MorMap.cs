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
    /// 主管机构信息
    /// </summary>
    public class PMR001MorMap : EntityTypeConfiguration<PMR001MorEntity>
    {
        public PMR001MorMap()
        {
            #region 表、主键
            //表
            this.ToTable("PMR001_MOR", "BPMS");
            //主键
            this.HasKey(t => t.ID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}