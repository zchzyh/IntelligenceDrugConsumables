using LeaRun.Application.Entity.CollectionAnalysis.ViewModel;
using LeaRun.Application.IService.CollectionAnalysis;
using LeaRun.Application.IService.DataAnalysis;
using LeaRun.Data;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Service.CollectionAnalysis
{
    /// <summary>
    /// 采集工作分析
    /// </summary>
    public class CollectionWorkAnalysisService : RepositoryFactory, ICollectionWorkAnalysisService
    {
        /// <summary>
        /// 获取采集任务督查列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<CollectionTaskInspectModel> GetCollectionTaskInspectList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT U.[NAME]
                            	  ,C.[ND]
                            	  ,C.[YD]
                            	  ,COUNT(distinct C.[CJBBM]) CjbCount
                            	  ,COUNT([XH]) RwCount
                            	  ,COUNT(case when [RWCD] = @CollectStatusTypeUndone then 1 else null end) Cj0Count
                            	  ,COUNT(case when [RWCD] = @CollectStatusTypeDoing then 1 else null end) Cj1Count
                            	  ,COUNT(case when [RWCD] = @CollectStatusTypeDone then 1 else null end) Cj2Count
                            	  ,COUNT(case when [SQZT] = @ApplyStatusTypeUndone then 1 else null end) Sq0Count
                            	  ,COUNT(case when [SQZT] = @ApplyStatusTypeReject then 1 else null end) Sq1Count
                            	  ,COUNT(case when [SQZT] = @ApplyStatusTypeDone then 1 else null end) Sq2Count
                            FROM [HQPAS].[BPMS].[BPC_SP006] P
                            LEFT JOIN [HQPAS].[BPMS].[BPC_SP002] C ON P.[RWBH] = C.[RWBH]
                            LEFT JOIN [HQPAS].[BPMS].[DEP_AUDIT_USER] U ON P.[USERID] = U.[USERID]
                            WHERE P.[STATUS] = '1' AND U.[STATUS] = '1' ");
            parameter.Add(DbParameters.CreateDbParameter("@CollectStatusTypeUndone", Config.GetValue("CollectStatusTypeUndone")));
            parameter.Add(DbParameters.CreateDbParameter("@CollectStatusTypeDone", Config.GetValue("CollectStatusTypeDone")));
            parameter.Add(DbParameters.CreateDbParameter("@CollectStatusTypeDoing", Config.GetValue("CollectStatusTypeDoing")));
            parameter.Add(DbParameters.CreateDbParameter("@ApplyStatusTypeUndone", Config.GetValue("ApplyStatusTypeUndone")));
            parameter.Add(DbParameters.CreateDbParameter("@ApplyStatusTypeDone", Config.GetValue("ApplyStatusTypeDone")));
            parameter.Add(DbParameters.CreateDbParameter("@ApplyStatusTypeReject", Config.GetValue("ApplyStatusTypeReject")));
            //绩效年度
            if (!queryParam["jxbm"].IsEmpty())
            {
                strSql.Append(" AND C.[JXBM] = @JXBM ");
                parameter.Add(DbParameters.CreateDbParameter("@JXBM", queryParam["jxbm"].ToString()));
            }
            //月度
            if (!queryParam["yd"].IsEmpty())
            {
                strSql.Append(" AND [YD] = @YD ");
                parameter.Add(DbParameters.CreateDbParameter("@YD", queryParam["yd"].ToDecimal()));
            }
            //任务人
            if (!queryParam["name"].IsEmpty())
            {
                strSql.Append(" AND U.[NAME] LIKE @NAME ");
                parameter.Add(DbParameters.CreateDbParameter("@NAME", '%' + queryParam["name"].ToString() + '%'));
            }
            strSql.Append(" GROUP by P.[USERID],U.[NAME],C.[JXBM],C.[ND],C.[YD] ");
            return this.HQPASRepository().FindList<CollectionTaskInspectModel>(strSql.ToString(), parameter.ToArray(), pagination);
        }

        /// <summary>
        /// 获取审核任务督查列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<AuditTaskInspectModel> GetAuditTaskInspectList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT U.[NAME]
                            	  ,C.[ND]
                            	  ,C.[YD]
                            	  ,COUNT(distinct C.[CJBBM]) CjbCount
                            	  ,COUNT([XH]) RwCount
                            	  ,COUNT(case when [SQZT] = @ApplyStatusTypeUndone then 1 else null end) Sq0Count
                            	  ,COUNT(case when [SQZT] = @ApplyStatusTypeReject then 1 else null end) Sq1Count
                            	  ,COUNT(case when [SQZT] = @ApplyStatusTypeDone then 1 else null end) Sq2Count
                            	  ,COUNT(case when [SHZT] = @AuditStatusTypeUndone then 1 else null end) Sh0Count
                            	  ,COUNT(case when [SHZT] = @AuditStatusTypeReject then 1 else null end) Sh1Count
                            	  ,COUNT(case when [SHZT] = @AuditStatusTypePass then 1 else null end) Sh2Count
                            FROM [HQPAS].[BPMS].[BPC_SP006] P
                            LEFT JOIN [HQPAS].[BPMS].[BPC_SP002] C ON P.[RWBH] = C.[RWBH]
                            LEFT JOIN [HQPAS].[BPMS].[DEP_AUDIT_USER] U ON P.[SHR] = U.[USERID]
                            WHERE P.[STATUS] = '1' AND (P.[SHR] IS NULL OR P.[SHR] = '' OR U.[STATUS] = '1') ");
            parameter.Add(DbParameters.CreateDbParameter("@ApplyStatusTypeUndone", Config.GetValue("ApplyStatusTypeUndone")));
            parameter.Add(DbParameters.CreateDbParameter("@ApplyStatusTypeDone", Config.GetValue("ApplyStatusTypeDone")));
            parameter.Add(DbParameters.CreateDbParameter("@ApplyStatusTypeReject", Config.GetValue("ApplyStatusTypeReject")));
            parameter.Add(DbParameters.CreateDbParameter("@AuditStatusTypeUndone", Config.GetValue("AuditStatusTypeUndone")));
            parameter.Add(DbParameters.CreateDbParameter("@AuditStatusTypePass", Config.GetValue("AuditStatusTypePass")));
            parameter.Add(DbParameters.CreateDbParameter("@AuditStatusTypeReject", Config.GetValue("AuditStatusTypeReject")));
            //绩效年度
            if (!queryParam["jxbm"].IsEmpty())
            {
                strSql.Append(" AND C.[JXBM] = @JXBM ");
                parameter.Add(DbParameters.CreateDbParameter("@JXBM", queryParam["jxbm"].ToString()));
            }
            //月度
            if (!queryParam["yd"].IsEmpty())
            {
                strSql.Append(" AND [YD] = @YD ");
                parameter.Add(DbParameters.CreateDbParameter("@YD", queryParam["yd"].ToDecimal()));
            }
            //任务人
            if (!queryParam["name"].IsEmpty())
            {
                strSql.Append(" AND U.[NAME] LIKE @NAME ");
                parameter.Add(DbParameters.CreateDbParameter("@NAME", '%' + queryParam["name"].ToString() + '%'));
            }
            strSql.Append(" GROUP by P.[SHR],U.[NAME],C.[JXBM],C.[ND],C.[YD] ");
            return this.HQPASRepository().FindList<AuditTaskInspectModel>(strSql.ToString(), parameter.ToArray(), pagination);
        }

        /// <summary>
        /// 获取采集任务预警列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<CollectionTaskWarningModel> GetCollectionTaskWarningList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT [XH]
                            	  ,U.[NAME]
                            	  ,B.[CJBQM]
                            	  ,C.[ND]
                            	  ,C.[YD]
                            	  ,C.[KSSJ]
                            	  ,C.[JZSJ]
                            FROM [HQPAS].[BPMS].[BPC_SP006] P
                            LEFT JOIN [HQPAS].[BPMS].[DEP_AUDIT_USER] U ON P.[USERID] = U.[USERID]
                            LEFT JOIN [HQPAS].[BPMS].[BPC_SP002] C ON P.[RWBH] = C.[RWBH]
                            LEFT JOIN [HQPAS].[BPMS].[BPC_SP001] B ON C.[CJBBM] = B.[CJBBM]
                            WHERE P.[STATUS] = '1' AND U.[STATUS] = '1' AND P.[RWCD] = '0' ");
            //绩效年度
            if (!queryParam["jxbm"].IsEmpty())
            {
                strSql.Append(" AND C.[JXBM] = @JXBM ");
                parameter.Add(DbParameters.CreateDbParameter("@JXBM", queryParam["jxbm"].ToString()));
            }
            //月度
            if (!queryParam["yd"].IsEmpty())
            {
                strSql.Append(" AND [YD] = @YD ");
                parameter.Add(DbParameters.CreateDbParameter("@YD", queryParam["yd"].ToDecimal()));
            }
            //任务人
            if (!queryParam["name"].IsEmpty())
            {
                strSql.Append(" AND U.[NAME] LIKE @NAME ");
                parameter.Add(DbParameters.CreateDbParameter("@NAME", '%' + queryParam["name"].ToString() + '%'));
            }
            //任务人
            if (!queryParam["cjbqm"].IsEmpty())
            {
                strSql.Append(" AND B.[CJBQM] LIKE @CJBQM ");
                parameter.Add(DbParameters.CreateDbParameter("@CJBQM", '%' + queryParam["cjbqm"].ToString() + '%'));
            }
            return this.HQPASRepository().FindList<CollectionTaskWarningModel>(strSql.ToString(), parameter.ToArray(), pagination);
        }

        /// <summary>
        /// 获取年度任务分析列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<YearTaskAnalysisModel> GetYearTaskAnalysisList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT P.[USERID]
                            	  ,U.[NAME]
                            	  ,C.[JXBM]
                            	  ,COUNT(1) RwCount
                            FROM [HQPAS].[BPMS].[BPC_SP006] P
                            LEFT JOIN [HQPAS].[BPMS].[BPC_SP002] C ON P.[RWBH] = C.[RWBH]
                            LEFT JOIN [HQPAS].[BPMS].[DEP_AUDIT_USER] U ON P.[USERID] = U.[USERID]
                            WHERE P.[STATUS] = '1' AND U.[STATUS] = '1' ");
            //绩效年度
            if (!queryParam["jxbm"].IsEmpty())
            {
                strSql.Append(" AND C.[JXBM] = @JXBM ");
                parameter.Add(DbParameters.CreateDbParameter("@JXBM", queryParam["jxbm"].ToString()));
            }
            //任务人
            if (!queryParam["name"].IsEmpty())
            {
                strSql.Append(" AND U.[NAME] LIKE @NAME ");
                parameter.Add(DbParameters.CreateDbParameter("@NAME", '%' + queryParam["name"].ToString() + '%'));
            }
            strSql.Append(" GROUP by P.[USERID],U.[NAME],C.[JXBM] ");
            return this.HQPASRepository().FindList<YearTaskAnalysisModel>(strSql.ToString(), parameter.ToArray(), pagination);
        }

        /// <summary>
        /// 获取年度任务列表
        /// </summary>
        /// <param name="jxbm">绩效年度编码</param>
        /// <param name="userids">任务人ID列表</param>
        /// <returns>返回列表</returns>
        public IEnumerable<YearTaskAnalysisItemModel> GetYearTaskAnalysisItemList(string jxbm, List<string> userids)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT [USERID]
                                  ,[RWCD]
                            	  ,[ND]
                            	  ,[YD]
                            FROM [HQPAS].[BPMS].[BPC_SP006] P
                            LEFT JOIN [HQPAS].[BPMS].[BPC_SP002] C ON P.[RWBH] = C.[RWBH]
                            WHERE P.[STATUS] = '1' ");
            //绩效年度
            strSql.Append(" AND C.[JXBM] = @JXBM ");
            parameter.Add(DbParameters.CreateDbParameter("@JXBM", jxbm));

            //任务人
            string sqlUserids = "('" + string.Join("','", userids) + "')";
            strSql.Append(" AND [USERID] IN " + sqlUserids);

            return this.HQPASRepository().FindList<YearTaskAnalysisItemModel>(strSql.ToString(), parameter.ToArray());
        }
    }
}