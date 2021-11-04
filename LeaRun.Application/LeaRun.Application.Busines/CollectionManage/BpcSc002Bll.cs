using System;
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
    public class BpcSc002BLL
    {
        private readonly IBpcSc002Service _service = new BpcSc002Service();

        #region 获取数据

        ///// <summary>
        ///// 获取列表
        ///// </summary>
        ///// <param name="pagination"></param>
        ///// <param name="queryJson">查询参数</param>
        ///// <returns>返回列表</returns>
        //public IEnumerable<BpcSc002Entity> GetPageList(Pagination pagination, string queryJson)
        //{
        //    return _service.GetList(pagination, queryJson);
        //}

        public IEnumerable<BpcSc002Entity> GetList(string year,string tbBm)
        {
            return _service.GetList(year,tbBm).ToList();
        }
        public IEnumerable<BpcSc002Entity> GetList(string year)
        {
            return _service.GetList(year).ToList();
        }
        public IEnumerable<TableRowModel> GetRowDataSort(Pagination pagination,string queryJson)
        {
            return _service.GetRowDataSort(pagination, queryJson).ToList();
        }
        public void SaveData(string year, string tbBm, List<BpcSc002Entity> entities)
        {
            _service.SaveData(year,tbBm, entities);
        }
        private void SaveData(string year, List<BpcSc002Entity> entities)
        {
            _service.SaveData(year, entities);
        }

        //public BpcSc002Entity GetEntity(string keyValue)
        //{
        //    return _service.GetEntity(keyValue);
        //}

        //public void ModifyStatus(string keyValue, bool enabled)
        //{
        //    _service.ModifyStatus(keyValue, enabled);
        //}

        #endregion

        #region 提交数据

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year">当前年</param>
        public void CopyLastYearRowSetting(string year)
        {
            //读取上一年的行配置
            var lastYearData = GetList((int.Parse(year) - 1).ToString()).ToList();
            if (lastYearData.Count < 1)
            {
               return;
            }
            foreach (var data in lastYearData)
            {
                data.ND = year;
                data.XH = string.Empty;
            }
            SaveData(year, lastYearData);
        }

        //public void AddLjSetting(BpcSc002Entity entity)
        //{
        //    _service.SaveForm(entity);
        //}

        //public void ModifyLjSetting(string keyValue, BpcSc002Entity entity)
        //{
        //    _service.SaveForm(entity);
        //}

        //public void DeleteRecord(string keyValue)
        //{
        //    _service.DeleteRecord(keyValue);
        //}

        #endregion
    }
}