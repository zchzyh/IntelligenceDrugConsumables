using System.Collections.Generic;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.Entity.CollectionManage.ViewModel;
using LeaRun.Application.Entity.PerfConfig;
using LeaRun.Application.IService.CollectionManage;
using LeaRun.Application.Service.CollectionManage;
using LeaRun.Util.WebControl;

namespace LeaRun.Application.Busines.CollectionManage
{
    /// <summary>
    ///年度采集表管理
    /// </summary>
    public class BpcSp003BLL
    {
        private readonly IBpcSp003Service _service = new BpcSp003Service();

        #region 获取数据

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<BpeSC001Entity> GetPageList(Pagination pagination, string queryJson)
        {
            return _service.GetPageList(pagination, queryJson);
        }

        public IEnumerable<RowColSettingModel> GetRowColPageList(Pagination pagination, string queryJson)
        {
            return _service.GetRowColPageList(pagination, queryJson);
        }

        public IEnumerable<BpcSp003Entity> GetList()
        {
            return _service.GetList();
        }

        public IEnumerable<BpcSp003Entity> GetListByYear(string year)
        {
            return _service.GetListByYear(year);
        }

        public  IEnumerable<BpcSp001Entity> GetTableListByYear(string year)
        {
            return _service.GetTableListByYear(year);
        }
        public BpeSC001Entity GetActiveYearSetting()
        {
            return _service.GetActiveYearSetting();
        }

        public BpcSp003Entity GetEntity(string keyValue)
        {
            return _service.GetEntity(keyValue);
        }

        public void SaveForm(string year,List<BpcSp003Entity> entities)
        {
             _service.SaveForm(year,entities);
        }
        #endregion

        #region 提交数据
        public void DeleteRecord(string keyValue)
        {
            _service.DeleteRecord(keyValue);
        }
        #endregion
    }
}
