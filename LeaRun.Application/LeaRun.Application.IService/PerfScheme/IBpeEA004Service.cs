using LeaRun.Application.Entity.PerfScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.PerfScheme
{
    /// <summary>
    /// 评价方法明细
    /// </summary>
    public interface IBpeEA004Service
    {
        #region 获取数据
        /// <summary>
        /// 评价方法明细实体
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <returns></returns>
        BpeEA004Entity GetEntity(string keyvalue);
        /// <summary>
        /// 评价方法明细实体
        /// </summary>
        /// <param name="jgfabh">部门方案编号</param>
        /// <returns></returns>
        BpeEA004Entity GetEntityByJGFABH(string jgfabh);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除评价方法明细
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        void RemoveForm(string keyvalue);
        /// <summary>
        /// 保存评价方法明细表单（新增、修改）
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <param name="entity">评价方法明细实体</param>
        /// <returns></returns>
        void SaveForm(string keyvalue, BpeEA004Entity entity);
        #endregion
    }
}