using LeaRun.Application.Entity.PerfConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.PerfConfig
{
    /// <summary>
    /// 定性指标库
    /// </summary>
    public interface IBpeTB001Service
    {
        #region 获取数据
        /// <summary>
        /// 定性指标库信息实体
        /// </summary>
        /// <param name="zbbh">指标编号</param>
        /// <param name="jxbm">绩效年度编码</param>
        /// <returns></returns>
        BpeTB001Entity GetEntity(string zbbh, string jxbm);
        /// <summary>
        /// 获取定量指标等级列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<BpeTB001Entity> GetLevelList(string queryJson);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除定性指标库信息
        /// </summary>
        /// <param name="zbbh">指标编号</param>
        /// <param name="jxbm">绩效年度编码</param>
        void RemoveForm(string zbbh, string jxbm);
        /// <summary>
        /// 保存定性指标库信息表单（新增、修改）
        /// </summary>
        /// <param name="zbbh">指标编号</param>
        /// <param name="jxbm">绩效年度编码</param>
        /// <param name="entity">定性指标库信息实体</param>
        /// <returns></returns>
        void SaveForm(string zbbh, string jxbm, BpeTB001Entity entity);
        #endregion
    }
}