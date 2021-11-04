using System;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Util.WebControl;
using System.Collections.Generic;

namespace LeaRun.Application.IService.CollectionManage
{
    /// <summary>
    /// 采集基本信息表
    /// </summary>
    public interface IBpcSp001Service
    {
        #region 获取数据

        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="pagination">分页参烽</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<BpcSp001Entity> GetPageList(Pagination pagination, string queryJson);

        IEnumerable<BpcSp001Entity> GetList();

        /// <summary>
        /// 获取单个实体信息
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        BpcSp001Entity GetEntity(string keyValue);

        int GetTableCountByCategory(string category);
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
        void SaveForm(BpcSp001Entity entity);

        #endregion
    }
}