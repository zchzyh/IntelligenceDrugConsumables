using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.Entity.SettingManage;
using LeaRun.Application.IService.CollectionManage;
using LeaRun.Application.IService.SettingManage;
using LeaRun.Application.Service.CollectionManage;
using LeaRun.Application.Service.SettingManage;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;

namespace LeaRun.Application.Busines.CollectionManage
{
   public class BpcSp008Bll
    {
        IBpcSp008Service _bpcSp008Service =new BpcSp008Service();
        IBpcSp001Service _bpcSp001Service = new BpcSp001Service();
        IPMR005OrgService _pmr005OrgService = new PMR005OrgService();

        public void AddOrUpdateRecord(BpcSp008Entity entity)
        {
            _bpcSp008Service.AddOrUpdateRecord(entity);
        }

        public void AddOrUpdateRecords(string orgId,string officeId, List<BpcSp008Entity> entities)
        {
            BpcSp008Entity existEntity;
            if (_bpcSp008Service.ExistsRecord(orgId, officeId, entities, out  existEntity))
            {
                var tbEntity = _bpcSp001Service.GetEntity(existEntity.CJBBM);
                var org = _pmr005OrgService.GetList(null).FirstOrDefault(m=>m.ORGCODE==existEntity.OrgId);
                var officEntity = new PMR008OffiecesService().GetEntity(existEntity.DWCSBM);
                if (officEntity.IsEmpty())
                {
                    //如果科室不存在，删除该记录
                    _bpcSp008Service.DeleteRecord(existEntity.CJBBM);
                }
                else
                throw new Exception(tbEntity.CJBMC + $"  已经被配置给(机构:{(org.IsEmpty()?"":org.MANAGERORGNAME)},科室:{(officEntity.IsEmpty()?"":officEntity.OFFICENAME)}),请确认");
            }

            _bpcSp008Service.AddOrUpdateRecords(orgId, officeId, entities);
        }

        public void DeleteRecord(string keyValue)
        {
            _bpcSp008Service.DeleteRecord(keyValue);
        }

        public BpcSp008Entity GetEntity(string keyValue)
        {
            return _bpcSp008Service.GetEntity(keyValue);
        }

        public IEnumerable<BpcSp008Entity> GetList()
        {
            return _bpcSp008Service.GetList();
        }

        public IEnumerable<BpcSp008Entity> GetPageList(Pagination pagination, string queryJson)
        {
            return _bpcSp008Service.GetPageList(pagination, queryJson);
        }
    }
}
