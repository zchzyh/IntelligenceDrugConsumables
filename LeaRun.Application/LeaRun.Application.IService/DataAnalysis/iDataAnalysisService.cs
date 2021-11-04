using LeaRun.Application.Entity.DataAnalysis.ViewModel;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.DataAnalysis
{
    /// <summary>
    /// 数据分析
    /// </summary>
    public interface IDataAnalysisService
    {
        /// <summary>
        /// 获取月度分析数据列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<DataAnalysisModel> GetMonthlyList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取同比分析数据列表
        /// </summary>
        /// <param name="pagination">分页条件</param>
        /// <param name="queryJson">查询条件</param>
        /// <returns>同比分析数据</returns>
        IEnumerable<DataAnalysisModel> GetYoyList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取环比分析数据列表
        /// </summary>
        /// <param name="pagination">分页条件</param>
        /// <param name="queryJson">查询条件</param>
        /// <returns>环比分析数据</returns>
        IEnumerable<DataAnalysisModel> GetMomList(Pagination pagination, string queryJson);
    }
}