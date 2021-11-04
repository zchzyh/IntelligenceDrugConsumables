using LeaRun.Application.Entity.PerfScheme.ViewModel;
using LeaRun.Application.IService.PerfScheme;
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

namespace LeaRun.Application.Service.PerfScheme
{
    /// <summary>
    /// 部门绩效评价设置
    /// </summary>
    public class PerfDeptSchemeAppraisedataService : RepositoryFactory, IPerfDeptSchemeAppraisedataService
    {
        /// <summary>
        /// 部门绩效评价设置列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<PerfDeptSchemeAppraisedataModel> GetList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT P3.[JGFABH]
                            	  ,P1.[SYND]
                                  ,[JGFAMC]
                                  ,D.[OFFICENAME] Department
                            	  ,Y.[FWZT]
                            	  ,E.[PJFFBH]
                            	  ,E3.[PJFFMC]
                            FROM [HQPAS].[BPMS].[BPE_PA003] P3
                            LEFT JOIN [HQPAS].[BPMS].[BPE_SC001] Y ON P3.[JXBM] = Y.[JXBM]
                            LEFT JOIN [HQPAS].[BPMS].[BPE_PA001] P1 ON P3.[FABH] = P1.[FABH]
                            LEFT JOIN [HQPAS].[BPMS].[PMR008_OFFIECES] D ON P3.[JGBM] = D.[ID]
                            LEFT JOIN [HQPAS].[BPMS].[BPE_EA004] E ON P3.[JGFABH] = E.[JGFABH]
                            LEFT JOIN [HQPAS].[BPMS].[BPE_EA003] E3 ON E.[PJFFBH] = E3.[PJFFBH]
                            WHERE (E.[PJFFBH] IS NULL OR E.[STATUS] = '1') ");
            //绩效年度编码
            if (!queryParam["jxbm"].IsEmpty())
            {
                strSql.Append(" AND P3.[JXBM] = @JXBM ");
                parameter.Add(DbParameters.CreateDbParameter("@JXBM", queryParam["jxbm"].ToString()));
            }
            //基础方案编号
            if (!queryParam["fabh"].IsEmpty())
            {
                strSql.Append(" AND P3.[FABH] = @FABH ");
                parameter.Add(DbParameters.CreateDbParameter("@FABH", queryParam["fabh"].ToString()));
            }
            //部门方案编号
            if (!queryParam["jgfabh"].IsEmpty())
            {
                strSql.Append(" AND P3.[JGFABH] = @JGFABH ");
                parameter.Add(DbParameters.CreateDbParameter("@JGFABH", queryParam["jgfabh"].ToString()));
            }
            //部门方案名称
            if (!queryParam["keyword"].IsEmpty())
            {
                strSql.Append(" AND [JGFAMC] LIKE @JGFAMC ");
                parameter.Add(DbParameters.CreateDbParameter("@JGFAMC", '%' + queryParam["keyword"].ToString() + '%'));
            }
            return this.HQPASRepository().FindList<PerfDeptSchemeAppraisedataModel>(strSql.ToString(), parameter.ToArray(), pagination);
        }
    }
}