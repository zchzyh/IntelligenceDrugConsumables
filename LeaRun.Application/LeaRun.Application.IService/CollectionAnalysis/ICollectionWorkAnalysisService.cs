using LeaRun.Application.Entity.CollectionAnalysis.ViewModel;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.CollectionAnalysis
{
    /// <summary>
    /// 采集工作分析
    /// </summary>
    public interface ICollectionWorkAnalysisService
    {
        /// <summary>
        /// 获取采集任务督查列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<CollectionTaskInspectModel> GetCollectionTaskInspectList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取审核任务督查列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<AuditTaskInspectModel> GetAuditTaskInspectList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取采集任务预警列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<CollectionTaskWarningModel> GetCollectionTaskWarningList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取年度任务分析列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<YearTaskAnalysisModel> GetYearTaskAnalysisList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取年度任务列表
        /// </summary>
        /// <param name="jxbm">绩效年度编码</param>
        /// <param name="userids">任务人ID列表</param>
        /// <returns>返回列表</returns>
        IEnumerable<YearTaskAnalysisItemModel> GetYearTaskAnalysisItemList(string jxbm, List<string> userids);
    }
}