using LeaRun.Application.Entity.PerfGoal;
using LeaRun.Application.IService.PerfGoal;
using LeaRun.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Service.PerfGoal
{
    /// <summary>
    /// 定量指标目标值
    /// </summary>
    public class BpeTA004Service : RepositoryFactory<BpeTA004Entity>, IBpeTA004Service
    {
        #region 获取数据

        /// <summary>
        /// 定量指标目标值实体
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <returns></returns>
        public BpeTA004Entity GetEntity(string keyvalue)
        {
            return this.HQPASRepository().FindEntity(keyvalue);
        }

        /// <summary>
        /// 定量指标目标值实体
        /// </summary>
        /// <param name="jxbm">年度绩效编码</param>
        /// <param name="jgfabh">部门方案编号</param>
        /// <param name="kpibh">KPI编号</param>
        /// <returns></returns>
        public BpeTA004Entity GetEntity(string jxbm, string jgfabh, string kpibh)
        {
            return this.HQPASRepository().FindEntity(e => e.JXBM == jxbm && e.JGFABH == jgfabh && e.KPIBH == kpibh);
        }

        #endregion

        #region 提交数据
        /// <summary>
        /// 保存定量指标目标值表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">定量指标目标值实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, BpeTA004Entity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.HQPASRepository().Update(entity);
            }
            else
            {
                entity.Create();
                this.HQPASRepository().Insert(entity);
            }
        }
        #endregion
    }
}