using LeaRun.Application.Entity.FlowManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.FlowManage
{
    /// <summary>
    /// 版 本
    /// Admin Studio
    /// 创建人：Admin
    /// 日 期：2016.02.23 09:58
    /// 描 述：工作流模板内容表
    /// </summary>
    public class WFSchemeContentMap: EntityTypeConfiguration<WFSchemeContentEntity>
    {
        public WFSchemeContentMap()
        {
            #region 表、主键
            //表
            this.ToTable("WF_SchemeContent");
            //主键
            this.HasKey(t => t.Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
