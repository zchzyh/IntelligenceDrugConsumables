using LeaRun.Application.Entity.CollectionManage;
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
    /// 数据修正法
    /// </summary>
    public class DataCorrectService : RepositoryFactory, IDataCorrectService
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
            //strSql.Append(@"SELECT DISTINCT CAST([JXND] AS REAL) MCVALUE, CAST([JXND] AS REAL) BMKEY
            //                FROM [HQPAS].[BPMS].[BPC_SC004] WITH (NOLOCK)
            //                WHERE [STATUS] = '1'
            //                ORDER BY MCVALUE DESC");
            strSql.Append(@"SELECT [JXND] MCVALUE, [JXND] BMKEY
                            FROM [HQPAS].[BPMS].[BPE_SC001] WITH (NOLOCK)
                            WHERE [STATUS] = '1'
                            ORDER BY MCVALUE DESC");
            return this.HQPASRepository().FindList<ComboBoxModel>(strSql.ToString());
        }

        /// <summary>
        /// 获取所属类别名称列表
        /// </summary>
        /// <returns>所属类别名称列表</returns>
        public IEnumerable<ComboBoxModel> GetTypeList()
        {
            var strSql = new StringBuilder();
            strSql.Append(@"SELECT NAME MCVALUE, TYPEID BMKEY
                            FROM [HQPAS].[BPMS].[BPC_SM002] WITH (NOLOCK)
                            WHERE [PARENT] IS NULL AND [GRADE] = '1' AND [STATUS] = '1'
                            ORDER BY BMKEY");
            return this.HQPASRepository().FindList<ComboBoxModel>(strSql.ToString());
        }

        /// <summary>
        /// 获取系数修正法列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<CoefficientCorrectModel> GetCoefficientList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT C4.[XH]
                                    ,CAST(C4.[JXND] AS REAL) JXND
                                    ,CAST(C4.[JXYD] AS REAL) JXYD
                                    ,M.[NAME] SSLBNAME
                                    ,O.[OFFICECODE]
                                    ,O.[OFFICENAME]
                                    ,P.[CJBQM]
                                    ,C4.[HCODE]
                                    ,RESULT.[NAME] HNAME
                                    ,C4.[LCODE]
                                    ,C3.[LMC] LNAME
                                    ,CAST(C4.[CCVALUE] AS REAL) CCVALUE
                                    ,CAST(C4.[XSVALUE] AS REAL) XSVALUE
                                    ,CAST(C4.[SJVALUE] AS REAL) SJVALUE
                            FROM [HQPAS].[BPMS].[BPC_SC004] C4 WITH (NOLOCK)
                            LEFT JOIN ( SELECT C1.[HCODE],C1.NAME, C1.[STATUS], C2.CJBBM, C2.ND
										FROM [HQPAS].[BPMS].[BPC_SC001] C1 WITH (NOLOCK)
										LEFT JOIN [HQPAS].[BPMS].[BPC_SC002] C2 WITH (NOLOCK)
										ON C1.HXBM = C2.HXBM AND C1.[STATUS] = C2.[STATUS]) RESULT
                            ON C4.[CJBBM] = RESULT.[CJBBM]
                            AND C4.[JXND] = RESULT.[ND]
                            AND C4.[HCODE] = RESULT.[HCODE]
                            LEFT JOIN [HQPAS].[BPMS].[BPC_SC003] C3 WITH (NOLOCK)
                            ON C4.[CJBBM] = C3.[CJBBM]
                            AND C4.[JXND] = C3.[ND]
                            AND C4.[LCODE] = C3.[LCODE]
                            LEFT JOIN [HQPAS].[BPMS].[PMR008_OFFIECES] O WITH (NOLOCK)
                            ON C4.[ORGID] = O.[ID]
                            LEFT JOIN [HQPAS].[BPMS].[BPC_SP001] P WITH (NOLOCK)
                            ON C4.[CJBBM] = P.[CJBBM]
                            LEFT JOIN [HQPAS].[BPMS].[BPC_SM002] M WITH (NOLOCK)
                            ON P.[SSLB] = M.[TYPEID]
                            WHERE C4.[STATUS] = '1'
                            AND RESULT.[STATUS] = '1'
                            AND C3.[STATUS] = '1'
                            AND P.[STATUS] = '1'
                            AND M.[STATUS] = '1' ");

            //年度过滤
            if (!queryParam["jxnd"].IsEmpty())
            {
                strSql.Append(" AND C4.[JXND] = @JXND ");
                parameter.Add(DbParameters.CreateDbParameter("@JXND", queryParam["jxnd"].ToString()));
            }

            //月度过滤
            if (!queryParam["jxyd"].IsEmpty())
            {
                strSql.Append(" AND C4.[JXYD] = @JXYD ");
                parameter.Add(DbParameters.CreateDbParameter("@JXYD", queryParam["jxyd"].ToString()));
            }

            //所属类别过滤
            if (!queryParam["typeid"].IsEmpty())
            {
                strSql.Append(" AND SUBSTRING(P.[SSLB], 1, 1) = @TYPEID ");
                parameter.Add(DbParameters.CreateDbParameter("@TYPEID", queryParam["typeid"].ToString()));
            }

            //行名过滤
            if (!queryParam["hname"].IsEmpty())
            {
                string hname = queryParam["hname"].ToString();
                strSql.Append(" AND RESULT.[NAME] LIKE @HNAME ");
                parameter.Add(DbParameters.CreateDbParameter("@HNAME", '%' + hname + '%'));
            }

            //列名过滤
            if (!queryParam["lname"].IsEmpty())
            {
                string lname = queryParam["lname"].ToString();
                strSql.Append(" AND C3.[LMC] LIKE @LNAME ");
                parameter.Add(DbParameters.CreateDbParameter("@LNAME", '%' + lname + '%'));
            }

            //采集表名称过滤
            if (!queryParam["cjbmc"].IsEmpty())
            {
                string cjbmc = queryParam["cjbmc"].ToString();
                strSql.Append(" AND P.[CJBQM] LIKE @CJBMC ");
                parameter.Add(DbParameters.CreateDbParameter("@CJBMC", '%' + cjbmc + '%'));
            }

            return this.HQPASRepository().FindList<CoefficientCorrectModel>(strSql.ToString(), parameter.ToArray(), pagination);
        }

        /// <summary>
        /// 获取归零修正法列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<ZeroingCorrectModel> GetZeroingList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT C4.[XH]
                                    ,CAST(C4.[JXND] AS REAL) JXND
                                    ,CAST(C4.[JXYD] AS REAL) JXYD
                                    ,M.[NAME] SSLBNAME
                                    ,O.[OFFICECODE]
                                    ,O.[OFFICENAME]
                                    ,P.[CJBQM]
                                    ,C4.[HCODE]
                                    ,RESULT.[NAME] HNAME
                                    ,C4.[LCODE]
                                    ,C3.[LMC] LNAME
                                    ,CAST(C4.[CCVALUE] AS REAL) CCVALUE
                                    ,CAST(C4.[SJVALUE] AS REAL) SJVALUE
                            FROM [HQPAS].[BPMS].[BPC_SC004] C4 WITH (NOLOCK)
                            LEFT JOIN ( SELECT C1.[HCODE],C1.NAME, C1.[STATUS], C2.CJBBM, C2.ND
										FROM [HQPAS].[BPMS].[BPC_SC001] C1 WITH (NOLOCK)
										LEFT JOIN [HQPAS].[BPMS].[BPC_SC002] C2 WITH (NOLOCK)
										ON C1.HXBM = C2.HXBM AND C1.[STATUS] = C2.[STATUS]) RESULT
                            ON C4.[CJBBM] = RESULT.[CJBBM]
                            AND C4.[JXND] = RESULT.[ND]
                            AND C4.[HCODE] = RESULT.[HCODE]
                            LEFT JOIN [HQPAS].[BPMS].[BPC_SC003] C3 WITH (NOLOCK)
                            ON C4.[CJBBM] = C3.[CJBBM]
                            AND C4.[JXND] = C3.[ND]
                            AND C4.[LCODE] = C3.[LCODE]
                            LEFT JOIN [HQPAS].[BPMS].[PMR008_OFFIECES] O WITH (NOLOCK)
                            ON C4.[ORGID] = O.[ID]
                            LEFT JOIN [HQPAS].[BPMS].[BPC_SP001] P WITH (NOLOCK)
                            ON C4.[CJBBM] = P.[CJBBM]
                            LEFT JOIN [HQPAS].[BPMS].[BPC_SM002] M WITH (NOLOCK)
                            ON P.[SSLB] = M.[TYPEID]
                            WHERE C4.[STATUS] = '1'
                            AND RESULT.[STATUS] = '1'
                            AND C3.[STATUS] = '1'
                            AND P.[STATUS] = '1'
                            AND M.[STATUS] = '1' ");

            //年度过滤
            if (!queryParam["jxnd"].IsEmpty())
            {
                strSql.Append(" AND C4.[JXND] = @JXND ");
                parameter.Add(DbParameters.CreateDbParameter("@JXND", queryParam["jxnd"].ToString()));
            }

            //月度过滤
            if (!queryParam["jxyd"].IsEmpty())
            {
                strSql.Append(" AND C4.[JXYD] = @JXYD ");
                parameter.Add(DbParameters.CreateDbParameter("@JXYD", queryParam["jxyd"].ToString()));
            }

            //所属类别过滤
            if (!queryParam["typeid"].IsEmpty())
            {
                strSql.Append(" AND SUBSTRING(P.[SSLB], 1, 1) = @TYPEID ");
                parameter.Add(DbParameters.CreateDbParameter("@TYPEID", queryParam["typeid"].ToString()));
            }

            //行名过滤
            if (!queryParam["hname"].IsEmpty())
            {
                string hname = queryParam["hname"].ToString();
                strSql.Append(" AND RESULT.[NAME] LIKE @HNAME ");
                parameter.Add(DbParameters.CreateDbParameter("@HNAME", '%' + hname + '%'));
            }

            //列名过滤
            if (!queryParam["lname"].IsEmpty())
            {
                string lname = queryParam["lname"].ToString();
                strSql.Append(" AND C3.[LMC] LIKE @LNAME ");
                parameter.Add(DbParameters.CreateDbParameter("@LNAME", '%' + lname + '%'));
            }

            //采集表名称过滤
            if (!queryParam["cjbmc"].IsEmpty())
            {
                string cjbmc = queryParam["cjbmc"].ToString();
                strSql.Append(" AND P.[CJBQM] LIKE @CJBMC ");
                parameter.Add(DbParameters.CreateDbParameter("@CJBMC", '%' + cjbmc + '%'));
            }

            return this.HQPASRepository().FindList<ZeroingCorrectModel>(strSql.ToString(), parameter.ToArray(), pagination);
        }


        /// <summary>
        /// 获取补录修正法列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<SupplementCorrectModel> GetSupplementList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT C4.[XH]
                                    ,CAST(C4.[JXND] AS REAL) JXND
                                    ,CAST(C4.[JXYD] AS REAL) JXYD
                                    ,M.[NAME] SSLBNAME
                                    ,O.[OFFICECODE]
                                    ,O.[OFFICENAME]
                                    ,P.[CJBQM]
                                    ,C4.[HCODE]
                                    ,RESULT.[NAME] HNAME
                                    ,C4.[LCODE]
                                    ,C3.[LMC] LNAME
                                    ,CAST(C4.[CCVALUE] AS REAL) CCVALUE
                                    ,CAST(C4.[BLVALUE] AS REAL) BLVALUE
                                    ,CAST(C4.[SJVALUE] AS REAL) SJVALUE
                            FROM [HQPAS].[BPMS].[BPC_SC004] C4 WITH (NOLOCK)
                            LEFT JOIN ( SELECT C1.[HCODE],C1.NAME, C1.[STATUS], C2.CJBBM, C2.ND
										FROM [HQPAS].[BPMS].[BPC_SC001] C1 WITH (NOLOCK)
										LEFT JOIN [HQPAS].[BPMS].[BPC_SC002] C2 WITH (NOLOCK)
										ON C1.HXBM = C2.HXBM AND C1.[STATUS] = C2.[STATUS]) RESULT
                            ON C4.[CJBBM] = RESULT.[CJBBM]
                            AND C4.[JXND] = RESULT.[ND]
                            AND C4.[HCODE] = RESULT.[HCODE]
                            LEFT JOIN [HQPAS].[BPMS].[BPC_SC003] C3 WITH (NOLOCK)
                            ON C4.[CJBBM] = C3.[CJBBM]
                            AND C4.[JXND] = C3.[ND]
                            AND C4.[LCODE] = C3.[LCODE]
                            LEFT JOIN [HQPAS].[BPMS].[PMR008_OFFIECES] O WITH (NOLOCK)
                            ON C4.[ORGID] = O.[ID]
                            LEFT JOIN [HQPAS].[BPMS].[BPC_SP001] P WITH (NOLOCK)
                            ON C4.[CJBBM] = P.[CJBBM]
                            LEFT JOIN [HQPAS].[BPMS].[BPC_SM002] M WITH (NOLOCK)
                            ON P.[SSLB] = M.[TYPEID]
                            WHERE C4.[STATUS] = '1'
                            AND RESULT.[STATUS] = '1'
                            AND C3.[STATUS] = '1'
                            AND P.[STATUS] = '1'
                            AND M.[STATUS] = '1' ");

            //年度过滤
            if (!queryParam["jxnd"].IsEmpty())
            {
                strSql.Append(" AND C4.[JXND] = @JXND ");
                parameter.Add(DbParameters.CreateDbParameter("@JXND", queryParam["jxnd"].ToString()));
            }

            //月度过滤
            if (!queryParam["jxyd"].IsEmpty())
            {
                strSql.Append(" AND C4.[JXYD] = @JXYD ");
                parameter.Add(DbParameters.CreateDbParameter("@JXYD", queryParam["jxyd"].ToString()));
            }

            //所属类别过滤
            if (!queryParam["typeid"].IsEmpty())
            {
                strSql.Append(" AND SUBSTRING(P.[SSLB], 1, 1) = @TYPEID ");
                parameter.Add(DbParameters.CreateDbParameter("@TYPEID", queryParam["typeid"].ToString()));
            }

            //行名过滤
            if (!queryParam["hname"].IsEmpty())
            {
                string hname = queryParam["hname"].ToString();
                strSql.Append(" AND RESULT.[NAME] LIKE @HNAME ");
                parameter.Add(DbParameters.CreateDbParameter("@HNAME", '%' + hname + '%'));
            }

            //列名过滤
            if (!queryParam["lname"].IsEmpty())
            {
                string lname = queryParam["lname"].ToString();
                strSql.Append(" AND C3.[LMC] LIKE @LNAME ");
                parameter.Add(DbParameters.CreateDbParameter("@LNAME", '%' + lname + '%'));
            }

            //采集表名称过滤
            if (!queryParam["cjbmc"].IsEmpty())
            {
                string cjbmc = queryParam["cjbmc"].ToString();
                strSql.Append(" AND P.[CJBQM] LIKE @CJBMC ");
                parameter.Add(DbParameters.CreateDbParameter("@CJBMC", '%' + cjbmc + '%'));
            }

            return this.HQPASRepository().FindList<SupplementCorrectModel>(strSql.ToString(), parameter.ToArray(), pagination);
        }



        #endregion

        #region 提交数据


        /// <summary>
        /// 更新数据修正
        /// </summary>
        /// <param name="type">数据修正类型</param>
        /// <param name="dataCorrectList">数据修正列表</param>
        public void UpateDataCorrectList(string type, string dataCorrectList)
        {
            List<BpcSC004Entity> entities = new List<BpcSC004Entity>();

            IEnumerable<DataCorrectModel> list = dataCorrectList.ToList<DataCorrectModel>();

            List<string> ids = list.Select(l => l.XH).ToList();

            var originalData = this.HQPASRepository().FindList<BpcSC004Entity>(s => ids.Contains(s.XH));

            foreach (var dataCorrect in list)
            {
                foreach (var item in originalData)
                {
                    if (item.XH == dataCorrect.XH)
                    {
                        switch (type)
                        {
                            case "coefficient":
                                if (item.XSVALUE != dataCorrect.XSVALUE || item.SJVALUE != dataCorrect.SJVALUE)
                                {
                                    item.XSVALUE = dataCorrect.XSVALUE;
                                    item.SJVALUE = dataCorrect.SJVALUE;
                                }
                                break;
                            case "zeroing":
                                if (item.SJVALUE != dataCorrect.SJVALUE)
                                {
                                    //item.SJVALUE = 0;
                                    item.SJVALUE = dataCorrect.SJVALUE;
                                }
                                break;
                            case "supplement":
                                if (item.BLVALUE != dataCorrect.BLVALUE || item.SJVALUE != dataCorrect.SJVALUE)
                                {
                                    item.BLVALUE = dataCorrect.BLVALUE;
                                    item.SJVALUE = dataCorrect.SJVALUE;
                                }
                                break;
                            default:
                                break;
                        }

                        item.Modify(item.XH);
                        entities.Add(item);
                        originalData = originalData.Where(o => o.XH != item.XH);
                        break;
                    }
                }
            }

            IRepository db = this.HQPASRepository().BeginTrans();
            try
            {
                foreach (var entity in entities)
                {
                    db.Update(entity);
                }
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
