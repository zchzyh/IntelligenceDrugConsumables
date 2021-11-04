using LeaRun.Application.Entity.CollectionAnalysis.ViewModel;
using LeaRun.Application.IService.CollectionAnalysis;
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
    /// 采集数据分析
    /// </summary>
    public class CollectionDataAnalysisService : RepositoryFactory, ICollectionDataAnalysisService
    {
        /// <summary>
        /// 获取数据项年度分析列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<StandardDataAnalysisModel> GetStandardDataYearAnalysisList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT [XH]
                                  ,[ND]
                                  ,[YD]
                            	  ,T.[NAME] TYPENAME
                                  ,T.[SECNAME] SECTYPENAME
                            	  ,M.[JCSJMC]
                                  ,[JCSJZ]
                                  ,U.[NAME] UNITNAME
                            FROM [HQPAS].[BPMS].[BPC_SM004] D
                            INNER JOIN [HQPAS].[BPMS].[BPC_SM001] M ON D.[JCSJBM] = M.[JCSJBM]
                            LEFT JOIN (SELECT [CODE]
                                            , [NAME]
                                       FROM [HQPAS].[BPMS].[S103_CODE]
                                       WHERE TYPEID = @UnitType AND STATUS = '1') U ON M.[JLDW] = U.CODE
                            LEFT JOIN (SELECT S2.[TYPEID] SECTYPEID
                            		        , S2.[NAME] SECNAME
                            		        , S1.[TYPEID] TYPEID
                            		        , S1.[NAME] NAME
                            		   FROM [HQPAS].[BPMS].[BPC_SM002] S2
                            		   LEFT JOIN (SELECT [TYPEID]
                            		                  	,[NAME]
                            		                  	,[PARENT]
                            		                  	,[GRADE]
                            		                  	,[STATUS]
                            		              FROM [HQPAS].[BPMS].[BPC_SM002]
                            		              WHERE GRADE = '1' AND STATUS = '1') S1 ON S2.PARENT = S1.TYPEID
                            		   WHERE S2.GRADE = '2' AND S2.STATUS = '1') T ON M.TYPEID = T.SECTYPEID
                            WHERE D.[STATUS] = '1' AND [YD] = 0 ");
            parameter.Add(DbParameters.CreateDbParameter("@UnitType", Config.GetValue("UnitType")));
            //绩效年度
            if (!queryParam["jxbm"].IsEmpty())
            {
                strSql.Append(" AND D.[JXBM] = @JXBM ");
                parameter.Add(DbParameters.CreateDbParameter("@JXBM", queryParam["jxbm"].ToString()));
            }
            //一级分类ID
            if (!queryParam["typeid"].IsEmpty())
            {
                strSql.Append(" AND T.[TYPEID] = @TYPEID ");
                parameter.Add(DbParameters.CreateDbParameter("@TYPEID", queryParam["typeid"].ToString()));
            }
            //二级分类ID
            if (!queryParam["sectypeid"].IsEmpty())
            {
                strSql.Append(" AND T.[SECTYPEID] = @SECTYPEID ");
                parameter.Add(DbParameters.CreateDbParameter("@SECTYPEID", queryParam["sectypeid"].ToString()));
            }
            //数据项名称
            if (!queryParam["keyword"].IsEmpty())
            {
                strSql.Append(" AND M.[JCSJMC] LIKE @JCSJMC ");
                parameter.Add(DbParameters.CreateDbParameter("@JCSJMC", '%' + queryParam["keyword"].ToString() + '%'));
            }
            return this.HQPASRepository().FindList<StandardDataAnalysisModel>(strSql.ToString(), parameter.ToArray(), pagination);
        }

        /// <summary>
        /// 获取数据项月度分析列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<StandardDataAnalysisModel> GetStandardDataMonthAnalysisList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT [XH]
                                  ,D.[JXBM]
                                  ,[ND]
                                  ,[YD]
                                  ,D.[JCSJBM]
                            	  ,M.[JCSJMC]
                                  ,[JCSJZ]
                                  ,U.[NAME] UNITNAME
                            FROM [HQPAS].[BPMS].[BPC_SM004] D
                            INNER JOIN [HQPAS].[BPMS].[BPC_SM001] M ON D.[JCSJBM] = M.[JCSJBM]
                            LEFT JOIN (SELECT S2.[TYPEID] SECTYPEID
                                            , S2.[NAME] SECNAME
                                            , S1.[TYPEID] TYPEID
                                            , S1.[NAME] NAME
                                       FROM [HQPAS].[BPMS].[BPC_SM002] S2
                                       LEFT JOIN (SELECT [TYPEID]
                                                      	,[NAME]
                                                      	,[PARENT]
                                                      	,[GRADE]
                                                      	,[STATUS]
                                                  FROM [HQPAS].[BPMS].[BPC_SM002]
                                                  WHERE GRADE = '1' AND STATUS = '1') S1 ON S2.PARENT = S1.TYPEID
                                       WHERE S2.GRADE = '2' AND S2.STATUS = '1') T ON M.TYPEID = T.SECTYPEID
                            LEFT JOIN (SELECT [CODE]
                                            , [NAME]
                                       FROM [HQPAS].[BPMS].[S103_CODE]
                                       WHERE TYPEID = @UnitType AND STATUS = '1') U ON M.[JLDW] = U.CODE
                            WHERE D.[STATUS] = '1' AND [YD] <> 0 ");
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
            //一级分类
            if (!queryParam["firstType"].IsEmpty())
            {
                strSql.Append(" AND T.[TYPEID] = @TYPEID ");
                parameter.Add(DbParameters.CreateDbParameter("@TYPEID", queryParam["firstType"].ToString()));
            }
            //二级分类
            if (!queryParam["secType"].IsEmpty())
            {
                strSql.Append(" AND T.[SECTYPEID] = @SECTYPEID ");
                parameter.Add(DbParameters.CreateDbParameter("@SECTYPEID", queryParam["secType"].ToString()));
            }
            //基础数据编码
            if (!queryParam["jcsjbm"].IsEmpty())
            {
                strSql.Append(" AND D.[JCSJBM] = @JCSJBM ");
                parameter.Add(DbParameters.CreateDbParameter("@JCSJBM", queryParam["jcsjbm"].ToString()));
            }
            //数据项名称
            if (!queryParam["keyword"].IsEmpty())
            {
                strSql.Append(" AND M.[JCSJMC] LIKE @JCSJMC ");
                parameter.Add(DbParameters.CreateDbParameter("@JCSJMC", '%' + queryParam["keyword"].ToString() + '%'));
            }
            return this.HQPASRepository().FindList<StandardDataAnalysisModel>(strSql.ToString(), parameter.ToArray(), pagination);
        }
    }
}