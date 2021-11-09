using LeaRun.Application.Entity.DrugConsumableManage;
using LeaRun.Application.IService.DrugConsumableManage;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Service.DrugConsumableManage
{
    /// <summary>
    /// 
    /// </summary>
    public class DrugStandardService : RepositoryFactory, IDrugStandardService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyvalue"></param>
        /// <returns></returns>
        public DrugStandardEntity GetEntity(string keyvalue)
        {
            //return HQPASRepository().FindEntity(keyvalue);
            return this.HQPASRepository().FindEntity<DrugStandardEntity>(keyvalue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<DrugStandardEntity> GetList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"  SELECT * FROM [HQPAS].[dbo].[Drug_Standard] ");
            return this.HQPASRepository().FindList<DrugStandardEntity>(strSql.ToString(), parameter.ToArray(), pagination);
        }

        public IEnumerable<DrugCompanyEntity> GetCompanyDrugList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"  SELECT * FROM [HQPAS].[dbo].[Drug_Company] ");
            return this.HQPASRepository().FindList<DrugCompanyEntity>(strSql.ToString(), parameter.ToArray(), pagination);


        }
    }
    
}
