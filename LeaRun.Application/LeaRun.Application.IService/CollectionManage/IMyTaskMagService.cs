using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaRun.Application.Entity.CollectionManage.ViewModel;
using LeaRun.Util.WebControl;
using LeaRun.Application.Entity.CollectionManage;

namespace LeaRun.Application.IService.CollectionManage
{
    /// <summary>
    /// 我的采集任务
    /// </summary>
    public interface IMyTaskMagService
    {
        #region 获取数据


        /// <summary>
        /// 获取我的采集任务列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<MyTaskMagModel> GetMyTaskMagList(Pagination pagination, string queryJson);

        /// <summary>
        /// 获取采集表表头
        /// </summary>
        /// <param name="entity">任务信息管理实体</param>
        /// <returns></returns>
        IEnumerable<MyTableHeaderModel> GetCollectionTableHeader(BpcSp002Entity entity);

        /// <summary>
        /// 获取采集表行
        /// </summary>
        /// <param name="entity">任务信息管理实体</param>
        /// <returns></returns>
        IEnumerable<MyTableRowModel> GetCollectionTableRow(BpcSp002Entity entity);

        /// <summary>
        /// 获取采集表数据
        /// </summary>
        /// <param name="entity">任务信息管理实体</param>
        /// <returns></returns>
        IEnumerable<MyTableDataModel> GetCollectionTableData(BpcSp002Entity entity);

        #endregion

        #region 提交数据

        #endregion



    }
}
