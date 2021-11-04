using System.Collections.Generic;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.Entity.CollectionManage.ViewModel;
using LeaRun.Application.Entity.PerfConfig;
using LeaRun.Util.WebControl;

namespace LeaRun.Application.IService.CollectionManage
{
    public interface IBpcSp003Service
    {
        #region 获取数据

        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="pagination">分页参烽</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<BpeSC001Entity> GetPageList(Pagination pagination, string queryJson);

        IEnumerable<RowColSettingModel> GetRowColPageList(Pagination pagination, string queryJson);

        IEnumerable<BpcSp003Entity> GetList();

        IEnumerable<BpcSp003Entity> GetListByYear(string year);

        IEnumerable<BpcSp001Entity> GetTableListByYear(string year);
        /// <summary>
        /// 获取单个实体信息
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        BpcSp003Entity GetEntity(string keyValue);


         BpeSC001Entity GetActiveYearSetting();
        #endregion

        #region 提交数据

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="keyValue">主键</param>
        void DeleteRecord(string keyValue);


        void ModifyStatus(string keyValue, bool enabled);

        /// <summary>
        /// 保存记录
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        void SaveForm(BpcSp003Entity entity);

        void SaveForm(string year, List<BpcSp003Entity> entities);

        #endregion
    }
}
