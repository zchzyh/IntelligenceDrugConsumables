using LeaRun.Application.Entity.CollectionManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollectionManage
{
    public class BpcSp003Map : EntityTypeConfiguration<BpcSp003Entity>
    {
        public BpcSp003Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPC_SP003", "BPMS");
            //主键
            this.HasKey(t => t.XH);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
