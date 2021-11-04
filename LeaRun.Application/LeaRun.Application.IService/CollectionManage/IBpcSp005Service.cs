using System.Collections.Generic;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.Entity.CollectionManage.ViewModel;
using LeaRun.Util.WebControl;

namespace LeaRun.Application.IService.CollectionManage
{
    public interface IBpcSp005Service
    {
        IEnumerable<UserAuthTableInfoModel> GetPageList(Pagination pagination, string queryJson);

        IEnumerable<BpcSp005Entity> GetUserTableList(string year,string userId);

        IEnumerable<BpcSp005Entity> GetUserTableList(string year);

        void SaveData(string year, string userId, List<BpcSp005Entity> entities);

        bool ExistsRecord(string userId,List<BpcSp005Entity> entities, out BpcSp005Entity existEntity);

        UserAuthTableInfoModel GetUserInfo(string userId);

        void DeleteRecord(string keyValue);

        void DeleteRecordByUserId(string userId);
    }
}
