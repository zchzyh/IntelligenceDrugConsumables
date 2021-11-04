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
    /// 定量指标目标值审核
    /// </summary>
    public interface IQuantitativeGoalAuditService
    {
        /// <summary>
        /// 定量指标目标值审核列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<QuantitativeGoalAuditModel> GetList(Pagination pagination, string queryJson);
        /// <summary>
        /// 定量指标目标值是否已申请
        /// </summary>
        /// <param name="jxbm">绩效年度编码</param>
        /// <param name="jgfabh">机构方案编号</param>
        /// <returns></returns>
        bool IsApply(string jxbm, string jgfabh);
    }
}