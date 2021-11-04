using LeaRun.Application.Entity.PerfReport;
using LeaRun.Application.Entity.PerfReport.ViewModel;
using LeaRun.Application.IService.PerfReport;
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

namespace LeaRun.Application.Service.PerfReport
{
    /// <summary>
    /// 
    /// </summary>
    public class FinalAssessmentRepService : RepositoryFactory
    {
        /// <summary>
        /// 最终评定报告
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<FinalAssessmentModel> GetList(Pagination pagination, string queryJson)
        {
            string  queryParam = queryJson;
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select a.serial_num,  
                                   a.year_code year_code,
                                   d.JXND [year],
	                               b.BSCMC dname, 
	                               e.CSFMC sfname,
	                               c.ZTMC sname,
	                               a.assessment,
	                               a.[status]  
	                               from BPMS.BPE_RA005 a
	                               left join BPMs.BPE_VA002 b ON b.BSCBH =a.cd
	                               left join BPMs.BPE_VA003 c on c.ZTBH =a.cs
	                               left join BPMs.BPE_SC001 d on a.year_code =d.JXBM
	                               left join BPMs.BPE_VA004 e ON e.CSFBH =a.csf
	                               where 1 =1
	                            ");
            parameter.Add(DbParameters.CreateDbParameter("@ServiceStatusType", Config.GetValue("ServiceStatusType")));
            parameter.Add(DbParameters.CreateDbParameter("@RunningStatusType", Config.GetValue("RunningStatusType")));
            //绩效年度
            if (!queryParam.IsEmpty())
            {
                strSql.Append(" AND a.[year_code] = @year_code ");
                parameter.Add(DbParameters.CreateDbParameter("@year_code", queryParam));
            }
            ////绩效主体
            //if (!queryParam["orgid"].IsEmpty())
            //{
            //    strSql.Append(" AND B.[JXQY] = @JXQY ");
            //    parameter.Add(DbParameters.CreateDbParameter("@JXQY", queryParam["orgid"].ToString()));
            //}
            return HQPASRepository().FindList<FinalAssessmentModel>(strSql.ToString(), parameter.ToArray(), pagination);
        }

    }
}
