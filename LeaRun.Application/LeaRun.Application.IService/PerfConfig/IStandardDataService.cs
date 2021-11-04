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
    /// 数据项列表信息
    /// </summary>
    public interface IStandardDataService
    {
        /// <summary>
        /// 获取数据项键值列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<StandardDataModel> GetKeyValueList(string queryJson);
        /// <summary>
        /// 获取数据项列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<StandardDataModel> GetList(Pagination pagination, string queryJson);

        /// <summary>
        /// 获取分析器数据项列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<StandardDataModel> GetListForAnalyzer(Pagination pagination, string queryJson);

        /// <summary>
        /// 数据项绑定分析器
        /// </summary>
        /// <param name="jcsjbm">数据项编码</param>
        /// <param name="fxqbm">分析器编码</param>
        void BindAnalyzer(string jcsjbm, string fxqbm);
    }
}