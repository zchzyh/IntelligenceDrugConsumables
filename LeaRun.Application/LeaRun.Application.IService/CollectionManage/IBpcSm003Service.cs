using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Util.WebControl;
using System.Collections.Generic;

namespace LeaRun.Application.IService.CollectionManage
{
    /// <summary>
    /// 采集频率表
    /// </summary>
    public interface IBpcSm003Service
    {
        #region 获取数据

        /// <summary>
        /// 获取采集频率列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<BpcSm003Entity> GetPageList(Pagination pagination, string queryJson);

        /// <summary>
        /// 获取采集频率列表
        /// </summary>
        /// <param name="year">年度</param>
        /// <param name="plbh">频率编号</param>
        /// <returns></returns>
        IEnumerable<BpcSm003Entity> GetList(string year, string plbh);
        /// <summary>
        /// 获取单个采集频率信息
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        BpcSm003Entity GetEntity(string keyValue);
        #endregion

        #region 提交数据

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="keyValue">序号</param>
        void DelRecord(string keyValue);


        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="enabled"></param>
        void ModifyStatus(string keyValue, bool enabled);

        /// <summary>
        /// 保存记录（新增、修改）
        /// </summary>
        /// <param name="entity">频率实体类</param>
        /// <returns></returns>
        void AddOrUpdateRecord(BpcSm003Entity entity);

        /// <summary>
        /// 检查指定年度频率是否存在
        /// </summary>
        /// <param name="year">年度</param>
        /// <param name="value">频率值</param>
        /// <returns></returns>
        bool ExistsRecord(string year,string value);

        #endregion
    }
}