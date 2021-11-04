using LeaRun.Application.Entity.PerfConfig;
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
    /// 定量指标设置
    /// </summary>
    public class QuantitativeIndicatorsService : RepositoryFactory, IQuantitativeIndicatorsService
    {
        /// <summary>
        /// 定量指标设置列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<QuantitativeIndicatorsModel> GetList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT P.[ZBBH]
                                  ,P.[JXBM]
                                  ,Y.[JXND]
                                  ,P.[ZBMC]
                                  ,P.[FJZB]
                                  ,P.[ZBJB]
                                  ,P.[STATUS]
                                  ,P.[EXPLAIN]
                            FROM [HQPAS].[BPMS].[BPE_TA001] P
                            LEFT JOIN [HQPAS].[BPMS].[BPE_SC001] Y ON P.[JXBM] = Y.JXBM
                            WHERE 1 = 1 ");
            //绩效年度编码
            if (!queryParam["jxbm"].IsEmpty())
            {
                strSql.Append(" AND P.[JXBM] = @JXBM ");
                parameter.Add(DbParameters.CreateDbParameter("@JXBM", queryParam["jxbm"].ToString()));
            }
            //等级
            if (!queryParam["level"].IsEmpty())
            {
                strSql.Append(" AND P.[ZBJB] = @ZBJB ");
                parameter.Add(DbParameters.CreateDbParameter("@ZBJB", queryParam["level"].ToString()));
            }
            //父级指标
            if (!queryParam["fjzb"].IsEmpty())
            {
                strSql.Append(" AND P.[FJZB] = @FJZB ");
                parameter.Add(DbParameters.CreateDbParameter("@FJZB", queryParam["fjzb"].ToString()));
            }
            //指标名称
            if (!queryParam["zbmc"].IsEmpty())
            {
                strSql.Append(" AND P.[ZBMC] LIKE @ZBMC ");
                parameter.Add(DbParameters.CreateDbParameter("@ZBMC", '%' + queryParam["zbmc"].ToString() + '%'));
            }
            if (!queryParam["zbbh"].IsEmpty())
            {
                strSql.Append(" AND P.[ZBBH] = @ZBBH ");
                parameter.Add(DbParameters.CreateDbParameter("@ZBBH", queryParam["zbbh"].ToString()));
            }
            return this.HQPASRepository().FindList<QuantitativeIndicatorsModel>(strSql.ToString(), parameter.ToArray(), pagination);
        }
    }
}