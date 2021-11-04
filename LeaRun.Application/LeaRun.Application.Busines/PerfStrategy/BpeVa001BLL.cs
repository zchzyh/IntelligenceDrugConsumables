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
    public class BpeVa001BLL
    {
        private readonly IBpeVa001Service _service = new BpeVa001Service();

        public void AddOrUpdateRecord(BpeVa001Entity entity)
        {
            _service.AddOrUpdateRecord(entity);
        }

        public void DeleteRecord(string keyValue)
        {
            _service.DeleteRecord(keyValue);
        }

        public IEnumerable<BpeVa001Model> GetPageList(Pagination pagination, string queryJson)
        {
            return _service.GetPageList(pagination, queryJson);
        }

        public BpeVa001Entity GetRecord(string keyValue)
        {
           return  _service.GetRecord(keyValue);
        }
         
    }
}
