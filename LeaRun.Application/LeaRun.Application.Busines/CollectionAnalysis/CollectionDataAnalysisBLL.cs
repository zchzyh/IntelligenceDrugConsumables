using LeaRun.Application.Entity.CollectionAnalysis.ViewModel;
using LeaRun.Application.IService.CollectionAnalysis;
using LeaRun.Application.Service.CollectionAnalysis;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Busines.CollectionAnalysis
{
    /// <summary>
    /// 采集数据分析
    /// </summary>
    public class CollectionDataAnalysisBLL
    {
        private ICollectionDataAnalysisService collectionDataAnalysisService = new CollectionDataAnalysisService();

        #region 获取数据

        /// <summary>
        /// 获取数据项年度分析列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<StandardDataAnalysisModel> GetStandardDataYearAnalysisList(Pagination pagination, string queryJson)
        {
            return collectionDataAnalysisService.GetStandardDataYearAnalysisList(pagination, queryJson);
        }

        /// <summary>
        /// 获取数据项月度分析列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<StandardDataAnalysisModel> GetStandardDataMonthAnalysisList(Pagination pagination, string queryJson)
        {
            return collectionDataAnalysisService.GetStandardDataMonthAnalysisList(pagination, queryJson);
        }

        #endregion
    }
}