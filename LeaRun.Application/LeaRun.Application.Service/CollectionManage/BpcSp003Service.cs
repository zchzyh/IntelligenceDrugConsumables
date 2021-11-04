using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.Entity.CollectionManage.ViewModel;
using LeaRun.Application.Entity.PerfConfig;
using LeaRun.Application.IService.CollectionManage;
using LeaRun.Data;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;

namespace LeaRun.Application.Service.CollectionManage
{
    /// <summary>
    /// 年度采集表管理
    /// </summary>
    public class BpcSp003Service : RepositoryFactory<BpcSp003Entity>, IBpcSp003Service
    {
        #region 获取数据 

        /// <inheritdoc />
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public BpcSp003Entity GetEntity(string keyValue)
        {
            return HQPASRepository().FindEntity(keyValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public BpeSC001Entity GetActiveYearSetting()
        {
            return new RepositoryFactory().HQPASRepository()
                .FindList<BpeSC001Entity>(m => m.YXZT == "1"&&m.STATUS=="1").OrderByDescending(m=>m.JXND).FirstOrDefault();
        }

        /// <summary>
        /// 无分页列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BpcSp003Entity> GetList()
        {
            return this.HQPASRepository().IQueryable().OrderBy(t => t.CREATEAT).ToList();
        }

        /// <summary>
        /// 按年度取数据
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public IEnumerable<BpcSp003Entity> GetListByYear(string year)
        {
            return this.HQPASRepository().IQueryable().Where(p => p.ND == year).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public IEnumerable<BpcSp001Entity> GetTableListByYear(string year)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            var expression = LinqExtensions.True<RowColSettingModel>();
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(@"SELECT  A.ND,B.* FROM bpms.BPC_SP003 A INNER JOIN bpms.BPC_SP001 B 
                                   ON A.CJBBM=B.CJBBM 
                      WHERE 1=1");

            sbSql.Append(" AND A.[ND] = @year ");
            parameter.Add(DbParameters.CreateDbParameter("@year", year));

            return new RepositoryFactory().HQPASRepository()
                .FindList<BpcSp001Entity>(sbSql.ToString(), parameter.ToArray());
        }

        /// <summary>
        /// 行列设置分页列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<RowColSettingModel> GetRowColPageList(Pagination pagination, string queryJson)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            var expression = LinqExtensions.True<RowColSettingModel>();

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(@"SELECT [CJBBM], [CJBMC],[CJBQM], [SSLB], [ND], [CategoryName]
	                            , [RowStatus], [ColStatus]
                            FROM (
	                            SELECT A.[CJBBM], A.[CJBMC], A.[CJBQM], A.[SSLB], B.ND
		                            , C.[NAME] AS [CategoryName], isnull((
			                            SELECT TOP 1 1
			                            FROM [BPMS].BPC_SC002 sm
			                            WHERE CJBBM = A.[CJBBM] and ND=b.ND
		                            ), 0) AS [RowStatus]
		                            , isnull((
			                            SELECT TOP 1 1
			                            FROM [BPMS].BPC_SC003 sm
			                            WHERE CJBBM = A.[CJBBM] and ND=b.ND
		                            ), 0) AS [ColStatus]
	                            FROM [BPMS].BPC_SP001 A
		                            INNER JOIN [BPMS].BPC_SP003 B ON A.CJBBM = B.CJBBM
		                            LEFT JOIN [BPMS].BPC_SM002 C ON A.SSLB = C.TYPEID
                            ) A
                      WHERE 1=1");


            var queryParam = queryJson.ToJObject();
            if (!queryParam["year"].IsEmpty())
            {
                sbSql.Append(" AND A.[ND] = @JXND ");
                parameter.Add(DbParameters.CreateDbParameter("@JXND", queryParam["year"].ToString()));
            }

            if (!queryParam["category"].IsEmpty())
            {
                sbSql.Append(" AND A.[SSLB] = @SSLB ");
                parameter.Add(DbParameters.CreateDbParameter("@SSLB", queryParam["category"].ToString()));
            }

            if (!queryParam["rowStatus"].IsEmpty())
            {
                sbSql.Append(" AND A.[RowStatus] = @RowStatus ");
                parameter.Add(DbParameters.CreateDbParameter("@RowStatus", queryParam["rowStatus"].ToString()));
            }

            if (!queryParam["colStatus"].IsEmpty())
            {
                sbSql.Append(" AND A.[ColStatus] = @ColStatus ");
                parameter.Add(DbParameters.CreateDbParameter("@ColStatus", queryParam["colStatus"].ToString()));
            }

            if (!queryParam["tableName"].IsEmpty())
            {
                sbSql.Append(" AND (A.[CJBMC] LIKE @CJBMC  or A.[CJBQM] LIKE  @CJBMC)");
                parameter.Add(DbParameters.CreateDbParameter("@CJBMC", '%' + queryParam["tableName"].ToString() + '%'));
            }

            if (!queryParam["tableNo"].IsEmpty())
            {
                sbSql.Append(" AND A.[CJBBM] LIKE  @CJBBM");
                parameter.Add(DbParameters.CreateDbParameter("@CJBBM", '%' + queryParam["tableNo"].ToString() + '%'));
            }
                return new RepositoryFactory().HQPASRepository()
                    .FindList<RowColSettingModel>(sbSql.ToString(), parameter.ToArray(), pagination);
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<BpeSC001Entity> GetPageList(Pagination pagination, string queryJson)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            var expression = LinqExtensions.True<BpeSC001Entity>();

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(@"SELECT [JXBM]
                                  ,[JXQY]
                                  ,[JXND]
                                  ,[KSSJ]
                                  ,[JZSJ]
                                  ,[FWZT]
                                  ,[YXZT]
                                  ,[REMARK]
                                  ,[CREATOR]
                                  ,[CREATEAT]
                                  ,[MODIFOR]
                                  ,[MODIFYAT]
                                  ,[STATUS]
                              FROM [HQPAS].[BPMS].[BPE_SC001] A
                      WHERE 1=1 and STATUS=1");


            var queryParam = queryJson.ToJObject();
            if (!queryParam["year"].IsEmpty())
            {
                sbSql.Append(" AND A.[JXND] = @JXND ");
                parameter.Add(DbParameters.CreateDbParameter("@JXND", queryParam["year"].ToString()));
            }

            if (!queryParam["status"].IsEmpty())
            {
                sbSql.Append(" AND A.[YXZT] = @YXZT ");
                parameter.Add(DbParameters.CreateDbParameter("@YXZT", queryParam["status"].ToString()));
            }

            try
            {
                // return this.HQPASRepository().FindList(sbSql.ToString(), parameter.ToArray(), pagination);
                return new RepositoryFactory().HQPASRepository()
                    .FindList<BpeSC001Entity>(sbSql.ToString(), parameter.ToArray(), pagination);
            }
            catch (Exception ex)
            {
            }

            return null;
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
        /// 保存记录（添加/删除）
        /// </summary>
        /// <param name="entity"></param>
        public void SaveForm(BpcSp003Entity entity)
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
        /// <param name="entities"></param>
        public void SaveForm(string year,List<BpcSp003Entity> entities)
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

        #endregion
    }
}