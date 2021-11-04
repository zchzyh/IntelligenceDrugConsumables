using LeaRun.Application.Entity.CollectionManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CollectionManage
{
    public class BpcSp002Map : EntityTypeConfiguration<BpcSp002Entity>
    {
        public BpcSp002Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPC_SP002", "BPMS");
            //主键
            this.HasKey(t => t.RWBH);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
