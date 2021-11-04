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
    /// 综合评价等级报告
    /// </summary>
    public interface IBpeRA003Service
    {
        #region 获取数据
        /// <summary>
        /// 综合评价等级报告列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<BpeRA003Entity> GetList(Pagination pagination, string queryJson);
        /// <summary>
        /// 综合评价等级报告实体
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <returns></returns>
        BpeRA003Entity GetEntity(string keyvalue);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除综合评价等级报告
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        void RemoveForm(string keyvalue);
        /// <summary>
        /// 保存综合评价等级报告表单（新增、修改）
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <param name="entity">综合评价等级报告实体</param>
        /// <returns></returns>
        void SaveForm(string keyvalue, BpeRA003Entity entity);


        void UpdateSFYPFJ(List<BpeRA003Entity> entities);

        #endregion
    }
}