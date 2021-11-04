using System.Collections.Generic;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Util.WebControl;

namespace LeaRun.Application.IService.CollectionManage
{
    public interface IBpcSc001Service
    {
        #region 获取数据

        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="pagination">分页参烽</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<BpcSc001Entity> GetPageList(Pagination pagination, string queryJson);


        IEnumerable<BpcSc001Entity> GetList(string rowName);

        /// <summary>
        /// 获取单个实体信息
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        BpcSc001Entity GetEntity(string keyValue);

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
        void SaveForm(BpcSc001Entity entity);

        #endregion
    }
}