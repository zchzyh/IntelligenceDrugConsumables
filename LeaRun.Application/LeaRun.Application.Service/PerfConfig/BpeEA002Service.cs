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
    /// 综合等级表
    /// </summary>
    public class BpeEA002Service : RepositoryFactory<BpeEA002Entity>, IBpeEA002Service
    {
        /// <summary>
        /// 获取综合等级实体
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        public BpeEA002Entity GetEntity(string xh)
        {
            return this.HQPASRepository().FindEntity(e => e.XH == xh);
        }
        /// <summary>
        /// 保存综合等级实体
        /// </summary>
        /// <param name="xh"></param>
        /// <param name="entity"></param>
        public void SaveForm(string xh, BpeEA002Entity entity)
        {
            if (!string.IsNullOrEmpty(xh))
            {
                entity.Modify(new string[] { xh });
                this.HQPASRepository().Update(entity);
            }
            else
            {
                entity.Create();
                this.HQPASRepository().Insert(entity);
            }
        }
        /// <summary>
        /// 删除综合等级
        /// </summary>
        /// <param name="xh"></param>
        public void RemoveForm(string xh)
        {
            this.HQPASRepository().Delete(e => e.XH == xh);
        }
    }
}
