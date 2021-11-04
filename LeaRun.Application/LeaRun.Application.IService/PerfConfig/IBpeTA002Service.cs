using LeaRun.Application.Entity.PerfConfig;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.PerfConfig
{
    /// <summary>
    /// 绩效定量指标设置
    /// </summary>
    public interface IBpeTA002Service
    {
        #region 获取数据
        /// <summary>
        /// 绩效定量指标设置实体
        /// </summary>
        /// <param name="kpibh">KPI编号</param>
        /// <returns></returns>
        BpeTA002Entity GetEntity(string kpibh);
        /// <summary>
        /// 判断是否已有该定量指标
        /// </summary>
        /// <param name="zbbh">指标编号</param>
        /// <param name="jxbm">绩效年度编码</param>
        /// <returns></returns>
        bool IsEntityExist(string zbbh, string jxbm);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除绩效定量指标设置
        /// </summary>
        /// <param name="kpibh">KPI编号</param>
        void RemoveForm(string kpibh);
        /// <summary>
        /// 保存绩效定量指标设置表单（新增、修改）
        /// </summary>
        /// <param name="kpibh">KPI编号</param>
        /// <param name="entity">绩效定量指标设置实体</param>
        /// <returns></returns>
        void SaveForm(string kpibh, BpeTA002Entity entity);
        #endregion
    }
}