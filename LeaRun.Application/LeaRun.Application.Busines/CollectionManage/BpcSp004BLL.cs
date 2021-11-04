using System;
using System.Collections.Generic;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.Entity.CollectionManage.ViewModel;
using LeaRun.Application.IService.CollectionManage;
using LeaRun.Application.Service.CollectionManage;
using LeaRun.Util.WebControl;

namespace LeaRun.Application.Busines.CollectionManage
{
    public  class BpcSp004BLL
    {
        private readonly IBpcSp004Service _service = new BpcSp004Service();

        public IEnumerable<UserAuthTableInfoModel> GetPageList(Pagination pagination, string queryJson)
        {
            return _service.GetPageList(pagination, queryJson);
        }

        public IEnumerable<BpcSp004Entity> GetUserTableList(string year, string userId)
        {
            return _service.GetUserTableList(year, userId);
        }
        public void SaveData(string year, string userId, List<BpcSp004Entity> entities)
        {
            BpcSp001Bll bpcSp001Bll = new BpcSp001Bll();
            BpcSp004Entity existEntity;
            if (_service.ExistsRecord(userId, entities, out existEntity))
            {
                var tbEntity = bpcSp001Bll.GetEntity(existEntity.CJBBM);
                throw new Exception(tbEntity.CJBMC + $"  已经被配置给(用户:{existEntity.USERID}),请确认");
            }
            _service.SaveData(year, userId, entities);
        }
    }
}
