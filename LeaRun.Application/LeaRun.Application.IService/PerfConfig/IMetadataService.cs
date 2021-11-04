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
    /// 元数据
    /// </summary>
    public interface IMetadataService
    {
        /// <summary>
        /// 获取元数据列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<MetadataModel> GetList(Pagination pagination, string queryJson);

        /// <summary>
        /// 获取分析器元数据列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<MetadataModel> GetListForAnalyzer(Pagination pagination, string queryJson);

        /// <summary>
        /// 元数据绑定分析器
        /// </summary>
        /// <param name="jxbm">绩效年度编码</param>
        /// <param name="metaCode">元数据编码</param>
        /// <param name="fxqbm">分析器编码</param>
        void BindAnalyzer(string jxbm, string metaCode, string fxqbm);
    }
}