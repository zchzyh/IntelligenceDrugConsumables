using LeaRun.Application.Entity.CustomerManage;
using LeaRun.Util.WebControl;
using System.Collections.Generic;

namespace LeaRun.Application.IService.CustomerManage
{
    /// <summary>
    /// 版 本 6.1
    /// Admin Studio
    /// 创 建：Admin
    /// 日 期：2016-03-16 13:54
    /// 描 述：订单明细
    /// </summary>
    public interface IOrderEntryService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="orderId">订单主键</param>
        /// <returns>返回列表</returns>
        IEnumerable<OrderEntryEntity> GetList(string orderId);
        #endregion
    }
}