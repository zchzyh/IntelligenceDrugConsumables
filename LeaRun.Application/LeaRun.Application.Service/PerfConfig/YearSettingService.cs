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
    /// 年度绩效设置
    /// </summary>
    public class YearSettingService : RepositoryFactory, IYearSettingService
    {
        /// <summary>
        /// 年度绩效配置列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<YearSettingModel> GetList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT [JXBM]
                                ,[JXQY]
                                ,P.ORGNAME
                                ,[JXND]
                                ,[KSSJ]
                                ,[JZSJ]
                                ,[FWZT]
                                ,U1.[NAME] FWZTNAME
                                ,[YXZT]
                                ,U2.[NAME] YXZTNAME
                                ,B.[REMARK]
                                ,B.[CREATOR]
                                ,B.[CREATEAT]
                                ,B.[MODIFOR]
                                ,B.[MODIFYAT]
                                ,B.[STATUS]
                            FROM [HQPAS].[BPMS].[BPE_SC001] B
                            LEFT JOIN [HQPAS].[BPMS].[PMR001_MOR] P ON B.JXQY = P.ORGID
                            LEFT JOIN (SELECT [CODE]
                                            , [NAME]
                                       FROM [HQPAS].[BPMS].[S103_CODE]
                                       WHERE TYPEID = @ServiceStatusType AND STATUS = '1') U1 ON B.[FWZT] = U1.CODE
                            LEFT JOIN (SELECT [CODE]
                                            , [NAME]
                                       FROM [HQPAS].[BPMS].[S103_CODE]
                                       WHERE TYPEID = @RunningStatusType AND STATUS = '1') U2 ON B.[YXZT] = U2.CODE
                            WHERE B.[STATUS] = '1'
                                  AND 1 = 1");
            parameter.Add(DbParameters.CreateDbParameter("@ServiceStatusType", Config.GetValue("ServiceStatusType")));
            parameter.Add(DbParameters.CreateDbParameter("@RunningStatusType", Config.GetValue("RunningStatusType")));
            //绩效年度
            if (!queryParam["year"].IsEmpty())
            {
                strSql.Append(" AND B.[JXND] = @JXND ");
                parameter.Add(DbParameters.CreateDbParameter("@JXND", queryParam["year"].ToString()));
            }
            //绩效主体
            if (!queryParam["orgid"].IsEmpty())
            {
                strSql.Append(" AND B.[JXQY] = @JXQY ");
                parameter.Add(DbParameters.CreateDbParameter("@JXQY", queryParam["orgid"].ToString()));
            }
            return this.HQPASRepository().FindList<YearSettingModel>(strSql.ToString(), parameter.ToArray(), pagination);
        }
    }
}