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
    /// 部门绩效评价设置
    /// </summary>
    public interface IPerfDeptSchemeAppraisedataService
    {
        #region 获取数据
        /// <summary>
        /// 部门绩效评价设置列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<PerfDeptSchemeAppraisedataModel> GetList(Pagination pagination, string queryJson);
        #endregion
    }
}