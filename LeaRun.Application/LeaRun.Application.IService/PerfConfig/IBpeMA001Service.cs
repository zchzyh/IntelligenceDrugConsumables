using LeaRun.Application.Entity.PerfConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.PerfConfig
{
    /// <summary>
    /// 元数据库基本表
    /// </summary>
    public interface IBpeMA001Service
    {
        #region 获取数据
        /// <summary>
        /// 元数据库基本表实体
        /// </summary>
        /// <param name="jxbm">绩效年度编码</param>
        /// <param name="metaCode">元数据编码</param>
        /// <returns></returns>
        BpeMA001Entity GetEntity(string jxbm, string metaCode);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除元数据库基本表信息
        /// </summary>
        /// <param name="jxbm">绩效年度编码</param>
        /// <param name="metaCode">元数据编码</param>
        void RemoveForm(string jxbm, string metaCode);
        /// <summary>
        /// 保存元数据库基本表表单（新增、修改）
        /// </summary>
        /// <param name="jxbm">绩效年度编码</param>
        /// <param name="metaCode">元数据编码</param>
        /// <param name="entity">数据项分类信息实体</param>
        /// <returns></returns>
        void SaveForm(string jxbm, string metaCode, BpeMA001Entity entity);
        #endregion
    }
}