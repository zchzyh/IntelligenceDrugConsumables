using LeaRun.Application.Entity.SettingManage;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.SettingManage
{
    /// <summary>
    /// 主管机构信息
    /// </summary>
    public interface IPMR001MorService
    {
        #region 获取数据
        /// <summary>
        /// 主管机构信息列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<PMR001MorEntity> GetList(string queryJson);
        /// <summary>
        /// 主管机构信息实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        PMR001MorEntity GetEntity(string keyValue);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除主管机构信息
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveForm(string keyValue);
        /// <summary>
        /// 保存主管机构信息表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">主管机构信息实体</param>
        /// <returns></returns>
        void SaveForm(string keyValue, PMR001MorEntity entity);
        #endregion
    }
}