using LeaRun.Application.Entity.DataAnalysis.ViewModel;
using LeaRun.Application.IService.DataAnalysis;
using LeaRun.Application.Service.DataAnalysis;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Busines.DataAnalysis
{
    /// <summary>
    /// 数据分析
    /// </summary>
    public class DataAnalysisBLL
    {
        private IDataAnalysisService dataAnalysisService = new DataAnalysisService();

        #region 获取数据

        /// <summary>
        /// 获取月度分析数据列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DataAnalysisModel> GetMonthlyList(Pagination pagination, string queryJson)
        {
            var datas = dataAnalysisService.GetMonthlyList(pagination, queryJson);
            datas.ToList().ForEach(d =>
            {
                if (d.YearData != null && d.YearData != 0)
                {
                    d.YearPercent = d.CurrentPeriodData / d.YearData * 100m;
                }
            });

            return datas;
        }

        /// <summary>
        /// 获取同比分析数据列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DataAnalysisModel> GetYoyList(Pagination pagination, string queryJson)
        {
            var datas = dataAnalysisService.GetYoyList(pagination, queryJson);
            datas.ToList().ForEach(d =>
            {
                if (d.LastPeriodData != null && d.LastPeriodData != 0)
                {
                    d.GrowthRate = (d.CurrentPeriodData - d.LastPeriodData) / d.LastPeriodData * 100m;
                }
            });

            return datas;
        }

        /// <summary>
        /// 获取环比分析数据列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DataAnalysisModel> GetMomList(Pagination pagination, string queryJson)
        {
            var datas = dataAnalysisService.GetMomList(pagination, queryJson);
            datas.ToList().ForEach(d =>
            {
                if (d.LastPeriodData != null && d.LastPeriodData != 0)
                {
                    d.GrowthRate = (d.CurrentPeriodData - d.LastPeriodData) / d.LastPeriodData * 100m;
                }
            });

            return datas;
        }

        #endregion
    }
}