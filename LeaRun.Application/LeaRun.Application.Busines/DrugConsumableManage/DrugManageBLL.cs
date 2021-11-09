using LeaRun.Util.WebControl;
using System.Collections.Generic;
using LeaRun.Application.Entity.DrugConsumableManage;
using LeaRun.Application.IService.DrugConsumableManage;
using LeaRun.Application.Service.DrugConsumableManage;

namespace LeaRun.Application.Busines.DrugConsumableManage
{
    /// <summary>
    /// 药品标准库
    /// </summary>
    public class DrugManageBLL
    {
        private IDrugStandardService drugmanageservice = new DrugStandardService();

        /// <summary>
        /// 获取药品清单数据
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DrugStandardEntity> GetDrugStandardList(Pagination pagination, string queryJson)
        {
            return drugmanageservice.GetList(pagination, queryJson);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<DrugCompanyEntity> GetCompanyDrugList(Pagination pagination, string queryJson)
        {
            return drugmanageservice.GetCompanyDrugList(pagination, queryJson);
        }

    }
}
