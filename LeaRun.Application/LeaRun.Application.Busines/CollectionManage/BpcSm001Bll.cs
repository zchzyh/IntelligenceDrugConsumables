using System.Collections.Generic;
using LeaRun.Application.Entity.PerfConfig;
using LeaRun.Application.IService.CollectionManage;
using LeaRun.Application.Service.CollectionManage;
using LeaRun.Util.WebControl;

namespace LeaRun.Application.Busines.CollectionManage
{
    public  class BpcSm001Bll
    {
        readonly IBpcSm001Service _bpcSm001Service = new BpcSm001Service();

        /// <summary>
        /// 获取数据项分类信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BpcSM001Entity> GetList()
        {
            return _bpcSm001Service.GetList();
        }

        public IEnumerable<BpcSM001Entity> GetPageList(Pagination pagination, string queryJson)
        {
            return _bpcSm001Service.GetPageList(pagination, queryJson);
        }

        public BpcSM001Entity GetEntity(string keyValue)
        {
            return _bpcSm001Service.GetEntity(keyValue);
        }

        public void DeleteRecord(string keyValue)
        {
              _bpcSm001Service.DeleteRecord(keyValue);
        }

        public void AddorUpdateRecord(BpcSM001Entity entity)
        {
                _bpcSm001Service.AddorUpdateRecord(entity);
        }

    }
}
