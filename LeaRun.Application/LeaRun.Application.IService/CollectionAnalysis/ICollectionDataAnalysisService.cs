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
    /// 采集数据分析
    /// </summary>
    public interface ICollectionDataAnalysisService
    {
        /// <summary>
        /// 获取数据项年度分析列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<StandardDataAnalysisModel> GetStandardDataYearAnalysisList(Pagination pagination, string queryJson);

        /// <summary>
        /// 获取数据项月度分析列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<StandardDataAnalysisModel> GetStandardDataMonthAnalysisList(Pagination pagination, string queryJson);
    }
}