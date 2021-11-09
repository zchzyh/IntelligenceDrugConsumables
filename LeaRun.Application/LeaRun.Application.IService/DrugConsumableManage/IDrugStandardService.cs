using LeaRun.Application.Entity.DrugConsumableManage;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.DrugConsumableManage
{
    public interface IDrugStandardService
    {
        DrugStandardEntity GetEntity(string keyvalue);

        IEnumerable<DrugStandardEntity> GetList(Pagination pagination,string keyvalue);

        IEnumerable<DrugCompanyEntity> GetCompanyDrugList(Pagination pagination, string keyvalue);
    }
}
