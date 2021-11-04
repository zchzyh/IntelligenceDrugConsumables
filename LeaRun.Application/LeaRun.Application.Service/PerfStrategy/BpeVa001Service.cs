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
    public class BpeVa001Service : RepositoryFactory<BpeVa001Entity>, IBpeVa001Service
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void AddOrUpdateRecord(BpeVa001Entity entity)
        {
            if (!string.IsNullOrEmpty(entity.SMBH ))
            {
                entity.Modify(entity.SMBH);
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
        public BpeVa001Entity GetRecord(string keyValue)
        {
            return HQPASRepository().FindEntity(keyValue);
        }

        IEnumerable<BpeVa001Model> IBpeVa001Service.GetPageList(Pagination pagination, string queryJson)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            var expression = LinqExtensions.True<RowColSettingModel>();

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(@"SELECT  A.[SMBH]
                                  ,A.[SMCS]
                                  ,A.[YJCS]
                                  ,A.[JZGCS]
                                  ,A.[ZLZMB]
                                  ,A.[JXBM]
                                  ,A.[REMARK]
                                  ,A.[CREATOR]
                                  ,A.[CREATEAT]
                                  ,A.[MODIFOR]
                                  ,A.[MODIFYAT]
                                  ,A.[STATUS]
	                              ,B.[JXND]
	                              ,B.[JXND] AS [YEAR]
                              FROM [BPMS].[BPE_VA001] A INNER JOIN [BPMS].[BPE_SC001] B
                              on A.JXBM =b.JXBM
                      WHERE 1=1");


            var queryParam = queryJson.ToJObject();
            if (!queryParam["jxbm"].IsEmpty())
            {
                sbSql.Append(" AND B.[JXBM] = @jxbm ");
                parameter.Add(DbParameters.CreateDbParameter("@jxbm", queryParam["jxbm"].ToString()));
            }
            if (!queryParam["mission"].IsEmpty())
            {
                sbSql.Append(" AND a.[SMCS] LIKE @mission ");
                parameter.Add(DbParameters.CreateDbParameter("@mission", '%' + queryParam["mission"].ToString() + '%'));
            }
            if (!queryParam["strategicTarget"].IsEmpty())
            {
                sbSql.Append(" AND a.[ZLZMB] LIKE @strategicTarget ");
                parameter.Add(DbParameters.CreateDbParameter("@strategicTarget", '%' + queryParam["strategicTarget"].ToString() + '%'));
            }
            

            return new RepositoryFactory().HQPASRepository()
                .FindList<BpeVa001Model>(sbSql.ToString(), parameter.ToArray(), pagination);
        }
    }
}
