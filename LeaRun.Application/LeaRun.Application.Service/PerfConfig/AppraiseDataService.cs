using LeaRun.Application.Code;
using LeaRun.Application.Entity.PerfConfig;
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
    /// 评价设置接口实现程序
    /// </summary>
    public class AppraiseDataService : RepositoryFactory, IAppraiseDataService
    {
        /// <summary>
        /// 获取评价方法列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns>评价方法列表</returns>
        public IEnumerable<BpeEA003Entity> GetList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"  SELECT [PJFFBH]
                                    ,[PJFFMC]
                                    ,[PJFFGZ]
                                    ,[REMARK]
                                    ,[CREATOR]
                                    ,[CREATEAT]
                                    ,[MODIFOR]
                                    ,[MODIFYAT]
                                    ,[STATUS]
                                    FROM [HQPAS].[BPMS].[BPE_EA003]
                                    WHERE STATUS = '1' ");
            if (!queryParam["keyword"].IsEmpty())
            {
                strSql.Append(" AND ([PJFFBH] LIKE @KEYWORD OR [PJFFMC] LIKE @KEYWORD) ");
                parameter.Add(DbParameters.CreateDbParameter("@KEYWORD", '%' + queryParam["keyword"].ToString() + '%'));
            }
            return this.HQPASRepository().FindList<BpeEA003Entity>(strSql.ToString(), parameter.ToArray(), pagination);
        }
        /// <summary>
        /// 获取评价方法编码列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns>评价方法列表</returns>
        public IEnumerable<BpeEA003Entity> GetBmList(string queryJson)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT [PJFFBH]
                                  ,[PJFFMC]
                            FROM [HQPAS].[BPMS].[BPE_EA003]
                            WHERE [STATUS] = '1'
                            ORDER BY [PJFFBH]");
            return this.HQPASRepository().FindList<BpeEA003Entity>(strSql.ToString());
        }
        /// <summary>
        /// 获取评价方法实体
        /// </summary>
        /// <param name="pjffbh"></param>
        /// <returns></returns>
        public BpeEA003Entity GetEntity(string pjffbh)
        {
            return this.HQPASRepository().FindEntity<BpeEA003Entity>(e => e.PJFFBH == pjffbh);
        }
        /// <summary>
        /// 获取指标等级列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<BpeEA001Entity> GetPerfLevelDataList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"  SELECT M.[XH]
                              ,Y.[JXND] AS [YEAR]
                              ,M.[DJMC]
                              ,M.[FZXX]
                              ,M.[FZSX]
                              ,M.[CREATOR]
                              ,M.[CREATEAT]
                              ,M.[MODIFOR]
                              ,M.[MODIFYAT]
                              ,M.[STATUS]
                              FROM [HQPAS].[BPMS].[BPE_EA001] M 
                              INNER JOIN (SELECT [JXBM]
                          			         ,[JXND]
                          			   FROM [HQPAS].[BPMS].[BPE_SC001]
                          			   WHERE STATUS = '1') Y ON M.[YEAR] = Y.JXBM ");
            //等级名称
            if (!queryParam["keyword"].IsEmpty())
            {
                strSql.Append(" AND (M.[DJMC] LIKE @KEYWORD OR [XH] LIKE @KEYWORD) ");
                parameter.Add(DbParameters.CreateDbParameter("@KEYWORD", '%' + queryParam["keyword"].ToString() + '%'));
            }
            //绩效年度
            if (!queryParam["YEAR"].IsEmpty())
            {
                strSql.Append(" AND M.[YEAR] = @YEAR ");
                parameter.Add(DbParameters.CreateDbParameter("@YEAR", queryParam["YEAR"].ToString()));
            }
            return this.HQPASRepository().FindList<BpeEA001Entity>(strSql.ToString(), parameter.ToArray(), pagination);
        }

        /// <summary>
        /// 综合等级设置列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<BpeEA002Entity> GetSynLevelDataList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"  SELECT M.[XH]
                              ,Y.[JXND] AS [YEAR]
                              ,M.[DJMC]
                              ,M.[FZXX]
                              ,M.[FZSX]
                              ,M.[CREATOR]
                              ,M.[CREATEAT]
                              ,M.[MODIFOR]
                              ,M.[MODIFYAT]
                              ,M.[STATUS]
                              FROM [HQPAS].[BPMS].[BPE_EA002] M
                              INNER JOIN (SELECT [JXBM]
                          			         ,[JXND]
                          			   FROM [HQPAS].[BPMS].[BPE_SC001]
                          			   WHERE STATUS = '1') Y ON M.[YEAR] = Y.JXBM ");
            //等级名称
            if (!queryParam["keyword"].IsEmpty())
            {
                strSql.Append(" AND (M.[DJMC] LIKE @KEYWORD OR [XH] LIKE @KEYWORD) ");
                parameter.Add(DbParameters.CreateDbParameter("@KEYWORD", '%' + queryParam["keyword"].ToString() + '%'));
            }
            //绩效年度
            if (!queryParam["YEAR"].IsEmpty())
            {
                strSql.Append(" AND M.[YEAR] = @YEAR ");
                parameter.Add(DbParameters.CreateDbParameter("@YEAR", queryParam["YEAR"].ToString()));
            }
            return this.HQPASRepository().FindList<BpeEA002Entity>(strSql.ToString(), parameter.ToArray(), pagination);
        }
    }
}
