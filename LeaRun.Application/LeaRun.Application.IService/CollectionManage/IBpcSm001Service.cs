using System.Collections.Generic;
using LeaRun.Application.Entity.PerfConfig;
using LeaRun.Util.WebControl;

namespace LeaRun.Application.IService.CollectionManage
{
    public interface IBpcSm001Service
    {
        IEnumerable<BpcSM001Entity> GetList();

        IEnumerable<BpcSM001Entity> GetPageList(Pagination pagination, string queryJson);

        BpcSM001Entity GetEntity(string keyValue);

        void DeleteRecord(string keyValue);

        void AddorUpdateRecord(BpcSM001Entity entity);
    }
}
