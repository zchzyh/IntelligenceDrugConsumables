﻿using LeaRun.Application.Entity.SettingManage;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.SettingManage
{
    /// <summary>
    /// 维度基本信息
    /// </summary>
    public interface IBpeVA002Service
    {
        #region 获取数据
        /// <summary>
        /// 维度基本信息列表
        /// </summary>
        /// <param name="pagination">分页信息</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<BpeVA002Entity> GetList(Pagination pagination, string queryJson);
        /// <summary>
        /// 维度基本信息实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        BpeVA002Entity GetEntity(string keyValue);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除维度基本信息
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveForm(string keyValue);
        /// <summary>
        /// 保存维度基本信息表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">维度基本信息实体</param>
        /// <returns></returns>
        void SaveForm(string keyValue, BpeVA002Entity entity);
        #endregion
    }
}