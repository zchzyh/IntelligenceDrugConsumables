using LeaRun.Application.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.SystemManage
{
    /// <summary>
    /// 版 本 6.1
    /// Admin Studio
    /// 创建人：Admin
    /// 日 期：2015.11.12 16:40
    /// 描 述：区域管理
    /// </summary>
    public class DataBaseLinkMap : EntityTypeConfiguration<DataBaseLinkEntity>
    {
        public DataBaseLinkMap()
        {
            #region 表、主键
            //表
            this.ToTable("Base_DatabaseLink");
            //主键
            this.HasKey(t => t.DatabaseLinkId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
