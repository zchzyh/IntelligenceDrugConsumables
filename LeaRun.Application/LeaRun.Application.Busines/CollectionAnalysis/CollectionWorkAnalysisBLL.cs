using LeaRun.Application.Entity.CollectionAnalysis.ViewModel;
using LeaRun.Application.IService.CollectionAnalysis;
using LeaRun.Application.Service.CollectionAnalysis;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Busines.CollectionAnalysis
{
    /// <summary>
    /// 采集工作分析
    /// </summary>
    public class CollectionWorkAnalysisBLL
    {
        private ICollectionWorkAnalysisService collectionWorkAnalysisService = new CollectionWorkAnalysisService();

        #region 获取数据

        /// <summary>
        /// 获取采集任务督查列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<CollectionTaskInspectModel> GetCollectionTaskInspectList(Pagination pagination, string queryJson)
        {
            return collectionWorkAnalysisService.GetCollectionTaskInspectList(pagination, queryJson);
        }

        /// <summary>
        /// 获取审核任务督查列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<AuditTaskInspectModel> GetAuditTaskInspectList(Pagination pagination, string queryJson)
        {
            return collectionWorkAnalysisService.GetAuditTaskInspectList(pagination, queryJson);
        }

        /// <summary>
        /// 获取采集任务预警列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<CollectionTaskWarningModel> GetCollectionTaskWarningList(Pagination pagination, string queryJson)
        {
            var list = collectionWorkAnalysisService.GetCollectionTaskWarningList(pagination, queryJson);
            DateTime now = DateTime.Now;
            list.ToList().ForEach(d =>
            {
                if (d.JZSJ.HasValue)
                {
                    d.Days = (d.JZSJ.Value - now).Days;
                }
            });

            return list;
        }

        /// <summary>
        /// 获取年度任务分析列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<YearTaskAnalysisModel> GetYearTaskAnalysisList(Pagination pagination, string queryJson)
        {
            var list = collectionWorkAnalysisService.GetYearTaskAnalysisList(pagination, queryJson).ToList();

            if (list.Count != 0)
            {
                string jxbm = list.First().JXBM;
                List<string> userids = list.Select(l => l.USERID).ToList();
                var items = collectionWorkAnalysisService.GetYearTaskAnalysisItemList(jxbm, userids);

                var collectStatusTypeDone = Config.GetValue("CollectStatusTypeDone");
                foreach (var l in list)
                {
                    l.AddMonthDatas(items.ToList(), collectStatusTypeDone);
                }
            }

            return list;
        }

        #endregion
    }
}