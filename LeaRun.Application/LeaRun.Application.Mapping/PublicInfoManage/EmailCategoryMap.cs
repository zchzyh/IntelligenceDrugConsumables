using LeaRun.Application.Entity.PublicInfoManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.PublicInfoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Admin Studio
    /// 创建人：Admin
    /// 日 期：2015.12.8 11:31
    /// 描 述：邮件分类
    /// </summary>
    public class EmailCategoryMap : EntityTypeConfiguration<EmailCategoryEntity>
    {
        public EmailCategoryMap()
        {
            #region 表、主键
            //表
            this.ToTable("Email_Category");
            //主键
            this.HasKey(t => t.CategoryId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
