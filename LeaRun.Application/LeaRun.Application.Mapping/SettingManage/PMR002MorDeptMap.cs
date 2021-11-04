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
    public class PMR002MorDeptMap : EntityTypeConfiguration<PMR002MorDeptEntity>
    {
        public PMR002MorDeptMap()
        {
            #region 表、主键
            //表
            this.ToTable("PMR002_MOR_DEPT", "BPMS");
            //主键
            this.HasKey(t => t.DEPTID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}