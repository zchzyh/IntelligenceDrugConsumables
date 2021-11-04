using LeaRun.Application.Entity.PerfGoal.ViewModel;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.PerfGoal
{
    /// <summary>
    /// 定量指标目标值
    /// </summary>
    public interface IQuantitativeGoalService
    {
        /// <summary>
        /// 定量指标目标值列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<QuantitativeGoalModel> GetList(Pagination pagination, string queryJson);
        /// <summary>
        /// 部门方案定量指标报告数据列表
        /// </summary>
        /// <param name="jgfabh">部门方案编号</param>
        /// <returns></returns>
        IEnumerable<QuantitativeGoalModel> GetReportDataList(string jgfabh);
        /// <summary>
        /// 定量指标目标值申请
        /// </summary>
        /// <param name="jgfabh">机构方案编号</param>
        /// <param name="applyStatus">申请状态(0未申请/1已申请)</param>
        void Apply(string jgfabh, int applyStatus);
    }
}