using LeaRun.Application.Entity.PerfReport;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.PerfReport
{
    /// <summary>
    /// 定性等级报告
    /// </summary>
    public interface IBpeRA002Service
    {
        #region 获取数据
        /// <summary>
        /// 定性等级报告列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<BpeRA002Entity> GetList(Pagination pagination, string queryJson);
        /// <summary>
        /// 定性等级报告实体
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <returns></returns>
        BpeRA002Entity GetEntity(string keyvalue);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除定性等级报告
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        void RemoveForm(string keyvalue);
        /// <summary>
        /// 保存定性等级报告表单（新增、修改）
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <param name="entity">定性等级报告实体</param>
        /// <returns></returns>
        void SaveForm(string keyvalue, BpeRA002Entity entity);
        #endregion
    }
}
