using LeaRun.Application.Entity.CollectionManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.PerfConfig
{
    /// <summary>
    /// 分析器基本信息
    /// </summary>
    public class BpcSp001Map : EntityTypeConfiguration<BpcSp001Entity>
    {
        public BpcSp001Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPC_Sp001", "BPMS");
            //主键
            this.HasKey(t => t.CJBBM);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}