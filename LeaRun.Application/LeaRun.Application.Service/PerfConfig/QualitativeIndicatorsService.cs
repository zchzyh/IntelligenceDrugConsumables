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
    /// 定性指标
    /// </summary>
    public class QualitativeIndicatorsService : RepositoryFactory, IQualitativeIndicatorsService
    {
        #region 获取数据

        /// <summary>
        /// 定性指标设置列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<QualitativeIndicatorsModel> GetList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT [ZBBH]
                                  ,P.[JXBM]
                                  ,[JXND]
                                  ,[ZBMC]
                                  ,[FJZB]
                                  ,[ZBJB]
                                  ,[ZBSM]
                                  ,[CREATOR]
                                  ,[CREATEAT]
                                  ,[MODIFOR]
                                  ,[MODIFYAT]
                                  ,[STATUS]
                            FROM [HQPAS].[BPMS].[BPE_TB001] P
                            LEFT JOIN (SELECT [JXBM]
                                             ,[JXND]
                                         FROM [HQPAS].[BPMS].[BPE_SC001]
                                         WHERE STATUS = '1') Y ON P.[JXBM] = Y.JXBM
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
                strSql.Append(" AND [ZBJB] = @ZBJB ");
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
                strSql.Append(" AND [ZBMC] LIKE @ZBMC ");
                parameter.Add(DbParameters.CreateDbParameter("@ZBMC", '%' + queryParam["zbmc"].ToString() + '%'));
            }
            return this.HQPASRepository().FindList<QualitativeIndicatorsModel>(strSql.ToString(), parameter.ToArray(), pagination);
        }

        #endregion
    }
}