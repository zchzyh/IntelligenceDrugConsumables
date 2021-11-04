using LeaRun.Application.Entity.CollectionManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.PerfConfig
{
    /// <summary>
    /// 分析器基本信息
    /// </summary>
    public class BpcSM003Map : EntityTypeConfiguration<BpcSm003Entity>
    {
        public BpcSM003Map()
        {
            #region 表、主键
            //表
            this.ToTable("BPC_SM003", "BPMS");
            //主键
            this.HasKey(t => t.XH);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}