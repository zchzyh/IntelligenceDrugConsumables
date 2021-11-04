using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Util.WebControl;
using System.Collections.Generic;

namespace LeaRun.Application.IService.CollectionManage
{
    /// <summary>
    /// 采集任务参数表
    /// </summary>
    public interface IBpcSp008Service
    {
        #region 获取数据

        IEnumerable<BpcSp008Entity> GetPageList(Pagination pagination, string queryJson);


        IEnumerable<BpcSp008Entity> GetList();


        BpcSp008Entity GetEntity(string keyValue);

        #endregion

        #region 提交数据

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="keyValue">序号</param>
        void DeleteRecord(string keyValue);

        /// <summary>
        /// 添加或删除记录
        /// </summary>
        /// <param name="entity"></param>
        void AddOrUpdateRecord(BpcSp008Entity entity);


        /// <summary>
        /// 添加或删除记录
        /// </summary>
        void AddOrUpdateRecords(string orgId, string officeCode,List<BpcSp008Entity> entities);

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="officeCode"></param>
        /// <returns></returns>
        bool ExistsRecord(string officeCode);


        bool ExistsRecord(string orgId, string officeCode, List<BpcSp008Entity> entities,
            out BpcSp008Entity existEntity);

        #endregion
    }
}