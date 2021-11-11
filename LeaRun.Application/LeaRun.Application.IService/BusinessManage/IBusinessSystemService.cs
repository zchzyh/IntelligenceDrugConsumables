using LeaRun.Application.Entity.BusinessManage;
using LeaRun.Application.Entity.BusinessManage.ViewModel;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.BusinessManage
{
    public interface IBusinessSystemService
    {
        /// <summary>
        /// 获取诺博业务系统的清单信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="keyvalue"></param>
        /// <returns></returns>
        IEnumerable<SystemInfoEntity> GetSystemList(Pagination pagination, string keyvalue);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="keyvalue"></param>
        /// <returns></returns>
        IEnumerable<SystemEditionInfoModel> GetSystemEditionInfo(Pagination pagination, string keyvalue);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="keyvalue"></param>
        /// <returns></returns>
        IEnumerable<SystemParameterEntity> GetSystemParameters(Pagination pagination, string keyvalue);
    }
}
