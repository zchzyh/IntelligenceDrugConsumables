using System;
using System.Collections.Generic;
using System.Linq;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.IService.CollectionManage;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;

namespace LeaRun.Application.Service.CollectionManage
{
    /// <summary>
    /// 行项目信息管理表
    /// </summary>
    public class BpcSc001Service : RepositoryFactory<BpcSc001Entity>, IBpcSc001Service
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void DeleteRecord(string keyValue)
        {
            HQPASRepository().Delete(keyValue);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public BpcSc001Entity GetEntity(string keyValue)
        {
            return HQPASRepository().FindEntity(keyValue);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BpcSc001Entity> GetList(string rowName)
        {
            try
            {
                var expression = LinqExtensions.True<BpcSc001Entity>();
                if (!rowName.IsEmpty())
                    expression = expression.And(t => t.NAME.Contains(rowName));
                return HQPASRepository().IQueryable(expression).ToList();
            }
            catch (Exception ex)
            {

            }

            return null;
        }
        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<BpcSc001Entity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<BpcSc001Entity>();
            var queryParam = queryJson.ToJObject();
            if (!queryParam["rowName"].IsEmpty())
            {
                string rowName = queryParam["rowName"].ToString();
                expression = expression.And(t => t.NAME == rowName);
            }
            if (!queryParam["isDictionary"].IsEmpty())
            {
                string isDictionary = queryParam["isDictionary"].ToString();
                expression = expression.And(t => t.SFZD == isDictionary);
            }
            if (!queryParam["status"].IsEmpty())
            {
                string status = queryParam["status"].ToString();
                expression = expression.And(t => t.STATUS == status);
            }

            return HQPASRepository().FindList(expression, pagination);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="enabled"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void ModifyStatus(string keyValue, bool enabled)
        {
            var entity = GetEntity(keyValue);
            entity.Modify(keyValue);
            entity.STATUS = enabled ? "1" : "0";
            HQPASRepository().Update(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void SaveForm(BpcSc001Entity entity)
        {
            if (!string.IsNullOrEmpty(entity.HXBM))
            {
                entity.Modify(entity.HXBM);
                HQPASRepository().Update(entity);
            }
            else
            {
                entity.Create();
                HQPASRepository().Insert(entity);
            }
        }
    }
}
