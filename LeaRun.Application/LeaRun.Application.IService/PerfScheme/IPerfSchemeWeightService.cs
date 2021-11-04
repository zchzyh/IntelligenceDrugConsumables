using LeaRun.Application.Entity.PerfScheme.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.PerfScheme
{
    /// <summary>
    /// 方案权重设置
    /// </summary>
    public interface IPerfSchemeWeightService
    {
        /// <summary>
        /// 获取方案所有指标
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<PerfSchemeWeightModel> GetZBList(string fabh);
        /// <summary>
        /// 获取方案所有指标权重
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<PerfSchemeWeightModel> GetWeightList(string fabh);
        /// <summary>
        /// 设置方案指标权重
        /// </summary>
        /// <param name="list">方案指标权重列表</param>
        /// <param name="level">指标等级</param>
        /// <returns></returns>
        void ModifyWeightList(List<PerfSchemeWeightModel> list, string level);
    }
}