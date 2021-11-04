using LeaRun.Application.Code;
using LeaRun.Application.Entity.PerfScheme;
using LeaRun.Application.Entity.PerfGoal;
using LeaRun.Application.IService.PerfScheme;
using LeaRun.Application.IService.PerfGoal;
using LeaRun.Data;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Service.PerfScheme
{
    /// <summary>
    /// 绩效方案明细表
    /// </summary>
    public class BpePA002Service : RepositoryFactory<BpePA002Entity>, IBpePA002Service
    {
        /// <summary>
        /// 删除某个方案的所有明细
        /// </summary>
        /// <param name="strFabh"></param>
        public void DelDataByFABH(string strFabh)
        {
            this.HQPASRepository().Delete(e => e.FABH == strFabh);
        }
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="entities"></param>
        public void InsertList(List<BpePA002Entity> entities)
        {
            foreach (var entity in entities)
            {
                entity.Create();
                this.HQPASRepository().Insert(entity);
            }
        }
        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="entities"></param>
        public void UpdateList(List<BpePA002Entity> entities)
        {
            foreach (var entity in entities)
            {
                this.HQPASRepository().Update(entity);
            }
        }

        /// <summary>
        /// 获取某个方案明细
        /// </summary>
        /// <param name="fabh"></param>
        /// <returns></returns>
        public List<BpePA002Entity> GetList(string fabh)
        {
            return HQPASRepository().IQueryable().Where(b2 => b2.FABH == fabh).ToList();
        }
    }
}
