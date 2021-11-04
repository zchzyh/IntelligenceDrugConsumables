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
    public class BpeTa003BLL
    {
        private readonly IBpeTa003Service _service = new BpeTa003Service();

        public void AddOrUpdateRecord(BpeTa003Entity entity)
        {
            _service.AddOrUpdateRecord(entity);
        }

        public void AddOrUpdateRecord(List<BpeTa003Entity> entities)
        {
            _service.AddOrUpdateRecord(entities);
        }

        public void DeleteRecord(string keyValue)
        {
            _service.DeleteRecord(keyValue);
        }

        public IEnumerable<BpeTa003Model> GetPageList(Pagination pagination, string queryJson)
        {
            return _service.GetPageList(pagination, queryJson);
        }

        public IEnumerable<BpeTa002Model> GetQuantifyPageList(Pagination pagination, string queryJson)
        {
            return _service.GetQuantifyPageList(pagination, queryJson);
        }

        public BpeTa003Entity GetRecord(string keyValue)
        {
           return  _service.GetRecord(keyValue);
        }

        public BpeTa003Model GetRecordModel(string keyValue)
        {
            return _service.GetRecordModel(keyValue);
        }


    }
}
