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
    /// 分析器基本信息表
    /// </summary>
    public interface IBpcSM006Service
    {
        #region 获取数据
        /// <summary>
        /// 分析器基本信息列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<BpcSM006Entity> GetList(Pagination pagination, string queryJson);
        /// <summary>
        /// 分析器基本信息实体
        /// </summary>
        /// <param name="fxqbm">分析器编码</param>
        /// <returns></returns>
        BpcSM006Entity GetEntity(string fxqbm);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除分析器基本信息
        /// </summary>
        /// <param name="fxqbm">分析器编码</param>
        void RemoveForm(string fxqbm);
        /// <summary>
        /// 保存分析器基本信息表单（新增、修改）
        /// </summary>
        /// <param name="fxqbm">分析器编码</param>
        /// <param name="entity">分析器基本信息实体</param>
        /// <returns></returns>
        void SaveForm(string fxqbm, BpcSM006Entity entity);
        #endregion
    }
}