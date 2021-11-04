using System.Collections.Generic;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.Entity.CollectionManage.ViewModel;
using LeaRun.Util.WebControl;

namespace LeaRun.Application.IService.CollectionManage
{
    public interface IBpcSc003Service
    {
        IEnumerable<BpcSc003Entity> GetList(string year, string tbBm);
        IEnumerable<BpcSc003Entity> GetList(string year);
        IEnumerable<BpcSc003Entity> GetList(Pagination pagination, string year, string tbBm);
        IEnumerable<BpcSc003Entity> GetColSetting(Pagination pagination, string tbBm);
        void SaveData(BpcSc003Entity entity);

        /// <summary>
        /// 获取单个实体信息
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        BpcSc003Entity GetEntity(string keyValue);

        IEnumerable<MyTableHeaderModel> GetTableHeader(string year, string tableNo);
        IEnumerable<MyTableRowModel> GetTableRow(string year, string tableNo);

        void DeleteRecord(string keyValue);
        void SaveData(string year, List<BpcSc003Entity> entities);
    }
}