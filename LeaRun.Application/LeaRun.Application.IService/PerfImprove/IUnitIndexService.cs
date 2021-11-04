using LeaRun.Application.Entity.PerfImprove.ViewModel;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.PerfImprove
{
    /// <summary>
    /// 单位指标分析
    /// </summary>
    public interface IUnitIndexService
    {
        #region 获取数据
        /// <summary>
        /// 获取年度名称列表
        /// </summary>
        /// <returns>年度名称列表</returns>
        IEnumerable<ComboBoxModel> GetYearList();

        /// <summary>
        /// 获取目标比较法列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<TargetComparisonModel> GetTargetList(Pagination pagination, string queryJson);

        /// <summary>
        /// 获取纵向比较法列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<VerticalComparisonModel> GetVerticalList(Pagination pagination, string queryJson);

        /// <summary>
        /// 获取横向比较法列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<HorizontalComparisonModel> GetHorizontalList(Pagination pagination, string queryJson);
        #endregion
    }
}
