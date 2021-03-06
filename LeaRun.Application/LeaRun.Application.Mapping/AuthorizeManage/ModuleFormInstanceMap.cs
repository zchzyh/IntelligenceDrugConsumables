using LeaRun.Application.Entity.AuthorizeManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.AuthorizeManage
{
    /// <summary>
    /// 版 本 6.1
    /// Admin Studio
    /// 创建人：Admin
    /// 日 期：2016.04.14 09:16
    /// 描 述：系统表单
    /// </summary>
    public class ModuleFormInstanceMap : EntityTypeConfiguration<ModuleFormInstanceEntity>
    {
        public ModuleFormInstanceMap()
        {
            #region 表、主键
            //表
            this.ToTable("Base_ModuleFormInstance");
            //主键
            this.HasKey(t => t.FormInstanceId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
