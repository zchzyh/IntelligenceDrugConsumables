using LeaRun.Application.Entity.PerfConfig.ViewModel;
using LeaRun.Application.IService.PerfConfig;
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

namespace LeaRun.Application.Service.PerfConfig
{
    /// <summary>
    /// 绩效考核
    /// </summary>
    public class AssessmentObjectService : RepositoryFactory, IAssessmentObjectService
    {
        /// <summary>
        /// 获取绩效考核对象列表
        /// </summary>
        /// <param name="jxbm"></param>
        /// <returns></returns>
        public IEnumerable<AssessmentObjectModel> GetDepartmentList(string jxbm)
        {
            if (string.IsNullOrWhiteSpace(jxbm))
            {
                return new List<AssessmentObjectModel>();
            }

            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT S.[XH]
                                  ,S.[JXBM]
                                  ,O.[ORGCODE]
                                  ,O.[MANAGERORGNAME]
                                  ,O.[SHORTNAME]
                                  ,O.[PARENTORG]
                                  ,D.[ID] DEPTID
                                  ,D.[OFFICENAME] DEPTNAME
                            FROM [HQPAS].[BPMS].[PMR001_MOR] M
                            LEFT JOIN [HQPAS].[BPMS].[PMR005_ORG] O ON M.[ADMINISTRATIVECODE] = O.[ADMINISTRATIVECODE]
                            INNER JOIN [HQPAS].[BPMS].[PMR008_OFFIECES] D ON O.[ORGCODE] = D.[ORGID]
                            LEFT JOIN (SELECT [XH]
                            				 ,[JXBM]
                            				 ,[JGBM]
                            		   FROM [HQPAS].[BPMS].[BPC_SP007] WHERE [JXBM] = @JXBM AND [STATUS] = '1') S ON D.[ID] = S.[JGBM]
                            WHERE M.[ORGID] = (SELECT [JXQY] FROM [HQPAS].[BPMS].[BPE_SC001] WHERE [JXBM] = @JXBM) AND M.[FLAG] = '1' AND O.[FLAG] = '1'
                            UNION
                            SELECT NULL [XH]
                            	  ,NULL [JXBM]
                            	  ,O.[ORGCODE]
                            	  ,O.[MANAGERORGNAME]
                            	  ,O.[SHORTNAME]
                            	  ,O.[PARENTORG]
                            	  ,NULL DEPTID
                            	  ,NULL DEPTNAME
                            FROM [HQPAS].[BPMS].[PMR005_ORG] O
                            LEFT JOIN [HQPAS].[BPMS].[PMR001_MOR] M ON O.[ADMINISTRATIVECODE] = M.[ADMINISTRATIVECODE]
                            WHERE O.[FLAG] = '1' AND M.[ORGID] = (SELECT [JXQY] FROM [HQPAS].[BPMS].[BPE_SC001] WHERE [JXBM] = @JXBM) AND M.[FLAG] = '1'");
            parameter.Add(DbParameters.CreateDbParameter("@JXBM", jxbm));
            return this.HQPASRepository().FindList<AssessmentObjectModel>(strSql.ToString(), parameter.ToArray());
        }

        /// <summary>
        /// 获取科室编码列表
        /// </summary>
        /// <param name="jxbm"></param>
        /// <returns></returns>
        public IEnumerable<AssessmentObjectModel> GetDepartmentBmList(string jxbm)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(jxbm))
            {
                strSql.Append(@"SELECT DISTINCT D.[ID] DEPTID
                                      ,D.[OFFICENAME] DEPTNAME
                                FROM [HQPAS].[BPMS].[PMR001_MOR] M
                                LEFT JOIN [HQPAS].[BPMS].[PMR005_ORG] O ON M.[ADMINISTRATIVECODE] = O.[ADMINISTRATIVECODE]
                                RIGHT JOIN [HQPAS].[BPMS].[PMR008_OFFIECES] D ON O.[ORGCODE] = D.[ORGID]
                                WHERE M.[ORGID] = (SELECT [JXQY] FROM [HQPAS].[BPMS].[BPE_SC001] WHERE [JXBM] = @JXBM) AND M.[FLAG] = '1'
                                AND O.[FLAG] = '1'");
                parameter.Add(DbParameters.CreateDbParameter("@JXBM", jxbm));
            }
            else
            {
                strSql.Append(@"SELECT DISTINCT D.[ID] DEPTID
                                      ,D.[OFFICENAME] DEPTNAME
                                FROM [HQPAS].[BPMS].[PMR001_MOR] M
                                LEFT JOIN [HQPAS].[BPMS].[PMR005_ORG] O ON M.[ADMINISTRATIVECODE] = O.[ADMINISTRATIVECODE]
                                RIGHT JOIN [HQPAS].[BPMS].[PMR008_OFFIECES] D ON O.[ORGCODE] = D.[ORGID]
                                WHERE M.[FLAG] = '1'
                                AND O.[FLAG] = '1'");
            }
            return this.HQPASRepository().FindList<AssessmentObjectModel>(strSql.ToString(), parameter.ToArray());
        }
    }
}