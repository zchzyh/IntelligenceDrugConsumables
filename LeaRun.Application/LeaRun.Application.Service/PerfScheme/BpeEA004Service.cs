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
    /// 评价方法明细
    /// </summary>
    public class BpeEA004Service : RepositoryFactory<BpeEA004Entity>, IBpeEA004Service
    {
        #region 获取数据
        /// <summary>
        /// 评价方法明细实体
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <returns></returns>
        public BpeEA004Entity GetEntity(string keyvalue)
        {
            return this.HQPASRepository().FindEntity(keyvalue);
        }
        /// <summary>
        /// 评价方法明细实体
        /// </summary>
        /// <param name="jgfabh">部门方案编号</param>
        /// <returns></returns>
        public BpeEA004Entity GetEntityByJGFABH(string jgfabh)
        {
            return this.HQPASRepository().FindEntity(e => e.JGFABH == jgfabh);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除评价方法明细信息
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        public void RemoveForm(string keyvalue)
        {
            this.HQPASRepository().Delete(keyvalue);
        }
        /// <summary>
        /// 保存评价方法明细表单（新增、修改）
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <param name="entity">评价方法明细实体</param>
        /// <returns></returns>
        public void SaveForm(string keyvalue, BpeEA004Entity entity)
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