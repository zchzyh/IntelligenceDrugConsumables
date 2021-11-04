using LeaRun.Application.Entity.PerfScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.PerfScheme
{
    /// <summary>
    /// 指标权重设置
    /// </summary>
    public interface IBpeEA005Service
    {
        #region 获取数据
        /// <summary>
        /// 指标权重设置实体
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <returns></returns>
        BpeEA005Entity GetEntity(string keyvalue);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除指标权重设置
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        void RemoveForm(string keyvalue);
        /// <summary>
        /// 保存指标权重设置表单（新增、修改）
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <param name="entity">指标权重设置实体</param>
        /// <returns></returns>
        void SaveForm(string keyvalue, BpeEA005Entity entity);
        #endregion
    }
}