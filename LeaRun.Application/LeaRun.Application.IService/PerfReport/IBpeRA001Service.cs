using LeaRun.Application.Entity.PerfReport;
using LeaRun.Application.Entity.PerfReport.ViewModel;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.PerfReport
{
    /// <summary>
    /// 定量指标等级报告
    /// </summary>
    public interface IBpeRA001Service
    {
        #region 获取数据
        /// <summary>
        /// 定量指标等级报告列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<BpeRA001Entity> GetList(Pagination pagination, string queryJson);

        /// <summary>
        /// 下一年度改进报告
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<BpeRA001Entity> GetList(string queryJson);

        IEnumerable<SchemeWeightModel> GetSchemeWeighList(Pagination pagination, string queryJson);
        /// <summary>
        /// 定量指标等级报告实体
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <returns></returns>
        BpeRA001Entity GetEntity(string keyvalue);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除定量指标等级报告
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        void RemoveForm(string keyvalue);
        /// <summary>
        /// 保存定量指标等级报告表单（新增、修改）
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <param name="entity">定量指标等级报告实体</param>
        /// <returns></returns>
        void SaveForm(string keyvalue, BpeRA001Entity entity);
        #endregion
    }
}