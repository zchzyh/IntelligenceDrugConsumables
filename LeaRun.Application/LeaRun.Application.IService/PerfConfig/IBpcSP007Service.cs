using LeaRun.Application.Entity.PerfConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.PerfConfig
{
    /// <summary>
    /// 考核对象管理
    /// </summary>
    public interface IBpcSP007Service
    {
        List<string> GetYearDeptCode(string year);
        #region 提交数据
        /// <summary>
        /// 删除考核对象管理信息
        /// </summary>
        /// <param name="keyValues">主键</param>
        void RemoveForm(string[] keyValues);
        /// <summary>
        /// 保存考核对象管理表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entities">考核对象管理实体</param>
        /// <returns></returns>
        void SaveForm(string keyValue, List<BpcSP007Entity> entities);
        #endregion
    }
}