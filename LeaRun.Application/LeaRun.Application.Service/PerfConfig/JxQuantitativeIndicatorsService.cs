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
    /// 绩效定量指标设置
    /// </summary>
    public class JxQuantitativeIndicatorsService : RepositoryFactory, IJxQuantitativeIndicatorsService
    {
        /// <summary>
        /// 绩效定量指标设置列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<JxQuantitativeIndicatorsModel> GetList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT [KPIBH]
                                  ,C.[JXBM]
                                  ,Y.[JXND]
                                  ,C.[ZBBH] ThirdZBBH
                                  ,P.[ThirdZBMC]
                                  ,P.[SecZBBH]
                                  ,P.[SecZBMC]
                                  ,P.[FirstZBBH]
                                  ,P.[FirstZBMC]
                                  ,[ZBJX]
                                  ,[ZBCD]
                                  ,[ZBGS]
                                  ,[ZBGSMS]
                                  ,U.[NAME] JLDW
                                  ,C.[STATUS]
                            FROM [HQPAS].[BPMS].[BPE_TA002] C
                            LEFT JOIN (SELECT T.[JXBM] JXBM
                                             ,T.[ZBBH] ThirdZBBH
                                             ,T.[ZBMC] ThirdZBMC
                                         	 ,S.[ZBBH] SecZBBH
                                             ,S.[ZBMC] SecZBMC
                                         	 ,F.[ZBBH] FirstZBBH
                                             ,F.[ZBMC] FirstZBMC
                                       FROM [HQPAS].[BPMS].[BPE_TA001] T
                                       LEFT JOIN [HQPAS].[BPMS].[BPE_TA001] S ON T.[FJZB] = S.[ZBBH] AND T.[JXBM] = S.[JXBM]
                                       LEFT JOIN [HQPAS].[BPMS].[BPE_TA001] F ON S.[FJZB] = F.[ZBBH] AND S.[JXBM] = F.[JXBM]
                                       WHERE T.[ZBJB] = '3') P ON C.[ZBBH] = P.[ThirdZBBH] AND C.[JXBM] = P.[JXBM]
                            LEFT JOIN [HQPAS].[BPMS].[BPE_SC001] Y ON C.[JXBM] = Y.[JXBM]
                            LEFT JOIN (SELECT [CODE]
                                             ,[NAME]
                                       FROM [HQPAS].[BPMS].[S103_CODE]
                                       WHERE TYPEID = @UnitType AND STATUS = '1') U ON C.[JLDW] = U.CODE
                            WHERE 1 = 1 ");
            parameter.Add(DbParameters.CreateDbParameter("@UnitType", Config.GetValue("UnitType")));
            //绩效年度编码
            if (!queryParam["jxbm"].IsEmpty())
            {
                strSql.Append(" AND C.[JXBM] = @JXBM ");
                parameter.Add(DbParameters.CreateDbParameter("@JXBM", queryParam["jxbm"].ToString()));
            }
            //绩效主体
            if (!queryParam["orgid"].IsEmpty())
            {
                strSql.Append(" AND Y.[JXQY] = @JXQY ");
                parameter.Add(DbParameters.CreateDbParameter("@JXQY", queryParam["orgid"].ToString()));
            }
            //指标名称
            if (!queryParam["keyword"].IsEmpty())
            {
                strSql.Append(" AND P.[ThirdZBMC] LIKE @KEYWORD ");
                parameter.Add(DbParameters.CreateDbParameter("@KEYWORD", '%' + queryParam["keyword"].ToString() + '%'));
            }
            return this.HQPASRepository().FindList<JxQuantitativeIndicatorsModel>(strSql.ToString(), parameter.ToArray(), pagination);
        }
    }
}