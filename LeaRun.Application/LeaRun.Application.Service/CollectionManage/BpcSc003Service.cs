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
    public class BpcSc003Service : RepositoryFactory<BpcSc003Entity>, IBpcSc003Service
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param> 
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
        public BpcSc003Entity GetEntity(string keyValue)
        {
            return HQPASRepository().FindEntity(keyValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="tableNo"></param>
        /// <returns></returns>
        public IEnumerable<MyTableHeaderModel> GetTableHeader(string year, string tableNo)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT [LBM]
                                    ,[LMC]
                                    ,[LCODE]
                                    ,[EDITABLE]
                                    ,[AUTOWIDTH]
                                    ,[WIDTH]
                                    ,[TYPE]
                                    ,[TEXTALIGN]
                                    ,[FORMATSTR]
                                    ,[ISMERGE]
                                    ,[VISIBLE]
                                    ,[INDEXNUM]
                            FROM [HQPAS].[BPMS].[BPC_SC003] WITH (NOLOCK)
                            WHERE [STATUS] = '1'
                            AND [CJBBM] = @CJBBM
                            AND [ND] = @ND ORDER BY INDEXNUM ASC");

            parameter.Add(DbParameters.CreateDbParameter("@CJBBM", tableNo));
            parameter.Add(DbParameters.CreateDbParameter("@ND", year));
            return new RepositoryFactory().HQPASRepository()
                .FindList<MyTableHeaderModel>(strSql.ToString(), parameter.ToArray());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="tableNo"></param>
        /// <returns></returns>
        public IEnumerable<MyTableRowModel> GetTableRow(string year, string tableNo)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT C1.[HXBM]
                                    ,C1.[NAME]
                                    ,C1.[SFZD]
                                    ,C1.[HCODE]
                                    ,C1.[PARENT]
                                    ,C1.[GRADE]
                                    ,C1.[PX]
                            FROM [HQPAS].[BPMS].[BPC_SC001] C1 WITH (NOLOCK)
                            LEFT JOIN [HQPAS].[BPMS].[BPC_SC002] C2 WITH (NOLOCK)
                            ON C1.[HXBM] = C2.[HXBM]
                            AND C1.[STATUS] = C2.[STATUS]
                            WHERE C1.[STATUS] = '1'
                            AND C2.[CJBBM] = @CJBBM
                            AND C2.[ND] = @ND");

            parameter.Add(DbParameters.CreateDbParameter("@CJBBM", tableNo));
            parameter.Add(DbParameters.CreateDbParameter("@ND", year));
            return new RepositoryFactory().HQPASRepository()
                .FindList<MyTableRowModel>(strSql.ToString(), parameter.ToArray());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="year"></param>
        /// <param name="tbBm"></param>
        /// <returns></returns>
        public IEnumerable<BpcSc003Entity> GetList(Pagination pagination, string year, string tbBm)
        {
            var expression = LinqExtensions.True<BpcSc003Entity>();
            expression = expression.And(t => t.ND == year && t.CJBBM==tbBm);
            return HQPASRepository().FindList(expression, pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BpcSc003Entity> GetList(string year, string tbBm)
        {
            var expression = LinqExtensions.True<BpcSc003Entity>();
            expression = expression.And(t => t.CJBBM == tbBm && t.ND==year);
            return HQPASRepository().IQueryable(expression);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public IEnumerable<BpcSc003Entity> GetList(string year)
        {
            var expression = LinqExtensions.True<BpcSc003Entity>();
            expression = expression.And(t => t.ND == year);
            return HQPASRepository().IQueryable(expression);
        }
        /// <summary>
        /// 取行排序数据
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="tbBm"></param>
        /// <returns></returns>
        public IEnumerable<BpcSc003Entity> GetColSetting(Pagination pagination, string tbBm)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            var expression = LinqExtensions.True<BpcSc003Entity>();
            expression = expression.And(t => t.CJBBM == tbBm);
            return HQPASRepository().FindList(expression, pagination);
            //            StringBuilder sbSql = new StringBuilder();
            //            sbSql.Append(@"SELECT A.HXBM,
            //                                   b.NAME AS RowName,
            //                                   A.CJBBM,
            //                                   b.SFZD,A.PX
            //                            FROM   bpms.BPC_SC002 A
            //                                   INNER JOIN bpms.BPC_SC001 B
            //                                           ON A.HXBM = b.HXBM
            //where 1=1
            //");
            //            sbSql.Append(" and A.CJBBM=@CJBBM and B.SFZD=1");
            //            parameter.Add(DbParameters.CreateDbParameter("@CJBBM", tbBm));

            //return new RepositoryFactory().HQPASRepository()
            //    .FindList<BpcSc003Entity>(sbSql.ToString(), parameter.ToArray(), pagination);
        }
        ///// <summary>
        ///// 分页获取列表
        ///// </summary>
        ///// <param name="pagination"></param>
        ///// <param name="queryJson"></param>
        ///// <returns></returns>
        ///// <exception cref="NotImplementedException"></exception>
        //public IEnumerable<BpcSc003Entity> GetPageList(Pagination pagination, string queryJson)
        //{
        //    var expression = LinqExtensions.True<BpcSc003Entity>();
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
        /// <param name="entity"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void SaveData(BpcSc003Entity entity)
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
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="tbBm"></param>
        /// <param name="entities"></param>
        public void SaveData(string year, string tbBm, List<BpcSc003Entity> entities)
        {
            var deletedEntities = HQPASRepository().IQueryable().Where(t => t.CJBBM == tbBm && t.ND == year).ToList();
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
        /// <param name="entities"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void SaveData(string year, List<BpcSc003Entity> entities)
        {
            var deletedEntities = HQPASRepository().IQueryable().Where(t => t.ND == year).ToList();
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
    }
}