using System.Collections.Generic;
using LeaRun.Application.Entity.PerfStrategy;
using LeaRun.Application.Entity.PerfStrategy.ViewModel;
using LeaRun.Application.IService.PerfStrategy;
using LeaRun.Application.Service.PerfStrategy;
using LeaRun.Util.WebControl;

namespace LeaRun.Application.Busines.PerfStrategy
{
    /// <summary>
    /// 使命远景信息表
    /// </summary>
    public class BpeVa003BLL
    {
        private readonly IBpeVa003Service _service = new BpeVa003Service();

        public void AddOrUpdateRecord(BpeVa003Entity entity)
        {
            _service.AddOrUpdateRecord(entity);
        }

        public void DeleteRecord(string keyValue)
        {
            _service.DeleteRecord(keyValue);
        }

        public IEnumerable<BpeVa003Model> GetPageList(Pagination pagination, string queryJson)
        {
            return _service.GetPageList(pagination, queryJson);
        }

        public BpeVa003Entity GetRecord(string keyValue)
        {
           return  _service.GetRecord(keyValue);
        }

        public BpeVa003Model GetRecordModel(string keyValue)
        {
            return _service.GetRecordModel(keyValue);
        }


    }
}
