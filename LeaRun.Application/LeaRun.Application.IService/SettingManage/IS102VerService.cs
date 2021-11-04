using LeaRun.Application.Entity.SettingManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.SettingManage
{
    /// <summary>
    /// 基础数据版本
    /// </summary>
    public interface IS102VerService
    {
        #region 获取数据
        /// <summary>
        /// 基础数据版本列表
        /// </summary>
        /// <param name="typeId">查询参数</param>
        /// <returns></returns>
        IEnumerable<S102VerEntity> GetList(string typeId);
        /// <summary>
        /// 基础数据版本实体
        /// </summary>
        /// <param name="keyValues">主键值</param>
        /// <returns></returns>
        S102VerEntity GetEntity(string typeId, string verId);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除基础数据版本
        /// </summary>
        /// <param name="typeId">主键</param>
        /// <param name="verId">主键</param>
        void RemoveForm(string typeId, string verId);
        /// <summary>
        /// 保存基础数据版本表单（新增、修改）
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="verId"></param>
        /// <param name="s102VerEntity">基础数据版本实体</param>
        /// <returns></returns>
        void SaveForm(string typeId, string verId, S102VerEntity s102VerEntity);
        #endregion
    }
}