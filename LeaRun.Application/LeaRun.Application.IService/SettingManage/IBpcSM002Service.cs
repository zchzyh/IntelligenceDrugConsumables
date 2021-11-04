using LeaRun.Application.Entity.SettingManage;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.SettingManage
{
    /// <summary>
    /// 数据项分类信息
    /// </summary>
    public interface IBpcSM002Service
    {
        #region 获取数据
        /// <summary>
        /// 数据项分类信息列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<BpcSM002Entity> GetList(string queryJson);
        /// <summary>
        /// 数据项分类信息列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<BpcSM002Entity> GetList(Pagination pagination, string queryJson);
        /// <summary>
        /// 数据项分类信息实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        BpcSM002Entity GetEntity(string keyValue);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据项分类信息
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveForm(string keyValue);
        /// <summary>
        /// 保存数据项分类信息表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">数据项分类信息实体</param>
        /// <returns></returns>
        void SaveForm(string keyValue, BpcSM002Entity entity);
        #endregion
    }
}