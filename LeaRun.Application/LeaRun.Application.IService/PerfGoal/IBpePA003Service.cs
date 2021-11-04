using LeaRun.Application.Entity.PerfGoal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.PerfGoal
{
    /// <summary>
    /// 单位方案信息
    /// </summary>
    public interface IBpePA003Service
    {
        #region 获取数据
        /// <summary>
        /// 获取部门/科室方案信息实体
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <returns></returns>
        BpePA003Entity GetEntity(string keyvalue);
        /// <summary>
        /// 获取部门/科室方案信息
        /// </summary>
        /// <param name="year"></param>
        /// <param name="fabh"></param>
        /// <returns></returns>
        IEnumerable<BpePA003Entity> GetSchemeDepList(string year, string fabh);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除单位方案信息
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        void RemoveForm(string keyvalue);
        /// <summary>
        /// 保存单位方案信息表单（新增、修改）
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <param name="entity">单位方案信息实体</param>
        /// <returns></returns>
        void SaveForm(string keyvalue, BpePA003Entity entity);
        /// <summary>
        /// 保存方案的科室列表
        /// </summary>
        /// <param name="fabh"></param>
        /// <param name="entities"></param>
        string[] SaveSchemeDepList(string fabh, string jxbm, string jgfabh, string jgbms, List<BpePA003Entity> entities);
        #endregion
    }
}