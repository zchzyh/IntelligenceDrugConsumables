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
    /// 定量指标目标值
    /// </summary>
    public class QuantitativeGoalService : RepositoryFactory, IQuantitativeGoalService
    {
        /// <summary>
        /// 定量指标目标值列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<QuantitativeGoalModel> GetList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT A4.[XH]
                            	  ,P3.[JXBM]
                                  ,S.[JXND]
                            	  ,P4.[JGFABH]
                            	  ,P3.[JGFAMC]
                            	  ,P3.[JGBM] ORGCODE
                            	  ,D.[OFFICENAME] MANAGERORGNAME
                            	  ,ZB.[FirstZBBH]
                                  ,ZB.[FirstZBMC]
                                  ,ZB.[SecZBBH]
                                  ,ZB.[SecZBMC]
                                  ,ZB.[ThirdZBBH]
                                  ,ZB.[ThirdZBMC]
                                  ,A4.[KPIBH]
                                  ,A4.[HGMBZ]
                                  ,A4.[YXMBZ]
                                  ,A4.[YLMBZ]
                                  ,A4.[BGMBZ]
                                  ,A4.[CKZ1]
                                  ,A4.[CKZ2]
                                  ,A4.[CKZ3]
                                  ,A4.[SQZT]
                            FROM [HQPAS].[BPMS].[BPE_PA004] P4
                            INNER JOIN [HQPAS].[BPMS].[BPE_PA003] P3 ON P4.[JGFABH] = P3.[JGFABH]
                            INNER JOIN [HQPAS].[BPMS].[BPE_SC001] S ON P3.[JXBM] = S.[JXBM]
                            INNER JOIN [HQPAS].[BPMS].[PMR008_OFFIECES] D ON P3.[JGBM] = D.[ID]
                            INNER JOIN (SELECT T.[JXBM] JXBM
                                              ,T.[ZBBH] ThirdZBBH
                                              ,T.[ZBMC] ThirdZBMC
                                              ,S.[ZBBH] SecZBBH
                                              ,S.[ZBMC] SecZBMC
                                              ,F.[ZBBH] FirstZBBH
                                              ,F.[ZBMC] FirstZBMC
                                        FROM [HQPAS].[BPMS].[BPE_TA001] T
                                        LEFT JOIN [HQPAS].[BPMS].[BPE_TA001] S ON T.[FJZB] = S.[ZBBH] AND T.[JXBM] = S.[JXBM]
                                        LEFT JOIN [HQPAS].[BPMS].[BPE_TA001] F ON S.[FJZB] = F.[ZBBH] AND S.[JXBM] = F.[JXBM]
                                        WHERE T.[ZBJB] = '3') ZB ON P4.[KPIBH] = ZB.[ThirdZBBH] AND P3.[JXBM] = ZB.[JXBM]
                            INNER JOIN [HQPAS].[BPMS].[BPE_TA002] A2 ON ZB.[JXBM] = A2.[JXBM] AND ZB.[ThirdZBBH] = A2.[ZBBH]
                            LEFT JOIN [HQPAS].[BPMS].[BPE_TA004] A4 ON A2.[KPIBH] = A4.[KPIBH] AND P4.[JGFABH] = A4.[JGFABH]
                            WHERE P4.[ZBLX] = '0' AND (A4.[KPIBH] IS NULL OR A4.[STATUS] = '1') ");
            //单位方案编号
            if (!queryParam["jgfabh"].IsEmpty())
            {
                strSql.Append(" AND P4.[JGFABH] = @JGFABH ");
                parameter.Add(DbParameters.CreateDbParameter("@JGFABH", queryParam["jgfabh"].ToString()));
            }
            //绩效年度编码
            if (!queryParam["jxbm"].IsEmpty())
            {
                strSql.Append(" AND P3.[JXBM] = @JXBM ");
                parameter.Add(DbParameters.CreateDbParameter("@JXBM", queryParam["jxbm"].ToString()));
            }
            //科室编码
            if (!queryParam["orgcode"].IsEmpty())
            {
                strSql.Append(" AND P3.[JGBM] = @ORGCODE ");
                parameter.Add(DbParameters.CreateDbParameter("@ORGCODE", queryParam["orgcode"].ToString()));
            }
            //一级分类编号
            if (!queryParam["firstZBBH"].IsEmpty())
            {
                strSql.Append(" AND ZB.[FirstZBBH] = @FirstZBBH ");
                parameter.Add(DbParameters.CreateDbParameter("@FirstZBBH", queryParam["firstZBBH"].ToString()));
            }
            //二级分类编号
            if (!queryParam["secZBBH"].IsEmpty())
            {
                strSql.Append(" AND ZB.[SecZBBH] = @SecZBBH ");
                parameter.Add(DbParameters.CreateDbParameter("@SecZBBH", queryParam["secZBBH"].ToString()));
            }
            //指标名称
            if (!queryParam["zbmc"].IsEmpty())
            {
                strSql.Append(" AND ZB.[ThirdZBMC] LIKE @ThirdZBMC ");
                parameter.Add(DbParameters.CreateDbParameter("@ThirdZBMC", '%' + queryParam["zbmc"].ToString() + '%'));
            }
            //申请状态
            if (!queryParam["applyStatus"].IsEmpty())
            {
                int sqzt = queryParam["applyStatus"].ToInt();
                if (sqzt == 1)
                {
                    strSql.Append(" AND [SQZT] = 1 ");
                }
                else
                {
                    strSql.Append(" AND ([SQZT] IS NULL OR [SQZT] = 0) ");
                }
            }
            //审核状态
            if (!queryParam["auditStatus"].IsEmpty())
            {
                bool isAudit = queryParam["applyStatus"].ToBool();
                if (isAudit)
                {
                    strSql.Append(" AND P3.[STATUS] = '1' ");
                }
                else
                {
                    strSql.Append(" AND (P3.[STATUS] = '0' OR P3.[STATUS] = '2') ");
                }
            }
            return this.HQPASRepository().FindList<QuantitativeGoalModel>(strSql.ToString(), parameter.ToArray(), pagination);
        }

        /// <summary>
        /// 部门方案定量指标报告数据列表
        /// </summary>
        /// <param name="jgfabh">部门方案编号</param>
        /// <returns></returns>
        public IEnumerable<QuantitativeGoalModel> GetReportDataList(string jgfabh)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT P4.[JGFABH]
                                  ,P3.[JXBM]
                                  ,P4.[KPIBH] ThirdZBBH
                            	  ,A2.[KPIBH]
                            	  ,A3.[CSFBH]
                            	  ,V4.[CSFMC]
                            	  ,V3.[BSCBH]
                            	  ,V2.[BSCMC]
                            	  ,CASE A2.[ZBJX] WHEN '0' THEN (SELECT MAX([KPISJZ])
                            									 FROM [HQPAS].[BPMS].[BPE_RA001]
                            									 WHERE [KPIBH] = A2.[KPIBH] AND [STATUS] = '1')
                            					  ELSE (SELECT MIN([KPISJZ])
                            									 FROM [HQPAS].[BPMS].[BPE_RA001]
                            									 WHERE [KPIBH] = A2.[KPIBH] AND [STATUS] = '1')
                            	   END BGMBZ
                            	  ,(SELECT TOP(1) [KPISJZ]
                            	    FROM [HQPAS].[BPMS].[BPE_RA001] R1
                            		LEFT JOIN [HQPAS].[BPMS].[BPE_SC001] SI ON R1.[JXBM] = SI.[JXBM]
                            		WHERE [JGFABH] = P4.[JGFABH] AND [KPIBH] = A2.[KPIBH] AND R1.[STATUS] = '1'
                            		AND SI.[JXND] = S.[JXND]-1 AND SI.[STATUS] = '1') CKZ1
                            	  ,(SELECT TOP(1) [KPISJZ]
                            	    FROM [HQPAS].[BPMS].[BPE_RA001] R1
                            		LEFT JOIN [HQPAS].[BPMS].[BPE_SC001] SI ON R1.[JXBM] = SI.[JXBM]
                            		WHERE [JGFABH] = P4.[JGFABH] AND [KPIBH] = A2.[KPIBH] AND R1.[STATUS] = '1'
                            		AND SI.[JXND] = S.[JXND]-2 AND SI.[STATUS] = '1') CKZ2
                            	  ,(SELECT TOP(1) [KPISJZ]
                            	    FROM [HQPAS].[BPMS].[BPE_RA001] R1
                            		LEFT JOIN [HQPAS].[BPMS].[BPE_SC001] SI ON R1.[JXBM] = SI.[JXBM]
                            		WHERE [JGFABH] = P4.[JGFABH] AND [KPIBH] = A2.[KPIBH] AND R1.[STATUS] = '1'
                            		AND SI.[JXND] = S.[JXND]-3 AND SI.[STATUS] = '1') CKZ3
                            FROM [HQPAS].[BPMS].[BPE_PA004] P4
                            INNER JOIN [HQPAS].[BPMS].[BPE_PA003] P3 ON P4.[JGFABH] = P3.[JGFABH]
                            INNER JOIN [HQPAS].[BPMS].[BPE_SC001] S ON P3.[JXBM] = S.[JXBM]
                            LEFT JOIN [HQPAS].[BPMS].[BPE_TA002] A2 ON P4.[KPIBH] = A2.[ZBBH] AND P3.[JXBM] = A2.[JXBM]
                            LEFT JOIN [HQPAS].[BPMS].[BPE_TA003] A3 ON A2.[KPIBH] = A3.[KPIBH] AND A2.[JXBM] = A3.[JXBM]
                            LEFT JOIN [HQPAS].[BPMS].[BPE_VA004] V4 ON A3.[CSFBH] = V4.[CSFBH]
                            LEFT JOIN [HQPAS].[BPMS].[BPE_VA003] V3 ON V4.[ZTBH] = V3.[ZTBH]
                            LEFT JOIN [HQPAS].[BPMS].[BPE_VA002] V2 ON V3.[BSCBH] = V2.[BSCBH]
                            WHERE P4.[STATUS] = '1' AND P4.[ZBLX] = '0'
                            AND (A3.[STATUS] IS NULL OR A3.[STATUS] = '1') ");
            //单位方案编号
            strSql.Append(" AND P4.[JGFABH] = @JGFABH ");
            parameter.Add(DbParameters.CreateDbParameter("@JGFABH", jgfabh));

            return this.HQPASRepository().FindList<QuantitativeGoalModel>(strSql.ToString(), parameter.ToArray());
        }

        /// <summary>
        /// 定量指标目标值申请
        /// </summary>
        /// <param name="jgfabh">机构方案编号</param>
        /// <param name="applyStatus">申请状态(0未申请/1已申请)</param>
        public void Apply(string jgfabh, int applyStatus)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"UPDATE [HQPAS].[BPMS].[BPE_TA004]
                            SET [SQZT] = @SQZT
                            WHERE [JGFABH] = @JGFABH");
            parameter.Add(DbParameters.CreateDbParameter("@JGFABH", jgfabh));
            parameter.Add(DbParameters.CreateDbParameter("@SQZT", applyStatus));

            this.HQPASRepository().ExecuteBySql(strSql.ToString(), parameter.ToArray());
        }
    }
}