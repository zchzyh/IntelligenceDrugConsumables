using System.Data.Entity.ModelConfiguration;
using LeaRun.Application.Entity.CollectionManage;

namespace LeaRun.Application.Mapping.CollectionManage
{
    public class BpcSm001Map : EntityTypeConfiguration<BpcSm001Entity>
    {
        public BpcSm001Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPC_SM001", "BPMS");
            //主键
            this.HasKey(t => t.JCSJBM);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
