using LeaRun.Application.Entity.PerfImprove;
using LeaRun.Application.Entity.PerfImprove.ViewModel;
using LeaRun.Application.IService.PerfImprove;
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

namespace LeaRun.Application.Service.PerfImprove
{
    /// <summary>
    /// 单位指标分析
    /// </summary>
    public class UnitIndexService : RepositoryFactory, IUnitIndexService
    {
        #region 获取数据
        /// <summary>
        /// 获取年度名称列表
        /// </summary>
        /// <returns>年度名称列表</returns>
        public IEnumerable<ComboBoxModel> GetYearList()
        {
            var strSql = new StringBuilder();
            // 存在数据才显示在下拉框
            //strSql.Append(@"SELECT DISTINCT S.[JXND] MCVALUE, R.[JXBM] BMKEY
            //                FROM [HQPAS].[BPMS].[BPE_RA001] R WITH (NOLOCK)
            //                LEFT JOIN [HQPAS].[BPMS].[BPE_SC001] S WITH (NOLOCK)
            //                ON R.[JXBM] = S.[JXBM]
            //                WHERE R.[STATUS] = '1'
            //                ORDER BY MCVALUE DESC");
            strSql.Append(@"SELECT [JXND] MCVALUE, [JXBM] BMKEY
                            FROM [HQPAS].[BPMS].[BPE_SC001] WITH (NOLOCK)
                            WHERE [STATUS] = '1'
                            ORDER BY MCVALUE DESC");
            return this.HQPASRepository().FindList<ComboBoxModel>(strSql.ToString());
        }

        /// <summary>
        /// 获取目标比较法列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<TargetComparisonModel> GetTargetList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();

            if (queryParam["jxbm"].IsEmpty() || queryParam["jgbm"].IsEmpty())
            {
                return null;
            }

            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT [BSCBH]
                                    ,[BSCMC]
                                    ,[CSFBH]
                                    ,[CSFMC]
                                    ,[KPIBH]
                                    ,[KPIMC]
                                    ,[KPIMBZ]
                                    ,[KPISJZ]
                                    ,[KPILHF]
                            FROM [HQPAS].[BPMS].[BPE_RA001] WITH (NOLOCK)
                            WHERE [STATUS] = '1' ");

            //年度过滤
            if (!queryParam["jxbm"].IsEmpty())
            {
                strSql.Append(" AND [JXBM] = @JXBM ");
                parameter.Add(DbParameters.CreateDbParameter("@JXBM", queryParam["jxbm"].ToString()));
            }

            //科室过滤
            if (!queryParam["jgbm"].IsEmpty())
            {
                strSql.Append(" AND [JGBM] = @JGBM ");
                parameter.Add(DbParameters.CreateDbParameter("@JGBM", queryParam["jgbm"].ToString()));
            }

            //指标名称过滤
            if (!queryParam["kpimc"].IsEmpty())
            {
                string kpimc = queryParam["kpimc"].ToString();
                strSql.Append(" AND [KPIMC] LIKE @KPIMC ");
                parameter.Add(DbParameters.CreateDbParameter("@KPIMC", '%' + kpimc + '%'));
            }

            return this.HQPASRepository().FindList<TargetComparisonModel>(strSql.ToString(), parameter.ToArray(), pagination);
        }

        /// <summary>
        /// 获取纵向比较法列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<VerticalComparisonModel> GetVerticalList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();

            if (queryParam["jxbm"].IsEmpty() || queryParam["jgbm"].IsEmpty())
            {
                return null;
            }

            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT R1.[BSCBH]
                                    ,R1.[BSCMC]
                                    ,R1.[CSFBH]
                                    ,R1.[CSFMC]
                                    ,R1.[KPIBH]
                                    ,R1.[KPIMC]
                                    ,R2.[KPISJZ] SQWCZ
                                    ,R1.[KPISJZ] BQWCZ
                                    ,FLOOR(( R1.[KPISJZ] / R2.[KPISJZ] ) * 100) ZXLHF
                                    FROM [HQPAS].[BPMS].[BPE_RA001] R1 WITH (NOLOCK)
                                    LEFT JOIN [HQPAS].[BPMS].[BPE_RA001] R2 WITH (NOLOCK)
                                    ON R1.[JGBM] = R2.[JGBM]
                                    AND R1.[BSCBH] = R2.[BSCBH]
                                    AND R1.[CSFBH] = R2.[CSFBH]
                                    AND R1.[KPIBH] = R2.[KPIBH]
                                    AND R1.[STATUS] = R2.[STATUS]
                                    AND R2.[JXBM] = 
                                    ( SELECT TOP 1 [JXBM] FROM [HQPAS].[BPMS].[BPE_SC001] WITH (NOLOCK)
                                    WHERE [STATUS] = '1' AND [JXND] = 
                                    ( SELECT ([JXND] - 1) FROM [HQPAS].[BPMS].[BPE_SC001] WITH (NOLOCK)
                                    WHERE [STATUS] = '1' AND [JXBM] = @JXBM )
                                    ORDER BY [JXND] DESC )
                                    WHERE R1.[STATUS] = '1' ");

            //年度过滤
            if (!queryParam["jxbm"].IsEmpty())
            {
                strSql.Append(" AND R1.[JXBM] = @JXBM ");
                parameter.Add(DbParameters.CreateDbParameter("@JXBM", queryParam["jxbm"].ToString()));
            }

            //科室过滤
            if (!queryParam["jgbm"].IsEmpty())
            {
                strSql.Append(" AND R1.[JGBM] = @JGBM ");
                parameter.Add(DbParameters.CreateDbParameter("@JGBM", queryParam["jgbm"].ToString()));
            }

            //指标名称过滤
            if (!queryParam["kpimc"].IsEmpty())
            {
                string kpimc = queryParam["kpimc"].ToString();
                strSql.Append(" AND R1.[KPIMC] LIKE @KPIMC ");
                parameter.Add(DbParameters.CreateDbParameter("@KPIMC", '%' + kpimc + '%'));
            }

            return this.HQPASRepository().FindList<VerticalComparisonModel>(strSql.ToString(), parameter.ToArray(), pagination);
        }

        /// <summary>
        /// 获取横向比较法列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<HorizontalComparisonModel> GetHorizontalList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();

            if (queryParam["jxbm1"].IsEmpty() || queryParam["jgbm1"].IsEmpty() || queryParam["jxbm2"].IsEmpty() || queryParam["jgbm2"].IsEmpty())
            {
                return null;
            }

            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT R1.[BSCBH]
                                    ,R1.[BSCMC]
                                    ,R1.[CSFBH]
                                    ,R1.[CSFMC]
                                    ,R1.[KPIBH]
                                    ,R1.[KPIMC]
                                    ,R1.[KPISJZ] DYKS
                                    ,R2.[KPISJZ] DEKS
                                    ,FLOOR(( R2.[KPISJZ] / (case when R1.[KPISJZ] = '0' then '1' else R1.[KPISJZ] end) ) * 100) HXLHF
                                    FROM [HQPAS].[BPMS].[BPE_RA001] R1 WITH (NOLOCK)
                                    LEFT JOIN [HQPAS].[BPMS].[BPE_RA001] R2 WITH (NOLOCK)
                                    ON R1.[BSCBH] = R2.[BSCBH]
                                    AND R1.[CSFBH] = R2.[CSFBH]
                                    AND R1.[KPIBH] = R2.[KPIBH]
                                    AND R1.[STATUS] = R2.[STATUS]
                                    AND R2.[JXBM] = @JXBM2
                                    AND R2.[JGBM] = @JGBM2
                                    WHERE R1.[STATUS] = '1' ");

            //第一科室过滤
            if (!queryParam["jxbm1"].IsEmpty() && !queryParam["jgbm1"].IsEmpty())
            {
                strSql.Append(" AND R1.[JXBM] = @JXBM1 AND R1.[JGBM] = @JGBM1 ");
                parameter.Add(DbParameters.CreateDbParameter("@JXBM1", queryParam["jxbm1"].ToString()));
                parameter.Add(DbParameters.CreateDbParameter("@JGBM1", queryParam["jgbm1"].ToString()));
            }

            //第二科室过滤
            if (!queryParam["jxbm2"].IsEmpty() && !queryParam["jgbm2"].IsEmpty())
            {
                parameter.Add(DbParameters.CreateDbParameter("@JXBM2", queryParam["jxbm2"].ToString()));
                parameter.Add(DbParameters.CreateDbParameter("@JGBM2", queryParam["jgbm2"].ToString()));
            }

            //指标名称过滤
            if (!queryParam["kpimc"].IsEmpty())
            {
                string kpimc = queryParam["kpimc"].ToString();
                strSql.Append(" AND R1.[KPIMC] LIKE @KPIMC ");
                parameter.Add(DbParameters.CreateDbParameter("@KPIMC", '%' + kpimc + '%'));
            }

            return this.HQPASRepository().FindList<HorizontalComparisonModel>(strSql.ToString(), parameter.ToArray(), pagination);
        }

        #endregion
    }
}
