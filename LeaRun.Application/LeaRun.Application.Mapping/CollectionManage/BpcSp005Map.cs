using System.Data.Entity.ModelConfiguration;
using LeaRun.Application.Entity.CollectionManage;

namespace LeaRun.Application.Mapping.CollectionManage
{
    public class BpcSp005Map : EntityTypeConfiguration<BpcSp005Entity>
    {
        public BpcSp005Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPC_SP005", "BPMS");
            //主键
            this.HasKey(t => t.XH);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
