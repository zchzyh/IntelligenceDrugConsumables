using LeaRun.Application.Entity.BaseManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.BaseManage
{
    /// <summary>
    /// 版 本
    /// Admin Studio
    /// 创建人：Admin
    /// 日 期：2015.11.03 10:58
    /// 描 述：用户关系
    /// </summary>
    public class UserRelationMap : EntityTypeConfiguration<UserRelationEntity>
    {
        public UserRelationMap()
        {
            #region 表、主键
            //表
            this.ToTable("Base_UserRelation");
            //主键
            this.HasKey(t => t.UserRelationId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
