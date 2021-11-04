using LeaRun.Application.Entity.PerfConfig;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.PerfConfig
{
    /// <summary>
    /// 评价设置接口程序
    /// </summary>
    public interface IAppraiseDataService
    {
        /// <summary>
        /// 获取评价方法列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<BpeEA003Entity> GetList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取评价方法编码列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<BpeEA003Entity> GetBmList(string queryJson);
        /// <summary>
        /// 获取评价方法实体
        /// </summary>
        /// <param name="pjffbh"></param>
        /// <returns></returns>
        BpeEA003Entity GetEntity(string pjffbh);

        /// <summary>
        /// 获取指标等级列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        IEnumerable<BpeEA001Entity> GetPerfLevelDataList(Pagination pagination, string queryJson);

        /// <summary>
        /// 获取综合等级列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        IEnumerable<BpeEA002Entity> GetSynLevelDataList(Pagination pagination, string queryJson);
    }
}