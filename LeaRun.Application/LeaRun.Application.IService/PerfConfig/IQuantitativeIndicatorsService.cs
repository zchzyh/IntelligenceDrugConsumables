using LeaRun.Application.Entity.PerfConfig;
using LeaRun.Application.Entity.PerfConfig.ViewModel;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.PerfConfig
{
    /// <summary>
    /// 定量指标设置
    /// </summary>
    public interface IQuantitativeIndicatorsService
    {
        /// <summary>
        /// 定量指标设置列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<QuantitativeIndicatorsModel> GetList(Pagination pagination, string queryJson);
    }
}