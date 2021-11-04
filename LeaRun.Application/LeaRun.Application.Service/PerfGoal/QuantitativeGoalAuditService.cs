using LeaRun.Application.Entity.PerfGoal.ViewModel;
using LeaRun.Application.IService.PerfGoal;
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

namespace LeaRun.Application.Service.PerfGoal
{
    /// <summary>
    /// 定量指标目标值审核
    /// </summary>
    public class QuantitativeGoalAuditService : RepositoryFactory, IQuantitativeGoalAuditService
    {
        /// <summary>
        /// 定量指标目标值审核
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<QuantitativeGoalAuditModel> GetList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT T.[JGFABH]
                                  ,T.[JGFAMC]
                                  ,T.[JXBM]
                                  ,S.[JXND]
                                  ,O.[ID] ORGCODE
                                  ,O.[OFFICENAME] MANAGERORGNAME
                                  ,T.[REMARK]
                                  ,T.[STATUS]
                            FROM [HQPAS].[BPMS].[BPE_PA003] T
                            LEFT JOIN [HQPAS].[BPMS].[BPE_SC001] S ON T.[JXBM] = S.[JXBM]
                            LEFT JOIN [HQPAS].[BPMS].[PMR008_OFFIECES] O ON T.[JGBM] = O.[ID]
                            WHERE ((SELECT COUNT(1)
                                    FROM [HQPAS].[BPMS].[BPE_TA004] A
                                    WHERE A.[JXBM] = T.[JXBM] AND A.[JGFABH] = T.[JGFABH] AND A.[STATUS] = '1' AND A.[SQZT] = 0) = 0)
                            AND ((SELECT COUNT(1)
                                  FROM [HQPAS].[BPMS].[BPE_TA004] A
                                  WHERE A.[JXBM] = T.[JXBM] AND A.[JGFABH] = T.[JGFABH] AND A.[STATUS] = '1') <> 0)");
            //绩效年度编码
            if (!queryParam["jxbm"].IsEmpty())
            {
                strSql.Append(" AND T.[JXBM] = @JXBM ");
                parameter.Add(DbParameters.CreateDbParameter("@JXBM", queryParam["jxbm"].ToString()));
            }
            //科室编码
            if (!queryParam["orgcode"].IsEmpty())
            {
                strSql.Append(" AND O.[ID] = @ORGCODE ");
                parameter.Add(DbParameters.CreateDbParameter("@ORGCODE", queryParam["orgcode"].ToString()));
            }
            //审核状态
            if (!queryParam["auditStatus"].IsEmpty())
            {
                strSql.Append(" AND T.[STATUS] = @STATUS ");
                parameter.Add(DbParameters.CreateDbParameter("@STATUS", queryParam["auditStatus"].ToString()));
            }
            return this.HQPASRepository().FindList<QuantitativeGoalAuditModel>(strSql.ToString(), parameter.ToArray(), pagination);
        }

        /// <summary>
        /// 定量指标目标值是否已申请
        /// </summary>
        /// <param name="jxbm">绩效年度编码</param>
        /// <param name="jgfabh">机构方案编号</param>
        /// <returns></returns>
        public bool IsApply(string jxbm, string jgfabh)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT COUNT(1)
                            FROM [HQPAS].[BPMS].[BPE_TA004]
                            WHERE [JXBM] = @JXBM AND [JGFABH] = @JGFABH AND [STATUS] = '1' AND [SQZT] = 0");
            parameter.Add(DbParameters.CreateDbParameter("@JXBM", jxbm));
            parameter.Add(DbParameters.CreateDbParameter("@JGFABH", jgfabh));

            var count = this.HQPASRepository().FindObject(strSql.ToString(), parameter.ToArray());
            if (count != null && (int)count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}