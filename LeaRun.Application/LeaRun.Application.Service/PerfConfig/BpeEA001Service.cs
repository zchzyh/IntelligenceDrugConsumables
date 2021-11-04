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
    /// 指标等级表
    /// </summary>
    public class BpeEA001Service : RepositoryFactory<BpeEA001Entity>, IBpeEA001Service
    {
        /// <summary>
        /// 获取指标等级实体
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        public BpeEA001Entity GetEntity(string xh)
        {
            return this.HQPASRepository().FindEntity(e => e.XH == xh);
        }
        /// <summary>
        /// 保存指标等级实体
        /// </summary>
        /// <param name="xh"></param>
        /// <param name="entity"></param>
        public void SaveForm(string xh, BpeEA001Entity entity)
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
        /// 删除指标等级
        /// </summary>
        /// <param name="xh"></param>
        public void RemoveForm(string xh)
        {
            this.HQPASRepository().Delete(e => e.XH == xh);
        }
    }
}
