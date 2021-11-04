using System;
using System.Collections.Generic;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.Entity.CollectionManage.ViewModel;
using LeaRun.Application.IService.CollectionManage;
using LeaRun.Application.Service.CollectionManage;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;

namespace LeaRun.Application.Busines.CollectionManage
{
    public  class BpcSp005Bll
    {
        private readonly IBpcSp005Service _service = new BpcSp005Service();
        
        public IEnumerable<UserAuthTableInfoModel> GetPageList(Pagination pagination, string queryJson)
        {
            return _service.GetPageList(pagination, queryJson);
        }

        public IEnumerable<BpcSp005Entity> GetUserTableList(string year, string userId)
        {
            return _service.GetUserTableList(year, userId);
        }
        public IEnumerable<BpcSp005Entity> GetUserTableList(string year)
        {
            return _service.GetUserTableList(year);
        }

        public void SaveData(string year, string userId, List<BpcSp005Entity> entities)
        {
            BpcSp001Bll bpcSp001Bll = new BpcSp001Bll();
            BpcSp005Entity existEntity;
            if (_service.ExistsRecord(userId, entities, out existEntity))
            {
                var tbEntity = bpcSp001Bll.GetEntity(existEntity.CJBBM);
                var userInfo = _service.GetUserInfo(existEntity.USERID) ?? new UserAuthTableInfoModel();
                if (userInfo.UserId.IsEmpty())
                {
                    //不存在此账户
                    _service.DeleteRecordByUserId(existEntity.USERID);
                }
                else
                {
                    throw new Exception(tbEntity.CJBMC +
                                        $"  已经被配置给【用户:{userInfo.UserName + "(账号:" + existEntity.USERID + ")"}】,请确认");
                }
            }

            _service.SaveData(year, userId, entities);
        }
    }
}
