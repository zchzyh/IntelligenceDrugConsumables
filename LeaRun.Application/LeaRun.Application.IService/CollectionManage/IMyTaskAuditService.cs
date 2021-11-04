using LeaRun.Application.Entity.CollectionManage.ViewModel;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.CollectionManage
{
    /// <summary>
    /// 我的审核任务
    /// </summary>
    public interface IMyTaskAuditService
    {
        #region 获取数据

        /// <summary>
        /// 获取我的审核任务列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<MyTaskAuditModel> GetMyTaskAuditList(Pagination pagination, string queryJson);

        #endregion

        #region 提交数据

        #endregion
    }
}
