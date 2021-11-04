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
    public interface IBpeVa004Service
    {
        IEnumerable<BpeVa004Model> GetPageList(Pagination pagination, string queryJson);

        BpeVa004Entity GetRecord(string keyValue);

        BpeVa004Model GetRecordModel(string keyValue);

        void DeleteRecord(string keyValue);

        void AddOrUpdateRecord(BpeVa004Entity entity);
    }
}
