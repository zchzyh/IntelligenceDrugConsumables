using System.Collections.Generic;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.Entity.CollectionManage.ViewModel;
using LeaRun.Application.Entity.PerfStrategy;
using LeaRun.Application.Entity.PerfStrategy.ViewModel;
using LeaRun.Util.WebControl;

namespace LeaRun.Application.IService.PerfStrategy
{
    /// <summary>
    /// 使命远景信息
    /// </summary>
    public interface IBpeTa003Service
    {
        IEnumerable<BpeTa003Model> GetPageList(Pagination pagination, string queryJson);

        IEnumerable<BpeTa002Model> GetQuantifyPageList(Pagination pagination, string queryJson);
      

        BpeTa003Entity GetRecord(string keyValue);

        BpeTa003Model GetRecordModel(string keyValue);

        void DeleteRecord(string keyValue);

        void AddOrUpdateRecord(BpeTa003Entity entity);

        void AddOrUpdateRecord(List<BpeTa003Entity> entities);
    }
}
