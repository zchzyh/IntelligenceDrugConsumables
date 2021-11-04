using System.Collections.Generic;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.IService.CollectionManage;
using LeaRun.Application.Service.CollectionManage;
using LeaRun.Util.WebControl;

namespace LeaRun.Application.Busines.CollectionManage
{
    /// <summary>
    /// 采集表逻辑配置
    /// </summary>
    public class BpcSc006BLL
    {
        private readonly IBpcSc006Service _service = new BpcSc006Service();

        #region 获取数据

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<BpcSc006Entity> GetPageList(Pagination pagination, string queryJson)
        {
            return _service.GetPageList(pagination, queryJson);
        }



        public BpcSc006Entity GetEntity(string keyValue)
        {
            return _service.GetEntity(keyValue);
        }

        public void ModifyStatus(string keyValue, bool enabled)
        {
            _service.ModifyStatus(keyValue, enabled);
        }

        #endregion

        #region 提交数据


        public void AddOrUpdateRecord(BpcSc006Entity entity)
        {
            _service.AddOrUpdateRecord(entity);
        }

        public bool ExistsRecord(string tableNo)
        {

            return _service.ExistsRecord(tableNo);
        }

        public void DeleteRecord(string keyValue)
        {
            _service.DeleteRecord(keyValue);
        }
        #endregion
    }
}
