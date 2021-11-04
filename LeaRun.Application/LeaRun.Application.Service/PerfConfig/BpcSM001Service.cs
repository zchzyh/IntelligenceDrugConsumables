using LeaRun.Application.Entity.PerfConfig;
using LeaRun.Application.IService.PerfConfig;
using LeaRun.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Service.PerfConfig
{
    /// <summary>
    /// 数据项基本信息
    /// </summary>
    public class BpcSM001Service : RepositoryFactory<BpcSM001Entity>, IBpcSM001Service
    {
        #region 获取数据
        /// <summary>
        /// 数据项基本信息实体
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <returns></returns>
        public BpcSM001Entity GetEntity(string keyvalue)
        {
            return this.HQPASRepository().FindEntity(keyvalue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据项基本信息信息
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        public void RemoveForm(string keyvalue)
        {
            this.HQPASRepository().Delete(keyvalue);
        }
        /// <summary>
        /// 保存数据项基本信息表单（新增、修改）
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <param name="entity">数据项基本信息实体</param>
        /// <returns></returns>
        public void SaveForm(string keyvalue, BpcSM001Entity entity)
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