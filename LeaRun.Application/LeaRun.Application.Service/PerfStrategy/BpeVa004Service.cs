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
    public class BpeVa004Service : RepositoryFactory<BpeVa004Entity>, IBpeVa004Service
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void AddOrUpdateRecord(BpeVa004Entity entity)
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
        public BpeVa004Entity GetRecord(string keyValue)
        {
            return HQPASRepository().FindEntity(keyValue);
        }
        public BpeVa004Model GetRecordModel(string keyValue)
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
            return new RepositoryFactory().HQPASRepository().FindList<BpeVa004Model>(sbSql.ToString(), parameter.ToArray()).FirstOrDefault();
        }

        IEnumerable<BpeVa004Model> IBpeVa004Service.GetPageList(Pagination pagination, string queryJson)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            var expression = LinqExtensions.True<RowColSettingModel>();

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(@"SELECT [CSFBH]
                                  ,VA004.[CSFMC]
                                  ,VA004.[ZTBH]
                                  ,VA004.[CREATOR]
                                  ,VA004.[CREATEAT]
                                  ,VA004.[MODIFOR]
                                  ,VA004.[MODIFYAT]
                                  ,VA004.[STATUS]
	                              ,VA003.[ZTMC]
	                              ,SC001.[JXND] AS [Year]
                                  ,SC001.[JXBM]
                              FROM [HQPAS].[BPMS].[BPE_VA004] VA004
                              INNER JOIN [BPMS].[BPE_VA003] VA003 ON VA004.ZTBH=VA003.ZTBH
                              INNER JOIN [BPMS].[BPE_VA001] VA001 ON VA001.SMBH=VA003.SMBH
                              INNER JOIN [BPMS].[BPE_SC001] SC001 ON SC001.JXBM=VA001.JXBM
                                                  WHERE 1=1");


            var queryParam = queryJson.ToJObject();
            if (!queryParam["year"].IsEmpty())
            {
                sbSql.Append(" AND SC001.[JXBM] = @year ");
                parameter.Add(DbParameters.CreateDbParameter("@year", queryParam["year"].ToString()));
            }
            if (!queryParam["csf"].IsEmpty())
            {
                sbSql.Append(" AND VA004.[CSFMC] LIKE @csf ");
                parameter.Add(DbParameters.CreateDbParameter("@csf", '%' + queryParam["csf"].ToString() + '%'));
            }

            return new RepositoryFactory().HQPASRepository()
                .FindList<BpeVa004Model>(sbSql.ToString(), parameter.ToArray(), pagination);
        }
    }
}
