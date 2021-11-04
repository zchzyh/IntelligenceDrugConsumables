using System.Data.Entity.ModelConfiguration;
using LeaRun.Application.Entity.CollectionManage;

namespace LeaRun.Application.Mapping.CollectionManage
{
    public class BpcSp008Map : EntityTypeConfiguration<BpcSp008Entity>
    {
        public BpcSp008Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPC_SP008", "BPMS");
            //主键
            this.HasKey(t => t.CJBBM);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
