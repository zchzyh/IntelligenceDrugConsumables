using System.Collections.Generic;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.IService.CollectionManage;
using LeaRun.Application.Service.CollectionManage;
using LeaRun.Util.WebControl;

namespace LeaRun.Application.Busines.CollectionManage
{
    /// <summary>
    /// 采集基本信息表业务类
    /// </summary>
    public class BpcSp001Bll
    {
        private readonly IBpcSp001Service _service = new BpcSp001Service();

        #region 获取数据

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<BpcSp001Entity> GetPageList(Pagination pagination, string queryJson)
        {
            return _service.GetPageList(pagination,queryJson);
        }

        public IEnumerable<BpcSp001Entity> GetList()
        {
            return _service.GetList();
        }

        public BpcSp001Entity GetEntity(string keyValue)
        {
            return _service.GetEntity(keyValue);
        }

        public int GetTableCountByCategory(string category)
        {
            return _service.GetTableCountByCategory(category);
        }
        public void ModifyStatus(string keyValue, bool enabled)
        {
             _service.ModifyStatus(keyValue, enabled);
        }
         
        #endregion

        #region 提交数据

        public void SaveForm(BpcSp001Entity entity)
        {
            _service.SaveForm( entity);
        }

        //public void ModifyTable(string keyValue, BpcSp001Entity entity)
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
