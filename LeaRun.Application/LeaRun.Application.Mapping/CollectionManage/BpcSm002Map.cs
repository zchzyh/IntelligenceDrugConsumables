using LeaRun.Application.Entity.SettingManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollectionManage
{
    /// <summary>
    /// 分析器基本信息
    /// </summary>
    public class BpcSm002Map : EntityTypeConfiguration<BpcSM002Entity>
    {
        public BpcSm002Map()
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