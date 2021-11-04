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
    /// 医疗机构注册
    /// </summary>
    public interface IPMR005OrgService
    {
        #region 获取数据
        /// <summary>
        /// 分布获取医疗机构注册列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        IEnumerable<PMR005OrgEntity> GetList(Pagination pagination, string queryJson);
        /// <summary>
        /// 医疗机构注册列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<PMR005OrgEntity> GetList(string queryJson);
        /// <summary>
        /// 医疗机构注册列表
        /// </summary>
        /// <param name="jxbm">年度绩效编码</param>
        /// <returns></returns>
        IEnumerable<PMR005OrgEntity> GetListByJXBM(string jxbm);
        /// <summary>
        /// 医疗机构注册实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        PMR005OrgEntity GetEntity(string keyValue);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除医疗机构注册
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveForm(string keyValue);
        /// <summary>
        /// 保存医疗机构注册表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">医疗机构注册实体</param>
        /// <returns></returns>
        void SaveForm(string keyValue, PMR005OrgEntity entity);
        #endregion
    }
}