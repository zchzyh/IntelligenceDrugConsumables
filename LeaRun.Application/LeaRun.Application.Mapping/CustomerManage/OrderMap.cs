using LeaRun.Application.Entity.CustomerManage;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.Application.Mapping.CustomerManage
{
    /// <summary>
    /// 版 本
    /// Admin Studio
    /// 创 建：Admin
    /// 日 期：2016-03-16 13:54
    /// 描 述：订单管理
    /// </summary>
    public class OrderMap : EntityTypeConfiguration<OrderEntity>
    {
        public OrderMap()
        {
            #region 表、主键
            //表
            this.ToTable("Client_Order");
            //主键
            this.HasKey(t => t.OrderId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}