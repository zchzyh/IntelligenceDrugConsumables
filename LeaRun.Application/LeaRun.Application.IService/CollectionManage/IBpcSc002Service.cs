using System.Collections.Generic;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.Entity.CollectionManage.ViewModel;
using LeaRun.Util.WebControl;

namespace LeaRun.Application.IService.CollectionManage
{
    public interface IBpcSc002Service
    {

        IEnumerable<BpcSc002Entity> GetList(string year,string tbBm);
        IEnumerable<BpcSc002Entity> GetList(string year);
        IEnumerable<TableRowModel> GetRowDataSort(Pagination pagination, string queryJson);
        void SaveData(string year, string tbBm, List<BpcSc002Entity> entities);

        void SaveData(string year, List<BpcSc002Entity> entities);
    }
}
