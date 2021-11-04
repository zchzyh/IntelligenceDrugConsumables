using LeaRun.Application.Entity.DataAnalysis.ViewModel;
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

namespace LeaRun.Application.Service.DataAnalysis
{
    /// <summary>
    /// 数据分析
    /// </summary>
    public class DataAnalysisService : RepositoryFactory, IDataAnalysisService
    {
        /// <summary>
        /// 获取月度分析数据列表
        /// </summary>
        /// <param name="pagination">分页条件</param>
        /// <param name="queryJson">查询条件</param>
        /// <returns>月度分析数据</returns>
        public IEnumerable<DataAnalysisModel> GetMonthlyList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT [XH]
                                  ,[ND]
                                  ,[YD]
                                  ,M.[METNAME]
                                  ,O.[OFFICENAME] Department
                                  ,U.NAME UNITNAME
                                  ,[YSJZ] CurrentPeriodData
                                  ,(SELECT SUM(S.[YSJZ])
                                    FROM [HQPAS].[BPMS].[BPC_SM005] M
                                    LEFT JOIN [HQPAS].[BPMS].[BPC_SM005] S ON M.[ND] = S.[ND]
                                    										AND M.[JXBM] = S.[JXBM]
                                    										AND M.[YSJBM] = S.[YSJBM]
                                    										AND M.[ZCDXLX] = S.[ZCDXLX]
                                    										AND M.[ZCDXBM] = S.[ZCDXBM]
                                    WHERE S.[STATUS] = '1' AND M.[XH] = D.[XH]) YearData
                            FROM [HQPAS].[BPMS].[BPC_SM005] D
                            INNER JOIN [HQPAS].[BPMS].[BPE_MA001] M ON D.JXBM = M.JXND AND D.[YSJBM] = M.[METCODE]
                            LEFT JOIN (SELECT [CODE]
                                             ,[NAME]
                                       FROM [HQPAS].[BPMS].[S103_CODE]
                                       WHERE TYPEID = @UnitType AND STATUS = '1') U ON M.UNIT = U.CODE
                            LEFT JOIN [HQPAS].[BPMS].[PMR008_OFFIECES] O ON D.[ZCDXBM] = O.[ID]
                            WHERE D.[STATUS] = '1' ");
            parameter.Add(DbParameters.CreateDbParameter("@UnitType", Config.GetValue("UnitType")));
            //绩效年度
            if (!queryParam["jxbm"].IsEmpty())
            {
                strSql.Append(" AND D.[JXBM] = @JXBM ");
                parameter.Add(DbParameters.CreateDbParameter("@JXBM", queryParam["jxbm"].ToString()));
            }
            //月度
            if (!queryParam["yd"].IsEmpty())
            {
                strSql.Append(" AND D.[YD] = @YD ");
                parameter.Add(DbParameters.CreateDbParameter("@YD", queryParam["yd"].ToDecimal()));
            }
            //科室编码
            if (!queryParam["deptcode"].IsEmpty())
            {
                strSql.Append(" AND D.[ZCDXLX] = '2' AND D.[ZCDXBM] = @ZCDXBM ");
                parameter.Add(DbParameters.CreateDbParameter("@ZCDXBM", queryParam["deptcode"].ToString()));
            }
            //元数据编码
            if (!queryParam["metcode"].IsEmpty())
            {
                strSql.Append(" AND M.[METCODE] = @METCODE ");
                parameter.Add(DbParameters.CreateDbParameter("@METCODE", queryParam["metcode"].ToString()));
            }
            return this.HQPASRepository().FindList<DataAnalysisModel>(strSql.ToString(), parameter.ToArray(), pagination);
        }

        /// <summary>
        /// 获取同比分析数据列表
        /// </summary>
        /// <param name="pagination">分页条件</param>
        /// <param name="queryJson">查询条件</param>
        /// <returns>同比分析数据</returns>
        public IEnumerable<DataAnalysisModel> GetYoyList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT [XH]
                                  ,[ND]
                                  ,[YD]
                                  ,M.[METNAME]
                                  ,O.[OFFICENAME] Department
                                  ,U.NAME UNITNAME
                                  ,[YSJZ] CurrentPeriodData
                                  ,(SELECT SUM(S.[YSJZ])
                                    FROM [HQPAS].[BPMS].[BPC_SM005] M
                                    LEFT JOIN [HQPAS].[BPMS].[BPC_SM005] S ON M.[YD] = S.[YD]
                                    										AND M.[YSJBM] = S.[YSJBM]
                                    										AND M.[ZCDXLX] = S.[ZCDXLX]
                                    										AND M.[ZCDXBM] = S.[ZCDXBM]
                                    WHERE S.[STATUS] = '1' AND S.[ND] = (M.[ND] - 1) AND M.[XH] = D.[XH]) LastPeriodData
                            FROM [HQPAS].[BPMS].[BPC_SM005] D
                            INNER JOIN [HQPAS].[BPMS].[BPE_MA001] M ON D.JXBM = M.JXND AND D.[YSJBM] = M.[METCODE]
                            LEFT JOIN (SELECT [CODE]
                                             ,[NAME]
                                       FROM [HQPAS].[BPMS].[S103_CODE]
                                       WHERE TYPEID = @UnitType AND STATUS = '1') U ON M.UNIT = U.CODE
                            LEFT JOIN [HQPAS].[BPMS].[PMR008_OFFIECES] O ON D.[ZCDXBM] = O.[ID]
                            WHERE D.[STATUS] = '1' ");
            parameter.Add(DbParameters.CreateDbParameter("@UnitType", Config.GetValue("UnitType")));
            //绩效年度
            if (!queryParam["jxbm"].IsEmpty())
            {
                strSql.Append(" AND D.[JXBM] = @JXBM ");
                parameter.Add(DbParameters.CreateDbParameter("@JXBM", queryParam["jxbm"].ToString()));
            }
            //月度
            if (!queryParam["yd"].IsEmpty())
            {
                strSql.Append(" AND D.[YD] = @YD ");
                parameter.Add(DbParameters.CreateDbParameter("@YD", queryParam["yd"].ToDecimal()));
            }
            //科室编码
            if (!queryParam["deptcode"].IsEmpty())
            {
                strSql.Append(" AND D.[ZCDXLX] = '2' AND D.[ZCDXBM] = @ZCDXBM ");
                parameter.Add(DbParameters.CreateDbParameter("@ZCDXBM", queryParam["deptcode"].ToString()));
            }
            //元数据编码
            if (!queryParam["metcode"].IsEmpty())
            {
                strSql.Append(" AND M.[METCODE] = @METCODE ");
                parameter.Add(DbParameters.CreateDbParameter("@METCODE", queryParam["metcode"].ToString()));
            }
            return this.HQPASRepository().FindList<DataAnalysisModel>(strSql.ToString(), parameter.ToArray(), pagination);
        }

        /// <summary>
        /// 获取环比分析数据列表
        /// </summary>
        /// <param name="pagination">分页条件</param>
        /// <param name="queryJson">查询条件</param>
        /// <returns>环比分析数据</returns>
        public IEnumerable<DataAnalysisModel> GetMomList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT [XH]
                                  ,[ND]
                                  ,[YD]
                                  ,M.[METNAME]
                                  ,O.[OFFICENAME] Department
                                  ,U.NAME UNITNAME
                                  ,[YSJZ] CurrentPeriodData
                                  ,(SELECT SUM(S.[YSJZ])
                                    FROM [HQPAS].[BPMS].[BPC_SM005] M
                                    LEFT JOIN [HQPAS].[BPMS].[BPC_SM005] S ON M.[JXBM] = S.[JXBM]
                                    										AND M.[YSJBM] = S.[YSJBM]
                                    										AND M.[ZCDXLX] = S.[ZCDXLX]
                                    										AND M.[ZCDXBM] = S.[ZCDXBM]
                                    WHERE S.[STATUS] = '1' AND ((M.[YD]<>1 AND M.[ND]=S.[ND] AND S.[YD]=(M.[YD]-1)) OR (M.[YD]=1 AND S.[ND]=(M.[ND]-1) AND S.[YD]=12)) AND M.[XH] = D.[XH]) LastPeriodData
                            FROM [HQPAS].[BPMS].[BPC_SM005] D
                            INNER JOIN [HQPAS].[BPMS].[BPE_MA001] M ON D.JXBM = M.JXND AND D.[YSJBM] = M.[METCODE]
                            LEFT JOIN (SELECT [CODE]
                                             ,[NAME]
                                       FROM [HQPAS].[BPMS].[S103_CODE]
                                       WHERE TYPEID = @UnitType AND STATUS = '1') U ON M.UNIT = U.CODE
                            LEFT JOIN [HQPAS].[BPMS].[PMR008_OFFIECES] O ON D.[ZCDXBM] = O.[ID]
                            WHERE D.[STATUS] = '1' ");
            parameter.Add(DbParameters.CreateDbParameter("@UnitType", Config.GetValue("UnitType")));
            //绩效年度
            if (!queryParam["jxbm"].IsEmpty())
            {
                strSql.Append(" AND D.[JXBM] = @JXBM ");
                parameter.Add(DbParameters.CreateDbParameter("@JXBM", queryParam["jxbm"].ToString()));
            }
            //月度
            if (!queryParam["yd"].IsEmpty())
            {
                strSql.Append(" AND D.[YD] = @YD ");
                parameter.Add(DbParameters.CreateDbParameter("@YD", queryParam["yd"].ToDecimal()));
            }
            //科室编码
            if (!queryParam["deptcode"].IsEmpty())
            {
                strSql.Append(" AND D.[ZCDXLX] = '2' AND D.[ZCDXBM] = @ZCDXBM ");
                parameter.Add(DbParameters.CreateDbParameter("@ZCDXBM", queryParam["deptcode"].ToString()));
            }
            //元数据编码
            if (!queryParam["metcode"].IsEmpty())
            {
                strSql.Append(" AND M.[METCODE] = @METCODE ");
                parameter.Add(DbParameters.CreateDbParameter("@METCODE", queryParam["metcode"].ToString()));
            }
            return this.HQPASRepository().FindList<DataAnalysisModel>(strSql.ToString(), parameter.ToArray(), pagination);
        }
    }
}