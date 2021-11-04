using LeaRun.Application.Entity.CollectionManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollectionManage
{
    public  class BpcSc003Map : EntityTypeConfiguration<BpcSc003Entity>
    {
        public BpcSc003Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPC_SC003", "BPMS");
            //主键
            this.HasKey(t => t.XH);
            #endregion

            #region 配置关系
            #endregion
        }

    }
}
