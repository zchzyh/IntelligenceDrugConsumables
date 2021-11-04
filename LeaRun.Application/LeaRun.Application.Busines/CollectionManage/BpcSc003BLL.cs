using System.Collections.Generic;
using System.Linq;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.Entity.CollectionManage.ViewModel;
using LeaRun.Application.IService.CollectionManage;
using LeaRun.Application.Service.CollectionManage;
using LeaRun.Util.WebControl;

namespace LeaRun.Application.Busines.CollectionManage
{
    /// <summary>
    /// 采集表逻辑配置
    /// </summary>
    public class BpcSc003BLL
    {
        private readonly IBpcSc003Service _service = new BpcSc003Service();

        #region 获取数据

        ///// <summary>
        ///// 获取列表
        ///// </summary>
        ///// <param name="pagination"></param>
        ///// <param name="queryJson">查询参数</param>
        ///// <returns>返回列表</returns>
        //public IEnumerable<BpcSc003Entity> GetPageList(Pagination pagination, string queryJson)
        //{
        //    return _service.GetList(pagination, queryJson);
        //}

        public IEnumerable<BpcSc003Entity> GetList(string year,string tbBm)
        {
            return _service.GetList(year,tbBm).ToList();
        }
        public IEnumerable<BpcSc003Entity> GetList(string year)
        {
            return _service.GetList(year).ToList();
        }
        public IEnumerable<BpcSc003Entity> GetList(Pagination pagination, string year, string tbBm)
        {
            return _service.GetList(pagination,year, tbBm).ToList();
        }
        public void SaveData(BpcSc003Entity entitiy)
        {
            _service.SaveData(entitiy);
        }

        public void SaveData(string year,  List<BpcSc003Entity> entities)
        {
            _service.SaveData(year, entities);
        }

        public BpcSc003Entity GetEntity(string keyValue)
        {
            return _service.GetEntity(keyValue);
        }

        public IEnumerable<MyTableHeaderModel> GetTableHeader(string year, string tableNo)
        {
            return _service.GetTableHeader(year, tableNo);
        }

        public IEnumerable<MyTableRowModel> GetTableRow(string year, string tableNo)
        {
            return _service.GetTableRow(year, tableNo);
        }
        #endregion

        #region 提交数据

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year">当前年</param>
        /// <param name="tbBm">表编码</param>
        public void CopyLastYearColSetting(string year)
        {
            //读取上一年的行配置
            var lastYearData = GetList((int.Parse(year) - 1).ToString()).ToList();
           
            foreach (var data in lastYearData)
            {
                data.ND = year;
                data.XH = string.Empty;
            }
            SaveData(year, lastYearData);
        }

        //public void AddLjSetting(BpcSc003Entity entity)
        //{
        //    _service.SaveForm(entity);
        //}

        //public void ModifyLjSetting(string keyValue, BpcSc003Entity entity)
        //{
        //    _service.SaveForm(entity);
        //}

        public void DeleteRecord(string keyValue)
        {
            _service.DeleteRecord(keyValue);
        }

        #endregion
    }
}