using LeaRun.Application.Entity.SettingManage;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.SettingManage
{
    public interface IPMR009UserService
    {
        #region 获取数据
        /// <summary>
        /// 医疗卫生人员列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<PMR009UserEntity> GetList(Pagination pagination, string queryJson);
        
        /// <summary>
        /// 医疗卫生人员列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<PMR009UserEntity> GetList(string queryJson);
        
        /// <summary>
        /// 医疗卫生人员实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        PMR009UserEntity GetEntity(string keyValue);
       
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除医疗卫生人员表
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveForm(string keyValue);
       
        /// <summary>
        /// 保存医疗卫生人员表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">主管机构信息实体</param>
        /// <returns></returns>
        void SaveForm(string keyValue, PMR009UserEntity entity);
        
        #endregion
    }
}
