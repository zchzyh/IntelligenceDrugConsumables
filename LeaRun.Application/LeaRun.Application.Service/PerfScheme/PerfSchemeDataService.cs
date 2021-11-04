using LeaRun.Application.Entity.PerfGoal;
using LeaRun.Application.Entity.PerfScheme;
using LeaRun.Application.Entity.PerfScheme.ViewModel;
using LeaRun.Application.IService.PerfScheme;
using LeaRun.Data;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace LeaRun.Application.Service.PerfScheme
{
    /// <summary>
    /// 基本方案设置接口实现程序
    /// </summary>
    public class PerfSchemeDataService : RepositoryFactory, IPerfSchemeDataService
    {
        /// <summary>
        /// 获取基本方案列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns>评价方法列表</returns>
        public IEnumerable<BpePA001Entity> GetList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"  SELECT [FABH]
                                    ,[FAMC]
                                    ,Y.[JXND] AS [YEAR]
                                    ,M.[SYND]
                                    ,M.[SYDX]
                                    ,M.[JXBM]
                                    ,M.[REMARK]
                                    ,M.[CREATOR]
                                    ,M.[CREATEAT]
                                    ,M.[MODIFOR]
                                    ,M.[MODIFYAT]
                                    ,M.[STATUS]
                                    FROM [HQPAS].[BPMS].[BPE_PA001] M
                                    INNER JOIN [HQPAS].[BPMS].[BPE_SC001] Y
                                    ON M.[JXBM] = Y.JXBM 
                                    WHERE M.STATUS = '1' ");
            return this.HQPASRepository().FindList<BpePA001Entity>(strSql.ToString(), parameter.ToArray(), pagination);
        }
        /// <summary>
        /// 获取基本方案名称列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns>评价方法列表</returns>
        public IEnumerable<BaseperfSchemesettingModel> GetBaseperfNameList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"  SELECT M.[FABH]
                                    ,M.[FAMC]
                                    ,Y.[JXND] AS [YEAR]
                                    ,M.[SYND]
                                    ,M.[SYDX]
                                    ,M.[JXBM]
                                    ,M.[REMARK]
                                    ,M.[CREATOR]
                                    ,M.[CREATEAT]
                                    ,M.[MODIFOR]
                                    ,M.[MODIFYAT]
                                    ,M.[STATUS]
                                    FROM [HQPAS].[BPMS].[BPE_PA001] M
                                    INNER JOIN [HQPAS].[BPMS].[BPE_SC001] Y
                                    ON M.[JXBM] = Y.JXBM 
                                    WHERE M.STATUS = '1' ");

            if (!queryParam["keyword"].IsEmpty())
            {
                strSql.Append(" AND ([FAMC] LIKE @KEYWORD OR [FABH] LIKE @KEYWORD) ");
                parameter.Add(DbParameters.CreateDbParameter("@KEYWORD", '%' + queryParam["keyword"].ToString() + '%'));
            }
            if (!queryParam["year"].IsEmpty())
            {
                strSql.Append(" AND (Y.[JXBM] = @YEAR) ");
                parameter.Add(DbParameters.CreateDbParameter("@YEAR", queryParam["year"].ToString()));
            }
            return this.HQPASRepository().FindList<BaseperfSchemesettingModel>(strSql.ToString(), parameter.ToArray(), pagination);
        }
        /// <summary>
        /// 获取基本方案列表编码
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<BpePA001Entity> GetBmList(string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT [FABH]
                                  ,[FAMC]
                            FROM [HQPAS].[BPMS].[BPE_PA001]
                            WHERE [STATUS] = '1' ");
            //绩效年度
            if (!queryParam["jxbm"].IsEmpty())
            {
                strSql.Append(" AND [JXBM] = @JXBM ");
                parameter.Add(DbParameters.CreateDbParameter("@JXBM", queryParam["jxbm"].ToString()));
            }
            strSql.Append(" ORDER BY [SYND] DESC,[FABH] ");
            return this.HQPASRepository().FindList<BpePA001Entity>(strSql.ToString(), parameter.ToArray());
        }
        /// <summary>
        /// 获取所有指标的列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<KpiAll> GetKPIListJson(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT 
                            E.JXND,
                            A.JXBM,
                            D.KPIBH,
                            D.ZBJX,
                            D.ZBCD,
                            D.ZBGS,
                            D.ZBGSMS,
                            D.ZBSDMD,
                            D.REMARK,
                            D.STATUS,
                            D.JLDW,
                            A.ZBBH AS ThirdZBBH,
                            A.ZBMC AS ThirdZBMC,
                            B.ZBBH AS SecZBBH,
                            B.ZBMC AS SecZBMC,
                            C.ZBBH AS FirstZBBH,
                            C.ZBMC AS FirstZBMC,
                            A.STATUS AS ZBSTATUS,
                            A.EXPLAIN,
                            A.ZBLB,
                            ISNULL(F.XH,'') AS XH,
                            ISNULL(F.FABH,'') AS FABH 
                            FROM [HQPAS].[BPMS].[KPIALL] A 
                            INNER JOIN [HQPAS].[BPMS].[KPIALL] B ON A.FJZB=B.ZBBH AND A.JXBM=B.JXBM AND A.ZBJB='3'
                            INNER JOIN [HQPAS].[BPMS].[KPIALL] C ON B.FJZB=C.ZBBH AND B.JXBM=C.JXBM 
                            LEFT JOIN [HQPAS].[BPMS].[BPE_TA002] D ON A.ZBBH=D.ZBBH AND A.JXBM=D.JXBM
                            LEFT JOIN [HQPAS].[BPMS].[BPE_SC001] E ON A.JXBM=E.JXBM 
                            LEFT JOIN [HQPAS].[BPMS].[BPE_PA002] F ON F.KPIBH=A.ZBBH ");
            //方案编号
            if (!queryParam["fabh"].IsEmpty())
            {
                strSql.Append(" AND F.FABH=@FABH WHERE 1=1");
                parameter.Add(DbParameters.CreateDbParameter("@FABH", queryParam["fabh"].ToString()));
            }
            else
            {
                strSql.Append(" AND F.FABH='' WHERE 1=1");
            }
            //绩效年度编码
            if (!queryParam["year"].IsEmpty())
            {
                strSql.Append(" AND A.[JXBM] = @YEAR ");
                parameter.Add(DbParameters.CreateDbParameter("@YEAR", queryParam["year"].ToString()));
            }

            if (!queryParam["indicator1"].IsEmpty())
            {
                strSql.Append(" AND C.ZBBH = @FZBBH ");
                parameter.Add(DbParameters.CreateDbParameter("@FZBBH", queryParam["indicator1"].ToString()));
            }

            return this.HQPASRepository().FindList<KpiAll>(strSql.ToString(), parameter.ToArray(), pagination);
        }
        /// <summary>
        /// 获取部门绩效方案列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<DepPerfSchemeSettingModel> GetDepSchemeDataList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"    SELECT PA003.[JGFABH]
                                      ,PA003.[JGFAMC]
                                      ,PA003.[JGBM]
                                      ,PMR008.[OFFICENAME]
                                      ,PA003.[FABH]
                                      ,PA001.[FAMC]
                                      ,PA003.[JXBM]
                                      ,SC001.[JXND]
                                      ,PA003.[REMARK]
                                      ,PA003.[CREATOR]
                                      ,PA003.[CREATEAT]
                                      ,PA003.[MODIFOR]
                                      ,PA003.[MODIFYAT]
                                      ,PA003.[STATUS]
                                  FROM [HQPAS].[BPMS].[BPE_PA003] PA003 
                                  LEFT JOIN [HQPAS].[BPMS].[BPE_SC001] SC001 ON PA003.JXBM=SC001.JXBM
                                  LEFT JOIN [HQPAS].[BPMS].[BPE_PA001] PA001 ON PA003.FABH=PA001.FABH AND PA003.JXBM=PA001.JXBM
                                  LEFT JOIN [HQPAS].[BPMS].[PMR008_OFFIECES] PMR008 ON PA003.JGBM=PMR008.ID
                            WHERE 1=1");


            //绩效年度编码
            if (!queryParam["jxbm"].IsEmpty())
            {
                strSql.Append(" AND PA003.[JXBM] = @JXBM ");
                parameter.Add(DbParameters.CreateDbParameter("@JXBM", queryParam["jxbm"].ToString()));
            }

            //部门方案名称
            if (!queryParam["keyword"].IsEmpty())
            {
                strSql.Append(" AND [JGFAMC] LIKE @JGFAMC ");
                parameter.Add(DbParameters.CreateDbParameter("@JGFAMC", '%' + queryParam["keyword"].ToString() + '%'));
            }

            // return this.HQPASRepository().FindList<BpePA003Entity>(strSql.ToString(), parameter.ToArray(), pagination);
            return HQPASRepository().FindList<DepPerfSchemeSettingModel>(strSql.ToString(), parameter.ToArray(), pagination);
        }

        IEnumerable<BpePA003Entity> IPerfSchemeDataService.GetDepSchemeDataList(Pagination pagination, string queryJson)
        {
            throw new System.NotImplementedException();
        }
    }
}

