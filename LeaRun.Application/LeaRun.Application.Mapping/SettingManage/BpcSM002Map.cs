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
    /// 数据项分类信息
    /// </summary>
    public class BpcSM002Map : EntityTypeConfiguration<BpcSM002Entity>
    {
        public BpcSM002Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPC_SM002", "BPMS");
            //主键
            this.HasKey(t => t.TYPEID);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}