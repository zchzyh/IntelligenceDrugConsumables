using System;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using LeaRun.Data;
using System.Linq;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.IService.CollectionManage;

namespace LeaRun.Application.Service.CollectionManage
{
    /// <summary>
    /// 采集表信息管理
    /// </summary>
    public class BpcSp001Service : RepositoryFactory<BpcSp001Entity>, IBpcSp001Service
    {
        #region 获取数据 

        /// <inheritdoc />
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public BpcSp001Entity GetEntity(string keyValue)
        {
            return HQPASRepository().FindEntity(keyValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public int GetTableCountByCategory(string category)
        {
            return HQPASRepository().IQueryable(c => c.SSLB == category).Count();
        }

        /// <summary>
        /// 无分页列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BpcSp001Entity> GetList()
        {
            return this.HQPASRepository().IQueryable().OrderBy(t => t.CREATEAT).ToList();
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<BpcSp001Entity> GetPageList(Pagination pagination, string queryJson)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            var expression = LinqExtensions.True<BpcSp001Entity>();

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(@"SELECT [CJBBM]
                          ,[CJBMC]
                          ,[CJBQM]
                          ,[CJPL]
                          ,[CJFS]
                          ,[SSLB]
                          ,[URL]
                          ,[SFBT]
                          ,[PX]
                          ,[REMARK]
                          ,[CREATOR]
                          ,[CREATEAT]
                          ,[MODIFOR]
                          ,[MODIFYAT]
                          ,A.[STATUS]
                          ,[DWFS]
	                      ,B.NAME as SSLBMC
                      FROM [HQPAS].[BPMS].[BPC_SP001] A 
                      left join bpms.BPC_SM002 B on A.SSLB=B.TYPEID
                      WHERE 1=1");


            var queryParam = queryJson.ToJObject();
            if (!queryParam["SSLB"].IsEmpty())
            {
                sbSql.Append(" AND A.[SSLB] = @SSLB ");
                parameter.Add(DbParameters.CreateDbParameter("@SSLB", queryParam["SSLB"].ToString()));
            }

            if (!queryParam["STATUS"].IsEmpty())
            {
                sbSql.Append(" AND A.[STATUS] = @STATUS ");
                parameter.Add(DbParameters.CreateDbParameter("@STATUS", queryParam["STATUS"].ToString()));
            }

            if (!queryParam["CJBMC"].IsEmpty())
            {
                sbSql.Append(" AND (A.[CJBMC] LIKE @CJBMC  or A.[CJBQM] LIKE  @CJBMC)");
                parameter.Add(DbParameters.CreateDbParameter("@CJBMC", '%' + queryParam["CJBMC"].ToString() + '%'));
            }
            if (!queryParam["CJBBM"].IsEmpty())
            {
                sbSql.Append(" AND A.[CJBBM] LIKE  @CJBBM");
                parameter.Add(DbParameters.CreateDbParameter("@CJBBM", '%' + queryParam["CJBBM"].ToString() + '%'));
            }
            return this.HQPASRepository().FindList(sbSql.ToString(), parameter.ToArray(), pagination);
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 修改状态
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
        /// 删除记录
        /// </summary>
        /// <param name="keyValue"></param>
        public void DeleteRecord(string keyValue)
        {
            HQPASRepository().Delete(keyValue);
        }

        /// <summary>
        /// 保存记录（添加/修改）
        /// </summary>
        /// <param name="entity"></param>
        public void SaveForm(BpcSp001Entity entity)
        {
            if (!string.IsNullOrEmpty(entity.CJBBM))
            {
                entity.Modify(entity.CJBBM);
                HQPASRepository().Update(entity);
            }
            else
            {
                entity.Create();
                int count = GetTableCountByCategory(entity.SSLB);
                entity.CJBBM = "BPC_" + "C" + entity.SSLB + (count + 1).ToString().PadLeft(3, '0');

                HQPASRepository().Insert(entity);
            }
        }

        #endregion
    }
}