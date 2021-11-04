using LeaRun.Application.Entity.PerfConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.PerfConfig
{
    /// <summary>
    /// 数据项基本信息
    /// </summary>
    public interface IBpcSM001Service
    {
        #region 获取数据
        /// <summary>
        /// 数据项基本信息实体
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <returns></returns>
        BpcSM001Entity GetEntity(string keyvalue);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据项基本信息
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        void RemoveForm(string keyvalue);
        /// <summary>
        /// 保存数据项基本信息表单（新增、修改）
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <param name="entity">数据项基本信息实体</param>
        /// <returns></returns>
        void SaveForm(string keyvalue, BpcSM001Entity entity);
        #endregion
    }
}