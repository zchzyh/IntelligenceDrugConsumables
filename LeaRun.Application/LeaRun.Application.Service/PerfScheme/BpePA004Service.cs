using LeaRun.Application.Entity.PerfScheme;
using LeaRun.Application.IService.PerfScheme;
using LeaRun.Data.Repository;
using System;
using System.Linq;
using System.Collections.Generic;

namespace LeaRun.Application.Service.PerfScheme
{
    /// <summary>
    /// 科室绩效明细表
    /// </summary>
    public class BpePA004Service : RepositoryFactory<BpePA004Entity>, IBpePA004Service
    {
        /// <summary>
        /// 删除某个方案的所有明细
        /// </summary>
        /// <param name="keyvalue"></param>
        public void DelDataByJGFABH(string strJgfabh)
        {
            this.HQPASRepository().Delete(e => e.JGFABH == strJgfabh);
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="entities"></param>
        public void InsertList(List<BpePA004Entity> entities)
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
        public void UpdateList(List<BpePA004Entity> entities)
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
        public List<BpePA004Entity> GetList(string jgfabh)
        {
            return HQPASRepository().IQueryable().Where(b2 => b2.JGFABH == jgfabh).ToList();
        }

        ///<summary>
        ///保存科室的方案指标列表
        ///</summary>
        public void SaveSchemeDepDetails(List<BpePA004Entity> kpis, string[] delFabh)
        {
            var deleteEntities = HQPASRepository().IQueryable().Where(t => delFabh.Contains(t.JGFABH)).ToList();
            IRepository db = new RepositoryFactory().HQPASRepository().BeginTrans();
            try
            {
                int result = db.Delete(deleteEntities);
                foreach (var entity in kpis)
                {
                    entity.Create();
                }
                db.Insert(kpis);
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
    }
}
