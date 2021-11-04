using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.Entity.CollectionManage.ViewModel;
using LeaRun.Application.IService.CollectionManage;
using LeaRun.Data;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;

namespace LeaRun.Application.Service.CollectionManage
{
    /// <summary>
    /// 采集纵向关系表
    /// </summary>
    public class BpcSc002Service : RepositoryFactory<BpcSc002Entity>, IBpcSc002Service
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
        public BpcSc002Entity GetEntity(string keyValue)
        {
            return HQPASRepository().FindEntity(keyValue);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BpcSc002Entity> GetList(string year,string tbBm)
        {
            var expression = LinqExtensions.True<BpcSc002Entity>();
            expression = expression.And(t => t.ND == year);
            expression = expression.And(t => t.CJBBM == tbBm);
            return HQPASRepository().IQueryable(expression);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<BpcSc002Entity> GetList(string year)
        {
            var expression = LinqExtensions.True<BpcSc002Entity>();
            expression = expression.And(t => t.ND == year);
            return HQPASRepository().IQueryable(expression);
        }

        /// <summary>
        /// 取行排序数据
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<TableRowModel> GetRowDataSort(Pagination pagination, string queryJson)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            var expression = LinqExtensions.True<TableRowModel>();
            var queryParam = queryJson.ToJObject();

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(@"SELECT A.HXBM,
                                   B.NAME AS RowName,
                                   A.CJBBM,
                                   B.SFZD,B.PX
                            FROM   bpms.BPC_SC002 A
                                   INNER JOIN bpms.BPC_SC001 B
                                           ON A.HXBM = B.HXBM
where 1=1");
            if (!queryParam["tbBm"].IsEmpty())
            {
                sbSql.Append(" and A.CJBBM=@CJBBM");
                parameter.Add(DbParameters.CreateDbParameter("@CJBBM", queryParam["tbBm"].ToString()));
            }
            if (!queryParam["year"].IsEmpty())
            {
                sbSql.Append(" and A.ND=@ND");
                parameter.Add(DbParameters.CreateDbParameter("@ND", queryParam["year"].ToString()));
            }
            return new RepositoryFactory().HQPASRepository()
                .FindList<TableRowModel>(sbSql.ToString(), parameter.ToArray(), pagination);
        }
        ///// <summary>
        ///// 分页获取列表
        ///// </summary>
        ///// <param name="pagination"></param>
        ///// <param name="queryJson"></param>
        ///// <returns></returns>
        ///// <exception cref="NotImplementedException"></exception>
        //public IEnumerable<BpcSc002Entity> GetPageList(Pagination pagination, string queryJson)
        //{
        //    var expression = LinqExtensions.True<BpcSc002Entity>();
        //    var queryParam = queryJson.ToJObject();
        //    if (!queryParam["rowName"].IsEmpty())
        //    {
        //        string rowName = queryParam["rowName"].ToString();
        //        expression = expression.And(t => t.NAME == rowName);
        //    }
        //    if (!queryParam["isDictionary"].IsEmpty())
        //    {
        //        string isDictionary = queryParam["isDictionary"].ToString();
        //        expression = expression.And(t => t.SFZD == isDictionary);
        //    }
        //    if (!queryParam["status"].IsEmpty())
        //    {
        //        string status = queryParam["status"].ToString();
        //        expression = expression.And(t => t.STATUS == status);
        //    }

        //    return HQPASRepository().FindList(expression, pagination);
        //}

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
        /// <param name="year"></param>
        /// <param name="entities"></param>
        public void SaveData(string year, List<BpcSc002Entity> entities)
        {
            var deletedEntities = HQPASRepository().IQueryable().Where(t =>  t.ND==year).ToList();
            IRepository db = new RepositoryFactory().HQPASRepository().BeginTrans();
            try
            {
                int result = db.Delete(deletedEntities);
                foreach (var e in entities)
                {
                    e.Create();
                    Thread.Sleep(5);
                }

                db.Insert(entities);
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="tbBm"></param>
        /// <param name="entities"></param>
        public void SaveData(string year, string tbBm, List<BpcSc002Entity> entities)
        {
            var deletedEntities = HQPASRepository().IQueryable().Where(t => t.ND == year && t.CJBBM==tbBm).ToList();
            IRepository db = new RepositoryFactory().HQPASRepository().BeginTrans();
            try
            {
                int result = db.Delete(deletedEntities);
                foreach (var e in entities)
                {
                    e.Create();
                    Thread.Sleep(5);
                }

                db.Insert(entities);
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <exception cref="NotImplementedException"></exception>
        //public void SaveData(BpcSc002Entity entity)
        //{
        //    if (!string.IsNullOrEmpty(entity.HXBM))
        //    {
        //        entity.Modify(entity.HXBM);
        //        HQPASRepository().Update(entity);
        //    }
        //    else
        //    {
        //        entity.Create();
        //        HQPASRepository().Insert(entity);
        //    }
        //}
    }
}