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
    /// 基础数据分类
    /// </summary>
    public interface IS101TypeService
    {
        #region 获取数据
        /// <summary>
        /// 基础数据分类列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<S101TypeEntity> GetList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取所有标准编码类别
        /// </summary>
        /// <returns></returns>
        IEnumerable<S101TypeEntity> GetList();
        /// <summary>
        /// 基础数据分类实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        S101TypeEntity GetEntity(string keyValue);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除基础数据分类
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveForm(string keyValue);
        /// <summary>
        /// 保存基础数据分类表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="s101TypeEntity">基础数据分类实体</param>
        /// <returns></returns>
        void SaveForm(string keyValue, S101TypeEntity s101TypeEntity);
        #endregion
    }
}