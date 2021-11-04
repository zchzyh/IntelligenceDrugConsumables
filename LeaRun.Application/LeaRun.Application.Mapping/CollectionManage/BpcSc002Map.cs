using LeaRun.Application.Entity.CollectionManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollectionManage
{
    public class BpcSc002Map : EntityTypeConfiguration<BpcSc002Entity>
    {
        public BpcSc002Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPC_SC002", "BPMS");
            //主键
            this.HasKey(t => t.XH);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
