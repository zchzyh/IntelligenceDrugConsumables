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
    /// 年度绩效设置
    /// </summary>
    public interface IYearSettingService
    {
        /// <summary>
        /// 获取年度绩效设置列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<YearSettingModel> GetList(Pagination pagination, string queryJson);
    }
}