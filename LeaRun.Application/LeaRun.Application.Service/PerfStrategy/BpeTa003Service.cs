using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.Entity.CollectionManage.ViewModel;
using LeaRun.Application.Entity.PerfStrategy;
using LeaRun.Application.Entity.PerfStrategy.ViewModel;
using LeaRun.Application.IService.CollectionManage;
using LeaRun.Application.IService.PerfStrategy;
using LeaRun.Data;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;

namespace LeaRun.Application.Service.PerfStrategy
{
    /// <summary>
    /// 使命远景信息
    /// </summary>
    public class BpeTa003Service : RepositoryFactory<BpeTa003Entity>, IBpeTa003Service
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void AddOrUpdateRecord(BpeTa003Entity entity)
        {
            if (!string.IsNullOrEmpty(entity.CSFBH))
            {
                entity.Modify(entity.CSFBH);
                HQPASRepository().Update(entity);
            }
            else
            {
                entity.Create();
                HQPASRepository().Insert(entity);
            }
        }


        public void AddOrUpdateRecord(List<BpeTa003Entity> entities)
        {
            var deleteEntities = entities.FindAll(e => !e.XH.IsEmpty());
            var addEntities = entities.FindAll(e => e.XH.IsEmpty());
            //foreach (var entity in addEntities)
            //{
            //    entity.Create();
            //}
       
            IRepository db = new RepositoryFactory().HQPASRepository().BeginTrans();
            try
            {
                int result = db.Delete(deleteEntities);
                foreach (var e in addEntities)
                {
                    e.Create(); 
                }

                db.Insert(addEntities);
                db.Commit();
            }
            catch (Exception ex)
            {
                db.Rollback();
                throw;
            }
        }

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
        public BpeTa003Entity GetRecord(string keyValue)
        {
            return HQPASRepository().FindEntity(keyValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public BpeTa003Model GetRecordModel(string keyValue)
        {
            List<DbParameter> parameter = new List<DbParameter>(); 

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(@"  SELECT [CSFBH]
                                      ,VA004.[CSFMC]
                                      ,VA004.[ZTBH]
                                      ,VA004.[CREATOR]
                                      ,VA004.[CREATEAT]
                                      ,VA004.[MODIFOR]
                                      ,VA004.[MODIFYAT]
                                      ,VA004.[STATUS]
	                                  ,VA003.[ZTMC]
	                                  ,SC001.[JXND] AS [Year], SC001.[JXBM]
                                  FROM [HQPAS].[BPMS].[BPE_VA004] VA004
                                  INNER JOIN [BPMS].[BPE_VA003] VA003 ON VA004.ZTBH=VA003.ZTBH
                                  INNER JOIN [BPMS].[BPE_VA001] VA001 ON VA001.SMBH=VA003.SMBH
                                  INNER JOIN [BPMS].[BPE_SC001] SC001 ON SC001.JXBM=VA001.JXBM
                      WHERE 1=1");


            if (!keyValue.IsEmpty())
            {
                sbSql.Append(" AND VA004.[CSFBH] = @CSFBH ");
                parameter.Add(DbParameters.CreateDbParameter("@CSFBH", keyValue));
            }
            return new RepositoryFactory().HQPASRepository().FindList<BpeTa003Model>(sbSql.ToString(), parameter.ToArray()).FirstOrDefault();
        }


        IEnumerable<BpeTa003Model> IBpeTa003Service.GetPageList(Pagination pagination, string queryJson)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            var expression = LinqExtensions.True<RowColSettingModel>();

            StringBuilder sbSql = new StringBuilder();
         //   sbSql.Append(@"  SELECT TA003.[XH]
         //                         ,TA003.[KPIBH]
         //                         ,TA003.[CSFBH]
         //                         ,TA003.[JXBM]
         //                         ,TA003.[CREATOR]
         //                         ,TA003.[CREATEAT]
         //                         ,TA003.[MODIFOR]
         //                         ,TA003.[MODIFYAT]
         //                         ,TA003.[STATUS]
	        //                      ,VA002.[BSCMC]
	        //                      ,VA004.[CSFMC]
	        //                      ,VA003.[ZTMC]
	        //                      ,TA001.[ZBMC]
         //                         ,TA001.[ZBBH]
         //                         ,SC001.[JXND]
         //                     FROM [HQPAS].[BPMS].[BPE_TA003] TA003 
         //                     INNER JOIN [BPMS].[BPE_VA004] VA004 ON TA003.CSFBH=VA004.CSFBH
         //                     INNER JOIN [BPMS].[BPE_VA003] VA003 ON VA003.ZTBH=VA004.ZTBH
         //                     INNER JOIN [BPMS].[BPE_VA002] VA002 ON VA002.BSCBH=VA003.BSCBH
							  //INNER JOIN [BPMS].[BPE_TA002] TA002 ON TA002.KPIBH=TA003.KPIBH
         //                     INNER JOIN[BPMS].[BPE_TA001] TA001 ON  TA003.JXBM=TA001.JXBM AND  TA001.ZBBH=TA002.ZBBH
         //                     INNER JOIN [BPMS].[BPE_SC001]SC001 ON SC001.JXBM=TA003.JXBM
         //                                         WHERE 1=1");
            sbSql.Append(@"  SELECT TA003.[XH]
                                  ,TA003.[KPIBH]
                                  ,TA003.[CSFBH]
                                  ,TA003.[JXBM]
                                  ,TA003.[CREATOR]
                                  ,TA003.[CREATEAT]
                                  ,TA003.[MODIFOR]
                                  ,TA003.[MODIFYAT]
                                  ,TA003.[STATUS]
	                              ,VA002.[BSCMC]
	                              ,VA004.[CSFMC]
	                              ,VA003.[ZTMC]
	                              ,TA001.[ZBMC]
                                  ,TA001.[ZBBH]
                                  ,SC001.[JXND]
                              FROM [HQPAS].[BPMS].[BPE_TA003] TA003 
                              INNER JOIN [BPMS].[BPE_VA004] VA004 ON TA003.CSFBH=VA004.CSFBH
                              INNER JOIN [BPMS].[BPE_VA003] VA003 ON VA003.ZTBH=VA004.ZTBH
                              INNER JOIN [BPMS].[BPE_VA002] VA002 ON VA002.BSCBH=VA003.BSCBH
							  INNER JOIN [BPMS].[BPE_TA002] TA002 ON TA002.KPIBH=TA003.KPIBH
                              INNER JOIN[BPMS].[KPIALL] TA001 ON  TA003.JXBM=TA001.JXBM AND  TA001.ZBBH=TA002.ZBBH
                              INNER JOIN [BPMS].[BPE_SC001]SC001 ON SC001.JXBM=TA003.JXBM
                                                  WHERE 1=1");

            var queryParam = queryJson.ToJObject();
            if (!queryParam["jxbm"].IsEmpty())
            {
                sbSql.Append(" AND TA003.[JXBM] = @jxbm ");
                parameter.Add(DbParameters.CreateDbParameter("@jxbm", queryParam["jxbm"].ToString()));
            }
            if (!queryParam["zbmc"].IsEmpty())
            {
                sbSql.Append(" AND TA001.[ZBMC] LIKE @zbmc ");
                parameter.Add(DbParameters.CreateDbParameter("@zbmc", '%' + queryParam["zbmc"].ToString() + '%'));
            }
            if (!queryParam["csfbh"].IsEmpty())
            {
                sbSql.Append(" AND TA003.[CSFBH] = @csfbh ");
                parameter.Add(DbParameters.CreateDbParameter("@csfbh",  queryParam["csfbh"].ToString()));
            }
            return new RepositoryFactory().HQPASRepository()
                .FindList<BpeTa003Model>(sbSql.ToString(), parameter.ToArray(), pagination);
        }

        IEnumerable<BpeTa002Model> IBpeTa003Service.GetQuantifyPageList(Pagination pagination, string queryJson)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            var expression = LinqExtensions.True<RowColSettingModel>();
            StringBuilder sbSqlWhere = new StringBuilder();
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(@" SELECT 
	                             TA001.ZBMC,
	                             TA001.ZBBH,
                                 TA002.[CREATEAT],
                                 TA002.[KPIBH],TA002.[JXBM]
                            FROM [HQPAS].[BPMS].[BPE_TA002] TA002
                            INNER JOIN [BPMS].KPIALL TA001 ON TA001.JXBM=TA002.JXBM AND TA001.ZBBH=TA002.ZBBH
                            WHERE 1=1");


            var queryParam = queryJson.ToJObject();
            if (!queryParam["jxbm"].IsEmpty())
            {
                sbSql.Append(" AND TA002.[JXBM] = @jxbm ");
                parameter.Add(DbParameters.CreateDbParameter("@jxbm", queryParam["jxbm"].ToString()));
            }
            if (!queryParam["zbmc"].IsEmpty())
            {
                sbSql.Append(" AND TA001.[ZBMC] LIKE @zbmc ");
                parameter.Add(DbParameters.CreateDbParameter("@zbmc", '%' + queryParam["zbmc"].ToString() + '%'));
            }
            if (!queryParam["indicator1"].IsEmpty()&& queryParam["indicator2"].IsEmpty())
            {
                sbSql.Append(" AND TA001.[ZBBH] LIKE @indicator1 ");
                parameter.Add(DbParameters.CreateDbParameter("@indicator1", '%' + queryParam["indicator1"].ToString() + '%'));
            }
            if (!queryParam["indicator1"].IsEmpty() && !queryParam["indicator2"].IsEmpty())
            {
                sbSql.Append(" AND TA001.[ZBBH] LIKE @indicator2 ");
                parameter.Add(DbParameters.CreateDbParameter("@indicator2", '%' + queryParam["indicator2"].ToString() + '%'));
            }
            return new RepositoryFactory().HQPASRepository()
                .FindList<BpeTa002Model>(sbSql.ToString(), parameter.ToArray(), pagination);
        }
    }
}
