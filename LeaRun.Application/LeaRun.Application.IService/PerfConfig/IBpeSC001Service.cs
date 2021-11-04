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
    /// 年度绩效配置
    /// </summary>
    public interface IBpeSC001Service
    {
        #region 获取数据
        /// <summary>
        /// 获取年度名称列表
        /// </summary>
        /// <returns>年度名称列表</returns>
        IEnumerable<string> GetYearList();
        /// <summary>
        /// 获取绩效年度编码列表
        /// </summary>
        /// <returns>绩效年度编码列表</returns>
        IEnumerable<BpeSC001Entity> GetYearBmList();
        /// <summary>
        /// 年度绩效配置实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        BpeSC001Entity GetEntity(string keyValue);
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存年度绩效配置表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">年度绩效配置实体</param>
        /// <returns></returns>
        void SaveForm(string keyValue, BpeSC001Entity entity);
        #endregion
    }
}