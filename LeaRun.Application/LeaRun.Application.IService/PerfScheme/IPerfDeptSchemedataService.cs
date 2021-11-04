using LeaRun.Application.Entity.PerfGoal;
using LeaRun.Application.Entity.PerfScheme.ViewModel;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.PerfScheme
{
    /// <summary>
    /// 部门绩效方案设置
    /// </summary>
    public interface IPerfDeptSchemedataService
    {
        /// <summary>
        /// 获取部门绩效方案编码列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<BpePA003Entity> GetBmList(string queryJson);
        /// <summary>
        /// 获取部门绩效方案年度服务状态
        /// </summary>
        /// <param name="jgfabh">部门绩效方案编号</param>
        /// <returns>部门绩效方案年度服务状态</returns>
        string GetPertFwzt(string jgfabh);

        /// <summary>
        ///部门绩效方案明细列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DepSchemeZBModel> GetKPIListJson(Pagination pagination, string queryJson);

    }
}