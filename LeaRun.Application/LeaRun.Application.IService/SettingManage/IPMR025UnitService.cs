using LeaRun.Application.Entity.SettingManage;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.SettingManage
{
    public interface IPMR025UnitService
    {
        #region 获取数据
        /// <summary>
        /// 行政区域列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<PMR025UnitEntity> GetList(Pagination pagination, string queryJson);

        /// <summary>
        /// 获取所有行政区域
        /// </summary>
        /// <returns></returns>
        IEnumerable<PMR025UnitEntity> GetList();


        /// <summary>
        /// 行政区域实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        PMR025UnitEntity GetEntity(string keyValue);

        #endregion

        #region 提交数据
        /// <summary>
        /// 删除行政区域
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveForm(string keyValue);

        /// <summary>
        /// 保存行政区域表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="pmr025UnitEntity">基础数据分类实体</param>
        /// <returns></returns>
        void SaveForm(string keyValue, PMR025UnitEntity pmr025UnitEntity);
        
        #endregion
    }
}
