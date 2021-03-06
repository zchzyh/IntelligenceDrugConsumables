using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Reflection;
using System.Linq;
using System.Web;
using System.IO;
using LeaRun.Data.EF.Extension;

namespace LeaRun.Data.EF
{
    /// <summary>
    /// 版 本 6.1
    /// Admin Studio
    /// 创建人：Admin
    /// 日 期：2015.10.10
    /// 描 述：数据访问(SqlServer) 上下文
    /// </summary>
    public class SqlServerDbContext : DbContext, IDbContext
    {
        #region 构造函数
        /// <summary>
        /// 初始化一个 使用指定数据连接名称或连接串 的数据访问上下文类 的新实例
        /// </summary>
        /// <param name="connString"></param>
        public SqlServerDbContext(string connString)
            : base(connString)
        {
            System.Data.Entity.Database.SetInitializer<SqlServerDbContext>(null);
            
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
        #endregion

        #region 重载
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            string assembleFileName = Assembly.GetExecutingAssembly().CodeBase.Replace("LeaRun.Data.EF.DLL", "LeaRun.Application.Mapping.dll").Replace("file:///", "");
            Assembly asm = Assembly.LoadFile(assembleFileName);
            var typesToRegister = asm.GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            modelBuilder.Conventions.Add(new DecimalPrecisionAttributeConvention());
            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
