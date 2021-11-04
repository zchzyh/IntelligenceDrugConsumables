using System;
using System.Collections.Generic;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.IService.CollectionManage;
using LeaRun.Application.Service.CollectionManage;
using LeaRun.Util.WebControl;

namespace LeaRun.Application.Busines.CollectionManage
{
    public class BpcSm003BLL
    {
        private readonly IBpcSm003Service _service = new BpcSm003Service();

        #region 获取数据

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<BpcSm003Entity> GetPageList(Pagination pagination, string queryJson)
        {
           return _service.GetPageList(pagination, queryJson);

        }
        /// <summary>
        /// 获取采集频率列表
        /// </summary>
        /// <param name="year">年度</param>
        /// <param name="plbh">频率编号</param>
        /// <returns></returns>

        public IEnumerable<BpcSm003Entity> GetList(string year, string plbh)
        {
            return _service.GetList(year, plbh);
        }



        public BpcSm003Entity GetEntity(string keyValue)
        {
            return _service.GetEntity(keyValue);
        }

        public void ModifyStatus(string keyValue, bool enabled)
        {
             _service.ModifyStatus(keyValue, enabled);
        }

        public bool ExistsRecord(string year, string value)
        {
            return  _service.ExistsRecord(year, value);
        }
        #endregion

        #region 提交数据

        public void AddOrUpdateRecord(BpcSm003Entity entity)
        {
            _service.AddOrUpdateRecord(entity);
        }

        public void DelRecord(string keyValue)
        {
            _service.DelRecord(keyValue);
        }
        #endregion
    }
}
