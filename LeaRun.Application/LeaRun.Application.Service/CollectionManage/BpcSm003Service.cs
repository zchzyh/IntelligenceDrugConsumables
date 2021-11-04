using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.IService.CollectionManage;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Linq;

namespace LeaRun.Application.Service.CollectionManage
{
    /// <summary>
    /// 
    /// </summary>
    public class BpcSm003Service : RepositoryFactory<BpcSm003Entity>, IBpcSm003Service
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public BpcSm003Entity GetEntity(string keyValue)
        {
            return HQPASRepository().FindEntity(keyValue);
        }

        public IEnumerable<BpcSm003Entity> GetList(string year,string plbh)
        {
            var expression = LinqExtensions.True<BpcSm003Entity>();
            if (!year.IsEmpty())
            {
                expression = expression.And(t => t.ND == year);
            }
            if (!plbh.IsEmpty())
            {
                expression = expression.And(t => t.PLBH == plbh);
            }
            return HQPASRepository().IQueryable(expression);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<BpcSm003Entity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<BpcSm003Entity>();
            var queryParam = queryJson.ToJObject();
            if (!queryParam["ND"].IsEmpty())
            {
                string nd = queryParam["ND"].ToString();
                expression = expression.And(t => t.ND == nd);
            }

            if (!queryParam["STATUS"].IsEmpty())
            {
                string status = queryParam["STATUS"].ToString();
                expression = expression.And(t => t.STATUS == status);
            }
      
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
        public void AddOrUpdateRecord(BpcSm003Entity entity)
        {
            if (!string.IsNullOrEmpty(entity.XH))
            {
                entity.Modify(entity.XH);
                HQPASRepository().Update(entity);
            }
            else
            {
                entity.Create();
                HQPASRepository().Insert(entity);
            }
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="enabled">状态</param>
        public void ModifyStatus(string keyValue, bool enabled)
        {
            var entity = GetEntity(keyValue);
            entity.Modify(keyValue);
            entity.STATUS = enabled ? "1" : "0";
            HQPASRepository().Update(entity);
        }

        public bool ExistsRecord(string year, string value)
        {
            return HQPASRepository().IQueryable().Any(m => m.ND == year && m.PLBH == value);
        }
    }
}