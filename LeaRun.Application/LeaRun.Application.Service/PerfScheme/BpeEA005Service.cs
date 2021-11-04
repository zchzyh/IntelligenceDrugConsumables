using LeaRun.Application.Entity.PerfScheme;
using LeaRun.Application.IService.PerfScheme;
using LeaRun.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Service.PerfScheme
{
    /// <summary>
    /// 指标权重设置
    /// </summary>
    public class BpeEA005Service : RepositoryFactory<BpeEA005Entity>, IBpeEA005Service
    {
        #region 获取数据
        /// <summary>
        /// 指标权重设置实体
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <returns></returns>
        public BpeEA005Entity GetEntity(string keyvalue)
        {
            return this.HQPASRepository().FindEntity(keyvalue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除指标权重设置信息
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        public void RemoveForm(string keyvalue)
        {
            this.HQPASRepository().Delete(keyvalue);
        }
        /// <summary>
        /// 保存指标权重设置表单（新增、修改）
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <param name="entity">指标权重设置实体</param>
        /// <returns></returns>
        public void SaveForm(string keyvalue, BpeEA005Entity entity)
        {
            if (!string.IsNullOrEmpty(keyvalue))
            {
                entity.Modify(keyvalue);
                this.HQPASRepository().Update(entity);
            }
            else
            {
                entity.Create();
                this.HQPASRepository().Insert(entity);
            }
        }
        #endregion
    }
}