using System;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.IService.CollectionManage;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LeaRun.Application.Service.CollectionManage
{
    /// <summary>
    /// 
    /// </summary>
    public class BpcSp008Service : RepositoryFactory<BpcSp008Entity>, IBpcSp008Service
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public BpcSp008Entity GetEntity(string keyValue)
        {
            return HQPASRepository().FindEntity(keyValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BpcSp008Entity> GetList()
        {
            var expression = LinqExtensions.True<BpcSp008Entity>();
            return HQPASRepository().IQueryable(expression);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<BpcSp008Entity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<BpcSp008Entity>();
            var queryParam = queryJson.ToJObject();
            return HQPASRepository().FindList(expression, pagination);
        }


        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="keyValue"></param>
        public void DelRecord(string keyValue)
        {
            HQPASRepository().Delete(keyValue);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="entity"></param>
        public void AddOrUpdateRecord(BpcSp008Entity entity)
        {
            if (!string.IsNullOrEmpty(entity.CJBBM))
            {
                entity.Modify(entity.CJBBM);
                HQPASRepository().Update(entity);
            }
            else
            {
                entity.Create();
                HQPASRepository().Insert(entity);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="officeCode"></param>
        /// <param name="entities"></param>
        /// <param name="orgId"></param>
        public void AddOrUpdateRecords(string orgId, string officeCode, List<BpcSp008Entity> entities)
        {
            var deletedEntities = HQPASRepository().IQueryable().Where(t => t.OrgId == orgId && t.DWCSBM==officeCode).ToList();
            IRepository db = new RepositoryFactory().HQPASRepository().BeginTrans();
            try
            {
                int result = db.Delete(deletedEntities);
                db.Insert(entities);
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }

        /// <returns></returns>
        public bool ExistsRecord(string officeCode)
        {
            return HQPASRepository().IQueryable().Any(m => m.DWCSBM == officeCode);
        }

        public bool ExistsRecord(string orgId,string officeId, List<BpcSp008Entity> entities, out BpcSp008Entity existEntity)
        {
            existEntity = null;
            if (entities.Count < 1) return false;
            var list = GetList().ToList();

            foreach (var e in entities)
            {
                var entity = list.Find(t => t.CJBBM == e.CJBBM && t.DWCSBM != officeId);
                if (entity != null) { existEntity = entity; return true; }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        public void DeleteRecord(string keyValue)
        {
            HQPASRepository().Delete(keyValue);
        }

       
    }
}