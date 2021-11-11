using LeaRun.Application.Entity.BusinessManage;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.BusinessManage
{
    public interface IBusinessDataService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="keyvalue"></param>
        /// <returns></returns>
        IEnumerable<PantientInfoEntity> GetPantientInfoList(Pagination pagination, string keyvalue);
    }
}
