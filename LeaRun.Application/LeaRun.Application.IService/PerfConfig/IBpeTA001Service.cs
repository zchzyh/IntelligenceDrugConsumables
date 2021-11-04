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
    /// 指标库基本信息
    /// </summary>
    public interface IBpeTA001Service
    {
        #region 获取数据
        /// <summary>
        /// 指标库基本信息列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<BpeTA001Entity> GetList(Pagination pagination, string queryJson);
        /// <summary>
        /// 指标库基本信息实体
        /// </summary>
        /// <param name="zbbh">指标编号</param>
        /// <param name="jxbm">绩效年度编码</param>
        /// <returns></returns>
        BpeTA001Entity GetEntity(string zbbh, string jxbm);
        /// <summary>
        /// 获取定量指标等级列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<BpeTA001Entity> GetLevelList(string queryJson);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除指标库基本信息
        /// </summary>
        /// <param name="zbbh">指标编号</param>
        /// <param name="jxbm">绩效年度编码</param>
        void RemoveForm(string zbbh, string jxbm);
        /// <summary>
        /// 保存指标库基本信息表单（新增、修改）
        /// </summary>
        /// <param name="zbbh">指标编号</param>
        /// <param name="jxbm">绩效年度编码</param>
        /// <param name="entity">指标库基本信息实体</param>
        /// <returns></returns>
        void SaveForm(string zbbh, string jxbm, BpeTA001Entity entity);
        #endregion
    }
}