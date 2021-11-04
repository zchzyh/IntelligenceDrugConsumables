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
    /// 定性指标
    /// </summary>
    public interface IQualitativeIndicatorsService
    {
        #region 获取数据
        /// <summary>
        /// 定性指标设置列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<QualitativeIndicatorsModel> GetList(Pagination pagination, string queryJson);
        #endregion

        #region 提交数据
        #endregion
    }
}