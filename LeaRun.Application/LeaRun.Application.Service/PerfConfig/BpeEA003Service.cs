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
    /// 评价方法表
    /// </summary>
    public class BpeEA003Service : RepositoryFactory<BpeEA003Entity>, IBpeEA003Service
    {
        /// <summary>
        /// 获取评价方法实体
        /// </summary>
        /// <param name="pjffbh"></param>
        /// <returns></returns>
        public BpeEA003Entity GetEntity(string pjffbh)
        {
            return this.HQPASRepository().FindEntity(e => e.PJFFBH == pjffbh);
        }
        /// <summary>
        /// 保存评价方法实体
        /// </summary>
        /// <param name="pjffbh"></param>
        /// <param name="entity"></param>
        public void SaveForm(string pjffbh, BpeEA003Entity entity)
        {
            if (!string.IsNullOrEmpty(pjffbh))
            {
                entity.Modify(new string[] { pjffbh});
                this.HQPASRepository().Update(entity);
            }
            else
            {
                entity.Create();
                this.HQPASRepository().Insert(entity);
            }
        }
        /// <summary>
        /// 删除评价方法实体
        /// </summary>
        /// <param name="pjffbhe"></param>
        public void RemoveForm(string pjffbhe)
        {
            this.HQPASRepository().Delete(e => e.PJFFBH == pjffbhe);
        }
    }
}
