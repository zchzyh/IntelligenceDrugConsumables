using System.Collections.Generic;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.Entity.SettingManage;
using LeaRun.Util.WebControl;

namespace LeaRun.Application.IService.CollectionManage
{
    public interface IBpcSm002Service
    {
        IEnumerable<BpcSM002Entity> GetList();
        IEnumerable<BpcSM002Entity> GetList(string grade,string parentId);

        IEnumerable<BpcSM002Entity> GetPageList(Pagination pagination, string queryJson);

        BpcSM002Entity GetEntity(string keyValue);

        void DeleteRecord(string keyValue);

        void AddOrUpdateRecord(BpcSM002Entity entity);
    }
}
