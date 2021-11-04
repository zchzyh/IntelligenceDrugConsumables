using LeaRun.Application.Entity.PerfScheme;
using LeaRun.Application.Entity.PerfGoal;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaRun.Application.Entity.PerfConfig.ViewModel;
using LeaRun.Application.Entity.PerfScheme.ViewModel;

namespace LeaRun.Application.IService.PerfScheme
{
    /// <summary>
    /// 基本方案设置
    /// </summary>
    public interface IPerfSchemeDataService
    {
        /// <summary>
        /// 获取基本方案列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<BpePA001Entity> GetList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取基本方案名称列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<BaseperfSchemesettingModel> GetBaseperfNameList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取基本方案列表编码
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<BpePA001Entity> GetBmList(string queryJson);
        /// <summary>
        /// 获取所有指标的列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        IEnumerable<KpiAll> GetKPIListJson(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取科室方案信息
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<BpePA003Entity> GetDepSchemeDataList(Pagination pagination, string queryJson);
    }
}
