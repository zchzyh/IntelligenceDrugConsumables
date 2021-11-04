using LeaRun.Application.Entity.SettingManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaRun.Util.WebControl;

namespace LeaRun.Application.IService.SettingManage
{
    public interface IPMR008OffiecesService
    {
        #region 获取数据
        /// <summary>
        /// 医疗机构科室信息列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<PMR008OffiecesEntity> GetList();

        /// <summary>
        /// 医疗机构科室信息列表(分页)
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        IEnumerable<PMR008OffiecesEntity> GetPageList(Pagination pagination, string queryJson);

        /// <summary>
        /// 医疗机构科室信息实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        PMR008OffiecesEntity GetEntity(string keyValue);
       
        #endregion

        #region 验证数据
        /// <summary>
        /// 医疗机构科室编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        bool ExistEnCode(string enCode, string keyValue);
       
        /// <summary>
        /// 医疗机构科室名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        bool ExistFullName(string fullName, string keyValue);
       
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除医疗机构科室
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveForm(string keyValue);
       
        /// <summary>
        /// 保存医疗机构科室表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="departmentEntity">机构实体</param>
        /// <returns></returns>
        void SaveForm(string keyValue, PMR008OffiecesEntity offiecesEntity);
       
        #endregion
    }
}
