using LeaRun.Application.Entity.BusinessManage;
using LeaRun.Application.Entity.BusinessManage.ViewModel;
using LeaRun.Application.IService.BusinessManage;
using LeaRun.Application.Service.BusinessManage;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Busines.BusinessManage
{
    /// <summary>
    /// 
    /// </summary>
    public class BusinessSystemBLL
    {
        public IBusinessSystemService businessSystemService = new BusinessSystemService();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<SystemInfoEntity> GetSystemList(Pagination pagination, string queryJson)
        {
            return businessSystemService.GetSystemList(pagination, queryJson);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<SystemEditionInfoModel> GetSystemEditionInfo(Pagination pagination, string queryJson)
        {
            return businessSystemService.GetSystemEditionInfo(pagination, queryJson);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<SystemParameterEntity> GetSystemParameters(Pagination pagination, string queryJson)
        {
            return businessSystemService.GetSystemParameters(pagination, queryJson);
        }
    }
}
