using LeaRun.Application.Entity.PerfConfig;
using LeaRun.Application.IService.PerfConfig;
using LeaRun.Data.Repository;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Service.PerfConfig
{
    /// <summary>
    /// 绩效定量指标设置
    /// </summary>
    public class BpeTA002Service : RepositoryFactory<BpeTA002Entity>, IBpeTA002Service
    {
        #region 获取数据

        /// <summary>
        /// 绩效定量指标实体
        /// </summary>
        /// <param name="kpibh">KPI编号</param>
        /// <returns></returns>
        public BpeTA002Entity GetEntity(string kpibh)
        {
            return this.HQPASRepository().FindEntity(kpibh);
        }

        /// <summary>
        /// 判断是否已有该定量指标
        /// </summary>
        /// <param name="zbbh">指标编号</param>
        /// <param name="jxbm">绩效年度编码</param>
        /// <returns></returns>
        public bool IsEntityExist(string zbbh, string jxbm)
        {
            return null != this.HQPASRepository().FindEntity(e => e.ZBBH == zbbh && e.JXBM == jxbm);
        }

        #endregion

        #region 提交数据
        /// <summary>
        /// 删除绩效定量指标
        /// </summary>
        /// <param name="kpibh">KPI编号</param>
        public void RemoveForm(string kpibh)
        {
            this.HQPASRepository().Delete(kpibh);
        }
        /// <summary>
        /// 保存绩效定量指标表单（新增、修改）
        /// </summary>
        /// <param name="kpibh">KPI编号</param>
        /// <param name="entity">绩效定量指标实体</param>
        /// <returns></returns>
        public void SaveForm(string kpibh, BpeTA002Entity entity)
        {
            if (!string.IsNullOrEmpty(kpibh))
            {
                entity.Modify(kpibh);
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