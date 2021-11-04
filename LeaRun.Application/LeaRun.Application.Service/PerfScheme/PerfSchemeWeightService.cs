using LeaRun.Application.Entity.PerfScheme;
using LeaRun.Application.Entity.PerfScheme.ViewModel;
using LeaRun.Application.IService.PerfScheme;
using LeaRun.Data;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Service.PerfScheme
{
    /// <summary>
    /// 方案权重设置
    /// </summary>
    public class PerfSchemeWeightService : RepositoryFactory, IPerfSchemeWeightService
    {
        /// <summary>
        /// 获取方案所有指标
        /// </summary>
        /// <param name="fabh">方案编号</param>
        /// <returns></returns>
        public IEnumerable<PerfSchemeWeightModel> GetZBList(string fabh)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            //strSql.Append(@"SELECT P1.[SYND]
            //                      ,P2.[FABH]
            //                	  ,P1.[FAMC]
            //                      ,P.[FirstZBBH]
            //                      ,P.[FirstZBMC]
            //                      ,P.[FirstExplain]
            //                      ,P.[SecZBBH]
            //                      ,P.[SecZBMC]
            //                      ,P.[SecExplain]
            //                      ,P.[ThirdZBBH]
            //                      ,P.[ThirdZBMC]
            //                      ,P.[ThirdExplain]
            //                FROM [HQPAS].[BPMS].[BPE_PA002] P2
            //                LEFT JOIN [HQPAS].[BPMS].[BPE_PA001] P1 ON P2.[FABH] = P1.[FABH]
            //                LEFT JOIN (SELECT T.[JXBM] JXBM
            //                                 ,T.[ZBBH] ThirdZBBH
            //                                 ,T.[ZBMC] ThirdZBMC
            //                                 ,T.[EXPLAIN] ThirdExplain
            //                             	 ,S.[ZBBH] SecZBBH
            //                                 ,S.[ZBMC] SecZBMC
            //                                 ,S.[EXPLAIN] SecExplain
            //                             	 ,F.[ZBBH] FirstZBBH
            //                                 ,F.[ZBMC] FirstZBMC
            //                                 ,F.[EXPLAIN] FirstExplain
            //                           FROM [HQPAS].[BPMS].[BPE_TA001] T
            //                           LEFT JOIN [HQPAS].[BPMS].[BPE_TA001] S ON T.[FJZB] = S.[ZBBH] AND T.[JXBM] = S.[JXBM]
            //                           LEFT JOIN [HQPAS].[BPMS].[BPE_TA001] F ON S.[FJZB] = F.[ZBBH] AND S.[JXBM] = F.[JXBM]
            //                           WHERE T.[ZBJB] = '3') P ON P2.[KPIBH] = P.[ThirdZBBH] AND P1.[JXBM] = P.[JXBM]
            //                WHERE P2.[ZBLX] = '0' AND P2.[STATUS] = '1' AND P.[ThirdZBBH] IS NOT NULL
            //                      AND P2.[FABH] = @FABH
            //                ORDER BY P.[FirstZBBH],P.[SecZBBH],P.[ThirdZBBH]");
            strSql.Append(@"SELECT P1.[SYND]
                                  ,P2.[FABH]
                            	  ,P1.[FAMC]
                                  ,P.[FirstZBBH]
                                  ,P.[FirstZBMC]
                                  ,P.[FirstExplain]
                                  ,P.[SecZBBH]
                                  ,P.[SecZBMC]
                                  ,P.[SecExplain]
                                  ,P.[ThirdZBBH]
                                  ,P.[ThirdZBMC]
                                  ,P.[ThirdExplain]
                            FROM [HQPAS].[BPMS].[BPE_PA002] P2
                            LEFT JOIN [HQPAS].[BPMS].[BPE_PA001] P1 ON P2.[FABH] = P1.[FABH]
                            LEFT JOIN (SELECT T.[JXBM] JXBM
                                             ,T.[ZBBH] ThirdZBBH
                                             ,T.[ZBMC] ThirdZBMC
                                             ,T.[EXPLAIN] ThirdExplain
                                         	 ,S.[ZBBH] SecZBBH
                                             ,S.[ZBMC] SecZBMC
                                             ,S.[EXPLAIN] SecExplain
                                         	 ,F.[ZBBH] FirstZBBH
                                             ,F.[ZBMC] FirstZBMC
                                             ,F.[EXPLAIN] FirstExplain
                                       FROM [HQPAS].[BPMS].[KPIALL] T
                                       LEFT JOIN [HQPAS].[BPMS].[KPIALL] S ON T.[FJZB] = S.[ZBBH] AND T.[JXBM] = S.[JXBM]
                                       LEFT JOIN [HQPAS].[BPMS].[KPIALL] F ON S.[FJZB] = F.[ZBBH] AND S.[JXBM] = F.[JXBM]
                                       WHERE T.[ZBJB] = '3') P ON P2.[KPIBH] = P.[ThirdZBBH] AND P1.[JXBM] = P.[JXBM]
                            WHERE P2.[STATUS] = '1' AND P.[ThirdZBBH] IS NOT NULL
                                  AND P2.[FABH] = @FABH
                            ORDER BY P.[FirstZBBH],P.[SecZBBH],P.[ThirdZBBH]");
            parameter.Add(DbParameters.CreateDbParameter("@FABH", fabh));
            return this.HQPASRepository().FindList<PerfSchemeWeightModel>(strSql.ToString(), parameter.ToArray());
        }

        /// <summary>
        /// 获取方案所有指标
        /// </summary>
        /// <param name="fabh">方案编号</param>
        /// <returns></returns>
        public IEnumerable<PerfSchemeWeightModel> GetWeightList(string fabh)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT [KPIBH] ThirdZBBH
                                  ,[QZBZ]
                            FROM [HQPAS].[BPMS].[BPE_EA005]
                            WHERE [FABH] = @FABH");
            parameter.Add(DbParameters.CreateDbParameter("@FABH", fabh));
            return this.HQPASRepository().FindList<PerfSchemeWeightModel>(strSql.ToString(), parameter.ToArray());
        }
        /// <summary>
        /// 设置方案指标权重
        /// </summary>
        /// <param name="list">方案指标权重列表</param>
        /// <param name="level">指标等级</param>
        /// <returns></returns>
        public void ModifyWeightList(List<PerfSchemeWeightModel> list, string level)
        {
            IRepository db = this.HQPASRepository().BeginTrans();
            try
            {
                foreach (var l in list)
                {
                    BpeEA005Entity oldData = null;
                    switch (level)
                    {
                        case "1":
                            oldData = db.FindEntity<BpeEA005Entity>(e => e.FABH == l.FABH && e.KPIBH == l.FirstZBBH);
                            if (oldData == null)
                            {
                                oldData = new BpeEA005Entity
                                {
                                    FABH = l.FABH,
                                    KPIBH = l.FirstZBBH,
                                    QZBZ = l.QZBZ
                                };
                                oldData.Create();
                                db.Insert(oldData);
                            }
                            else
                            {
                                oldData.QZBZ = l.QZBZ;
                                oldData.STATUS = "1";
                                oldData.Modify(oldData.XH);
                                db.Update(oldData);
                            }
                            break;
                        case "2":
                            oldData = db.FindEntity<BpeEA005Entity>(e => e.FABH == l.FABH && e.KPIBH == l.SecZBBH);
                            if (oldData == null)
                            {
                                oldData = new BpeEA005Entity
                                {
                                    FABH = l.FABH,
                                    KPIBH = l.SecZBBH,
                                    QZBZ = l.QZBZ
                                };
                                oldData.Create();
                                db.Insert(oldData);
                            }
                            else
                            {
                                oldData.QZBZ = l.QZBZ;
                                oldData.STATUS = "1";
                                oldData.Modify(oldData.XH);
                                db.Update(oldData);
                            }
                            break;
                        case "3":
                            oldData = db.FindEntity<BpeEA005Entity>(e => e.FABH == l.FABH && e.KPIBH == l.ThirdZBBH);
                            if (oldData == null)
                            {
                                oldData = new BpeEA005Entity
                                {
                                    FABH = l.FABH,
                                    KPIBH = l.ThirdZBBH,
                                    QZBZ = l.QZBZ
                                };
                                oldData.Create();
                                db.Insert(oldData);
                            }
                            else
                            {
                                oldData.QZBZ = l.QZBZ;
                                oldData.STATUS = "1";
                                oldData.Modify(oldData.XH);
                                db.Update(oldData);
                            }
                            break;
                    }
                }

                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
    }
}