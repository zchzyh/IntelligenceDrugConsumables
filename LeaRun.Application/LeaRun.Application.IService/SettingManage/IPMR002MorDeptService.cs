using LeaRun.Application.Entity.SettingManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.SettingManage
{
    public interface IPMR002MorDeptService
    {
        #region 获取数据
        /// <summary>
        /// 主管机构部门列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<PMR002MorDeptEntity> GetList();
        
        /// <summary>
        /// 主管机构部门列表
        /// </summary>
        /// <param name="parentId">父部门Id</param>
        /// <param name="keyword">关键字查询</param>
        /// <returns></returns>
        IEnumerable<PMR002MorDeptEntity> GetList(string parentId, string keyword);
       
        /// <summary>
        /// 主管机构部门实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        PMR002MorDeptEntity GetEntity(string keyValue);
       
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除主管机构部门
        /// </summary>
        /// <param name="keyValue">主键</param>
       void RemoveForm(string keyValue);
       
        /// <summary>
        /// 保存主管机构部门表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="{">区域实体</param>
        /// <returns></returns>
        void SaveForm(string keyValue, PMR002MorDeptEntity deptEntity);
        
        #endregion
    }
}
