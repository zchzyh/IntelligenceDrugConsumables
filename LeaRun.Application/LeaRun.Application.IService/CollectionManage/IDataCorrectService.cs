using LeaRun.Application.Entity.CollectionManage.ViewModel;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.CollectionManage
{
    /// <summary>
    /// 数据修正法
    /// </summary>
    public interface IDataCorrectService
    {
        #region 获取数据

        /// <summary>
        /// 获取年度名称列表
        /// </summary>
        /// <returns>年度名称列表</returns>
        IEnumerable<ComboBoxModel> GetYearList();

        /// <summary>
        /// 获取所属类别名称列表
        /// </summary>
        /// <returns>所属类别名称列表</returns>
        IEnumerable<ComboBoxModel> GetTypeList();

        /// <summary>
        /// 获取系数修正法列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<CoefficientCorrectModel> GetCoefficientList(Pagination pagination, string queryJson);
        
        /// <summary>
        /// 获取归零修正法列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<ZeroingCorrectModel> GetZeroingList(Pagination pagination, string queryJson);
        
        /// <summary>
        /// 获取补录修正法列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<SupplementCorrectModel> GetSupplementList(Pagination pagination, string queryJson);

        #endregion

        #region 提交数据

        /// <summary>
        /// 更新数据修正
        /// </summary>
        /// <param name="type">数据修正类型</param>
        /// <param name="dataCorrectList">数据修正列表</param>
        void UpateDataCorrectList(string type, string dataCorrectList);

        #endregion

    }
}
