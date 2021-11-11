using LeaRun.Application.Entity.BusinessManage;
using LeaRun.Application.Entity.BusinessManage.ViewModel;
using LeaRun.Application.IService.BusinessManage;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Service.BusinessManage
{
    /// <summary>
    /// 
    /// </summary>
    public class BusinessSystemService: RepositoryFactory, IBusinessSystemService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<SystemInfoEntity> GetSystemList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"  SELECT * FROM [HQPAS].[dbo].[SystemInfo] ");
            return this.HQPASRepository().FindList<SystemInfoEntity>(strSql.ToString(), parameter.ToArray(), pagination);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SystemEditionInfoModel> GetSystemEditionInfo(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@" SELECT * FROM [HQPAS].[dbo].[SystemInfo] A,[HQPAS].[dbo].[EditionInfo] B WHERE A.sys_code = B.system_code ");
            return this.HQPASRepository().FindList<SystemEditionInfoModel>(strSql.ToString(),parameter.ToArray(),pagination);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<SystemParameterEntity> GetSystemParameters(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@" SELECT * FROM [HQPAS].[dbo].[SystemParameter] ");
            return this.HQPASRepository().FindList<SystemParameterEntity>(strSql.ToString(), parameter.ToArray(), pagination);
        }
    }
}
