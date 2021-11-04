using System.Collections.Generic;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.Entity.SettingManage;
using LeaRun.Application.IService.CollectionManage;
using LeaRun.Application.Service.CollectionManage;
using LeaRun.Util.WebControl;

namespace LeaRun.Application.Busines.CollectionManage
{
    /// <summary>
    /// 数据项分类信息表
    /// </summary>
    public class BpcSm002BLL
    {
        readonly IBpcSm002Service _bpcSm002Service = new BpcSm002Service();
   

        public IEnumerable<BpcSM002Entity> GetList()
        {
            return _bpcSm002Service.GetList();
        }
        public IEnumerable<BpcSM002Entity> GetList(string grade, string parentId)
        {
            return _bpcSm002Service.GetList(grade,parentId);
        }
        public IEnumerable<BpcSM002Entity> GetPageList(Pagination pagination, string queryJson)
        {
            return _bpcSm002Service.GetPageList(pagination, queryJson);
        }

        public BpcSM002Entity GetEntity(string keyValue)
        {
            return _bpcSm002Service.GetEntity(keyValue);
        }

        public void DeleteRecord(string keyValue)
        {
              _bpcSm002Service.DeleteRecord(keyValue);
        }

        public void AddOrUpdateRecord(BpcSM002Entity entity)
        {
             _bpcSm002Service.AddOrUpdateRecord(entity);
        }

    }
}
