using LeaRun.Application.Code;
using LeaRun.Application.Entity.PerfConfig.ViewModel;
using LeaRun.Application.IService.PerfConfig;
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

namespace LeaRun.Application.Service.PerfConfig
{
    /// <summary>
    /// 数据项列表信息
    /// </summary>
    public class StandardDataService : RepositoryFactory, IStandardDataService
    {
        /// <summary>
        /// 获取数据项列表
        /// </summary>
        /// <param name="queryJson">查询条件</param>
        /// <returns>数据项列表</returns>
        public IEnumerable<StandardDataModel> GetKeyValueList(string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT [JCSJBM]
                                 , [JCSJMC]
                            FROM [HQPAS].[BPMS].[BPC_SM001] M
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
                            WHERE [STATUS] = '1' ");
            //一级分类ID
            if (!queryParam["typeid"].IsEmpty())
            {
                strSql.Append(" AND T.TYPEID = @TYPEID ");
                parameter.Add(DbParameters.CreateDbParameter("@TYPEID", queryParam["typeid"].ToString()));
            }
            //二级分类ID
            if (!queryParam["sectypeid"].IsEmpty())
            {
                strSql.Append(" AND SECTYPEID = @SECTYPEID ");
                parameter.Add(DbParameters.CreateDbParameter("@SECTYPEID", queryParam["sectypeid"].ToString()));
            }
            //查询条件
            if (!queryParam["keyword"].IsEmpty())
            {
                strSql.Append(" AND [JCSJMC] LIKE @KEYWORD ");
                parameter.Add(DbParameters.CreateDbParameter("@KEYWORD", '%' + queryParam["keyword"].ToString() + '%'));
            }
            return this.HQPASRepository().FindList<StandardDataModel>(strSql.ToString(), parameter.ToArray());
        }

        /// <summary>
        /// 获取数据项列表
        /// </summary>
        /// <param name="pagination">分页条件</param>
        /// <param name="queryJson">查询条件</param>
        /// <returns>数据项列表</returns>
        public IEnumerable<StandardDataModel> GetList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT [JCSJBM]
                                 , [JCSJMC]
                                 , U.[NAME] JLDWNAME
                                 , R.[NAME] YXPLNAME
                                 , [TJXS]
                                 , T.[NAME] TYPENAME
                                 , T.[SECNAME] SECTYPENAME
                                 , [PX]
                                 , [STATUS]
                                 , [FXQBM]
                            FROM [HQPAS].[BPMS].[BPC_SM001] M
                            LEFT JOIN (SELECT [CODE]
                                            , [NAME]
                                       FROM [HQPAS].[BPMS].[S103_CODE]
                                       WHERE TYPEID = @UnitType AND STATUS = '1') U ON M.[JLDW] = U.CODE
                            LEFT JOIN (SELECT [CODE]
                                            , [NAME]
                                       FROM [HQPAS].[BPMS].[S103_CODE]
                                       WHERE TYPEID = @FrequencyType AND STATUS = '1') R ON M.[YXPL] = R.CODE
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
                            WHERE 1 = 1 ");
            parameter.Add(DbParameters.CreateDbParameter("@UnitType", Config.GetValue("UnitType")));
            parameter.Add(DbParameters.CreateDbParameter("@FrequencyType", Config.GetValue("FrequencyType")));
            //一级分类ID
            if (!queryParam["typeid"].IsEmpty())
            {
                strSql.Append(" AND T.TYPEID = @TYPEID ");
                parameter.Add(DbParameters.CreateDbParameter("@TYPEID", queryParam["typeid"].ToString()));
            }
            //二级分类ID
            if (!queryParam["sectypeid"].IsEmpty())
            {
                strSql.Append(" AND SECTYPEID = @SECTYPEID ");
                parameter.Add(DbParameters.CreateDbParameter("@SECTYPEID", queryParam["sectypeid"].ToString()));
            }
            //查询条件
            if (!queryParam["keyword"].IsEmpty())
            {
                strSql.Append(" AND [JCSJMC] LIKE @KEYWORD ");
                parameter.Add(DbParameters.CreateDbParameter("@KEYWORD", '%' + queryParam["keyword"].ToString() + '%'));
            }
            return this.HQPASRepository().FindList<StandardDataModel>(strSql.ToString(), parameter.ToArray(), pagination);
        }

        /// <summary>
        /// 获取分析器数据项列表
        /// </summary>
        /// <param name="pagination">分页条件</param>
        /// <param name="queryJson">查询条件</param>
        /// <returns>数据项列表</returns>
        public IEnumerable<StandardDataModel> GetListForAnalyzer(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT [JCSJBM]
                                  ,[JCSJMC]
                            	  ,[FXQBM]
                                  ,T.[NAME] SECTYPENAME
                            FROM [HQPAS].[BPMS].[BPC_SM001] M
                            LEFT JOIN (SELECT [TYPEID]
                                             ,[NAME]
                                       FROM [HQPAS].[BPMS].[BPC_SM002]
                            	       WHERE [GRADE] = '2') T ON M.[TYPEID] = T.[TYPEID]
                            WHERE [STATUS] = '1' AND 1 = 1 ");
            //是否配置分析器
            if (!queryParam["set"].IsEmpty())
            {
                string set = queryParam["set"].ToString().Trim();
                if (set == "1")
                {
                    strSql.Append(" AND [FXQBM] IS NOT NULL AND [FXQBM] <> '' ");
                }
                else if (set == "0")
                {
                    strSql.Append(" AND ([FXQBM] IS NULL OR [FXQBM] = '') ");
                }
            }
            //查询条件
            if (!queryParam["keyword"].IsEmpty())
            {
                strSql.Append(" AND [JCSJMC] LIKE @KEYWORD ");
                parameter.Add(DbParameters.CreateDbParameter("@KEYWORD", '%' + queryParam["keyword"].ToString() + '%'));
            }
            return this.HQPASRepository().FindList<StandardDataModel>(strSql.ToString(), parameter.ToArray(), pagination);
        }

        /// <summary>
        /// 数据项绑定分析器
        /// </summary>
        /// <param name="jcsjbm">数据项编码</param>
        /// <param name="fxqbm">分析器编码</param>
        public void BindAnalyzer(string jcsjbm, string fxqbm)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"UPDATE [BPMS].[BPC_SM001]
                              SET [FXQBM] = @FXQBM
                                 ,[MODIFOR] = @MODIFOR
                                 ,[MODIFYAT] = @MODIFYAT
                            WHERE [JCSJBM] = @JCSJBM");
            parameter.Add(DbParameters.CreateDbParameter("@FXQBM", fxqbm));
            parameter.Add(DbParameters.CreateDbParameter("@MODIFOR", OperatorProvider.Provider.Current().UserName));
            parameter.Add(DbParameters.CreateDbParameter("@MODIFYAT", DateTime.Now));
            parameter.Add(DbParameters.CreateDbParameter("@JCSJBM", jcsjbm));

            this.HQPASRepository().ExecuteBySql(strSql.ToString(), parameter.ToArray());
        }
    }
}