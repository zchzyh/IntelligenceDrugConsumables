using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.IService.CollectionManage;
using LeaRun.Data;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;

namespace LeaRun.Application.Service.CollectionManage
{
    /// <summary>
    /// 采集表逻辑配置
    /// </summary>
    public class BpcSc006Service : RepositoryFactory<BpcSc006Entity>, IBpcSc006Service
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
        public BpcSc006Entity GetEntity(string keyValue)
        {
            return HQPASRepository().FindEntity(keyValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<BpcSc006Entity> GetPageList(Pagination pagination, string queryJson)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            var expression = LinqExtensions.True<BpcSp001Entity>();

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(@"SELECT  A.[XH]
                          ,A.[CJBBM]
                          ,A.[YWGZ]
                          ,A.[REMARK]
                          ,A.[CREATOR]
                          ,A.[CREATEAT]
                          ,A.[MODIFOR]
                          ,A.[MODIFYAT]
                          ,A.[STATUS]
	                      ,B.[CJBMC]
                      FROM [HQPAS].[BPMS].[BPC_SC006] A 
                      left join [BPMS].[BPC_SP001] B on A.CJBBM=B.CJBBM
                      WHERE 1=1");


            var queryParam = queryJson.ToJObject();
            if (!queryParam["CJBBM"].IsEmpty())
            {
                sbSql.Append(" AND A.[CJBBM] = @CJBBM ");
                parameter.Add(DbParameters.CreateDbParameter("@CJBBM", queryParam["CJBBM"].ToString()));
            }

            if (!queryParam["STATUS"].IsEmpty())
            {
                sbSql.Append(" AND A.[STATUS] = @STATUS ");
                parameter.Add(DbParameters.CreateDbParameter("@STATUS", queryParam["STATUS"].ToString()));
            }

            if (!queryParam["CJBMC"].IsEmpty())
            {
                sbSql.Append(" AND (B.[CJBMC] LIKE @CJBMC)");
                parameter.Add(DbParameters.CreateDbParameter("@CJBMC", '%' + queryParam["CJBMC"].ToString() + '%'));
            }

            return this.HQPASRepository().FindList(sbSql.ToString(), parameter.ToArray(), pagination);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="enabled"></param>
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
        public void AddOrUpdateRecord(BpcSc006Entity entity)
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
        /// <param name="tableNo"></param>
        /// <returns></returns>
        public bool ExistsRecord(string tableNo)
        {
            return HQPASRepository().FindEntity(o => o.CJBBM == tableNo) != null;
        }
    }
}