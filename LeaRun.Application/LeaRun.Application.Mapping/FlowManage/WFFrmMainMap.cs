using LeaRun.Application.Entity.FlowManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.FlowManage
{
    /// <summary>
    /// 版 本
    /// Admin Studio
    /// 创建人：Admin
    /// 日 期：2016.01.14 09:58
    /// 描 述：表单管理
    /// </summary>
    public class WFFrmMainMap : EntityTypeConfiguration<WFFrmMainEntity>
    {
        public WFFrmMainMap()
        {
            #region 表、主键
            //表
            this.ToTable("WF_FrmMain");
            //主键
            this.HasKey(t => t.FrmMainId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
