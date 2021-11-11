using LeaRun.Application.Entity.BusinessManage;
using LeaRun.Application.IService.BusinessManage;
using LeaRun.Data.Repository;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using LeaRun.Util;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Service.BusinessManage
{
    /// <summary>
    /// 
    /// </summary>
    public class BusinessDataService: RepositoryFactory, IBusinessDataService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<PantientInfoEntity> GetPantientInfoList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"  SELECT * FROM [HQPAS].[dbo].[PantientInfo] ");
            return this.HQPASRepository().FindList<PantientInfoEntity>(strSql.ToString(), parameter.ToArray(), pagination);
        }
    }
}
