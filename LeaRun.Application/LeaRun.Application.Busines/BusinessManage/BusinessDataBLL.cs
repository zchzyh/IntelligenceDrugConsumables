using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaRun.Application.Entity.BusinessManage;
using LeaRun.Application.IService.BusinessManage;
using LeaRun.Application.Service.BusinessManage;
using LeaRun.Util.WebControl;

namespace LeaRun.Application.Busines.BusinessManage
{
    public class BusinessDataBLL
    {
        private IBusinessDataService businessdataService = new BusinessDataService();

        public IEnumerable<PantientInfoEntity> GetPantientInfoList(Pagination pagination, string queryJson)
        {
            return businessdataService.GetPantientInfoList(pagination, queryJson);
        }
    }
    
}
