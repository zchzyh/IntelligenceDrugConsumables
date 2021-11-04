using LeaRun.Application.Entity.CollectionManage.ViewModel;
using LeaRun.Application.IService.CollectionManage;
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

namespace LeaRun.Application.Service.CollectionManage
{
    /// <summary>
    /// 我的审核任务
    /// </summary>
    public class MyTaskAuditService : RepositoryFactory, IMyTaskAuditService
    {

        #region 获取数据

        /// <summary>
        /// 获取我的审核任务列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<MyTaskAuditModel> GetMyTaskAuditList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT P6.[XH]
                                    ,P2.[RWBH]
                                    ,P2.[CJBBM]
                                    ,P1.[CJBQM]
                                    ,P1.[CJPL]
                                    ,C.[NAME] CJPLNAME
                                    ,O.[OFFICECODE]
                                    ,O.[OFFICENAME]
                            	    ,P2.[ND]
                            	    ,P2.[YD]
                            	    ,P2.[KSSJ]
                            	    ,P2.[JZSJ]
                            	    ,P6.[USERID]
                            	    ,U.[NAME]
                            	    ,P6.[RWCD]
                            	    ,P6.[SQZT]
                            	    ,P6.[SHZT] FROM [HQPAS].[BPMS].[BPC_SP006] P6
                            LEFT JOIN [HQPAS].[BPMS].[BPC_SP002] P2
                            ON P2.[RWBH] = P6.[RWBH]
                            LEFT JOIN [HQPAS].[BPMS].[BPC_SP001] P1 WITH (NOLOCK)
                            ON P2.[CJBBM] = P1.[CJBBM]
                            LEFT JOIN (SELECT [CODE]
                                            , [NAME]
                                       FROM [HQPAS].[BPMS].[S103_CODE] WITH (NOLOCK)
                                       WHERE [TYPEID] = @FrequencyType AND [STATUS] = '1') C ON P1.[CJPL] = C.[CODE]
                            LEFT JOIN [HQPAS].[BPMS].[DEP_AUDIT_USER] U WITH (NOLOCK)
                            ON P6.USERID=U.USERID
                            LEFT JOIN [HQPAS].[BPMS].[PMR008_OFFIECES] O WITH (NOLOCK) 
                            ON P2.[JGDM] = O.[ID]
                            WHERE P2.[STATUS] = '1'
                            AND P1.[STATUS] = '1'
                            AND P6.[STATUS] = '1'
                            AND U.[STATUS] = '1'
                            AND P6.[RWCD] = @RWCD
                            AND P6.[SQZT] != @SQZT1 ");

            parameter.Add(DbParameters.CreateDbParameter("@FrequencyType", Config.GetValue("FrequencyType")));
            parameter.Add(DbParameters.CreateDbParameter("@RWCD", Config.GetValue("CollectStatusTypeDone")));
            parameter.Add(DbParameters.CreateDbParameter("@SQZT1", Config.GetValue("ApplyStatusTypeUndone")));

            //年度过滤
            if (!queryParam["nd"].IsEmpty())
            {
                strSql.Append(" AND P2.[JXBM] = @ND ");
                parameter.Add(DbParameters.CreateDbParameter("@ND", queryParam["nd"].ToString()));
            }

            //月度过滤
            if (!queryParam["yd"].IsEmpty())
            {
                strSql.Append(" AND P2.[YD] = @YD ");
                parameter.Add(DbParameters.CreateDbParameter("@YD", queryParam["yd"].ToString()));
            }

            //采集状态过滤
            //if (!queryParam["rwcd"].IsEmpty())
            //{
            //    strSql.Append(" AND P6.[RWCD] = @RWCD ");
            //    parameter.Add(DbParameters.CreateDbParameter("@RWCD", queryParam["rwcd"].ToString()));
            //}

            //申请状态过滤
            if (!queryParam["sqzt"].IsEmpty())
            {
                strSql.Append(" AND P6.[SQZT] = @SQZT ");
                parameter.Add(DbParameters.CreateDbParameter("@SQZT", queryParam["sqzt"].ToString()));
            }

            //审核状态过滤
            if (!queryParam["shzt"].IsEmpty())
            {
                strSql.Append(" AND P6.[SHZT] = @SHZT ");
                parameter.Add(DbParameters.CreateDbParameter("@SHZT", queryParam["shzt"].ToString()));
            }

            //采集表名称过滤
            if (!queryParam["cjbmc"].IsEmpty())
            {
                string cjbmc = queryParam["cjbmc"].ToString();
                strSql.Append(" AND P1.[CJBQM] LIKE @CJBMC ");
                parameter.Add(DbParameters.CreateDbParameter("@CJBMC", '%' + cjbmc + '%'));
            }

            return this.HQPASRepository().FindList<MyTaskAuditModel>(strSql.ToString(), parameter.ToArray(), pagination);
        }

        #endregion

        #region 提交数据

        #endregion
    }
}
