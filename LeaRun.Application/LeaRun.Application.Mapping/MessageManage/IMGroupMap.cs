using LeaRun.Application.Entity.MessageManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.MessageManage
{
    /// <summary>
    /// 版 本
    /// Admin Studio
    /// 创建人：Admin
    /// 日 期：2015.11.26 18:23
    /// 描 述：即时通信用户群组表
    /// </summary>
    public class IMGroupMap: EntityTypeConfiguration<IMGroupEntity>
    {
        public IMGroupMap()
        {
            #region 表、主键
            //表
            this.ToTable("IM_Group");
            //主键
            this.HasKey(t => t.GroupId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
