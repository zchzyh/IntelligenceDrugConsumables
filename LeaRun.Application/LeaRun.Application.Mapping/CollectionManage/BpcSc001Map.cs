using LeaRun.Application.Entity.CollectionManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollectionManage
{
    public class BpcSc001Map : EntityTypeConfiguration<BpcSc001Entity>
    {
        public BpcSc001Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPC_SC001", "BPMS");
            //主键
            this.HasKey(t => t.HXBM);
            #endregion

            #region 配置关系
            #endregion
        }
    }

}