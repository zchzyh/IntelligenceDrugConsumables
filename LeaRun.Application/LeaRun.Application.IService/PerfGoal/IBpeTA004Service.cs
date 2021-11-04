using LeaRun.Application.Entity.PerfGoal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.PerfGoal
{
    /// <summary>
    /// 定量指标目标值
    /// </summary>
    public interface IBpeTA004Service
    {
        #region 获取数据
        /// <summary>
        /// 定量指标目标值实体
        /// </summary>
        /// <param name="xh">序号</param>
        /// <returns></returns>
        BpeTA004Entity GetEntity(string xh);
        /// <summary>
        /// 定量指标目标值实体
        /// </summary>
        /// <param name="jxbm">年度绩效编码</param>
        /// <param name="jgfabh">部门方案编号</param>
        /// <param name="kpibh">KPI编号</param>
        /// <returns></returns>
        BpeTA004Entity GetEntity(string jxbm, string jgfabh, string kpibh);
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存定量指标目标值表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">定量指标目标值实体</param>
        /// <returns></returns>
        void SaveForm(string keyValue, BpeTA004Entity entity);
        #endregion
    }
}