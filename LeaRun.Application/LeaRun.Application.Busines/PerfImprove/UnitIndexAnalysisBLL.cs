using LeaRun.Application.Entity.PerfConfig.ViewModel;
using LeaRun.Application.Entity.PerfImprove.ViewModel;
using LeaRun.Application.IService.PerfConfig;
using LeaRun.Application.IService.PerfImprove;
using LeaRun.Application.Service.PerfConfig;
using LeaRun.Application.Service.PerfImprove;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Busines.PerfImprove
{
    /// <summary>
    /// 单位指标分析
    /// </summary>
    public class UnitIndexAnalysisBLL
    {
        private IUnitIndexService unitIndexService = new UnitIndexService();
        private IAssessmentObjectService assessmentObjectService = new AssessmentObjectService();

        #region 获取数据

        /// <summary>
        /// 获取年度名称列表
        /// </summary>
        /// <returns>年度名称列表</returns>
        public IEnumerable<ComboBoxModel> GetYears()
        {
            return unitIndexService.GetYearList();
        }

        /// <summary>
        /// 获取科室编码列表
        /// </summary>
        /// <param name="jxbm">查询参数</param>
        /// <returns></returns>
        public IEnumerable<AssessmentObjectModel> GetDepartmentBms(string jxbm)
        {
            return assessmentObjectService.GetDepartmentBmList(jxbm);
        }

        /// <summary>
        /// 获取目标比较法列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<TargetComparisonModel> GetTargetComparison(Pagination pagination, string queryJson)
        {
            return unitIndexService.GetTargetList(pagination, queryJson);
        }

        /// <summary>
        /// 获取纵向比较法列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<VerticalComparisonModel> GetVerticalComparison(Pagination pagination, string queryJson)
        {
            return unitIndexService.GetVerticalList(pagination, queryJson);
        }

        /// <summary>
        /// 获取横向比较法列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<HorizontalComparisonModel> GetHorizontalComparison(Pagination pagination, string queryJson)
        {
            return unitIndexService.GetHorizontalList(pagination, queryJson);
        }

        #endregion


    }
}
