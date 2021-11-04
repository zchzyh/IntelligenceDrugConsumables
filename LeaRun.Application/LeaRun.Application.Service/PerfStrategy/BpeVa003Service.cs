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
    public class BpeVa003Service : RepositoryFactory<BpeVa003Entity>, IBpeVa003Service
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void AddOrUpdateRecord(BpeVa003Entity entity)
        {
            if (!string.IsNullOrEmpty(entity.ZTBH))
            {
                entity.Modify(entity.ZTBH);
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
        public BpeVa003Entity GetRecord(string keyValue)
        {
            return HQPASRepository().FindEntity(keyValue);
        }
        public BpeVa003Model GetRecordModel(string keyValue)
        {
            List<DbParameter> parameter = new List<DbParameter>(); 

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(@"  SELECT  A.[ZTBH]
                                  ,A.[ZTMC]
                                  ,A.[BSCBH]
                                  ,A.[SMBH]
                                  ,A.[REMARK]
                                  ,A.[CREATOR]
                                  ,A.[CREATEAT]
                                  ,A.[MODIFOR]
                                  ,A.[MODIFYAT]
                                  ,A.[STATUS]
	                              ,C.[JXND] AS [YEAR]
                                  ,C.[JXBM]       
                              FROM [BPMS].[BPE_VA003] A 
                              INNER JOIN[BPMS].[BPE_VA001] B ON A.SMBH=B.SMBH
                              INNER JOIN [BPMS].[BPE_SC001] C on B.JXBM =C.JXBM 
                      WHERE 1=1");


            if (!keyValue.IsEmpty())
            {
                sbSql.Append(" AND A.[ZTBH] = @ZTBH ");
                parameter.Add(DbParameters.CreateDbParameter("@ZTBH", keyValue));
            }
            return new RepositoryFactory().HQPASRepository().FindList<BpeVa003Model>(sbSql.ToString(), parameter.ToArray()).FirstOrDefault();
        }

        IEnumerable<BpeVa003Model> IBpeVa003Service.GetPageList(Pagination pagination, string queryJson)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            var expression = LinqExtensions.True<RowColSettingModel>();

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(@"SELECT  [ZTBH]
                                  ,A.[ZTMC]
                                  ,A.[BSCBH]
                                  ,A.[SMBH]
                                  ,A.[REMARK]
                                  ,A.[CREATOR]
                                  ,A.[CREATEAT]
                                  ,A.[MODIFOR]
                                  ,A.[MODIFYAT]
                                  ,A.[STATUS]
	                              ,C.[JXND]
	                              ,D.[BSCMC]
                                  ,B.[ZLZMB]
                              FROM [BPMS].[BPE_VA003] A  INNER JOIN 
                              [BPMS].[BPE_VA001] B ON A.SMBH=B.SMBH
                              INNER JOIN [BPMS].[BPE_SC001] C on B.JXBM =C.JXBM 
                              INNER JOIN [BPMS].[BPE_VA002] D ON A.BSCBH=D.BSCBH
                      WHERE 1=1");


            var queryParam = queryJson.ToJObject();
            if (!queryParam["jxbm"].IsEmpty())
            {
                sbSql.Append(" AND B.[JXBM] = @jxbm ");
                parameter.Add(DbParameters.CreateDbParameter("@jxbm", queryParam["jxbm"].ToString()));
            }
            if (!queryParam["theme"].IsEmpty())
            {
                sbSql.Append(" AND A.[ZTMC] LIKE @theme ");
                parameter.Add(DbParameters.CreateDbParameter("@theme", '%' + queryParam["theme"].ToString() + '%'));
            }

            return new RepositoryFactory().HQPASRepository()
                .FindList<BpeVa003Model>(sbSql.ToString(), parameter.ToArray(), pagination);
        }
    }
}
