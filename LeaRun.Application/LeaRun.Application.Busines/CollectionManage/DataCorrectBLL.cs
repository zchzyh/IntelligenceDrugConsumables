using LeaRun.Application.Entity.CollectionManage.ViewModel;
using LeaRun.Application.IService.CollectionManage;
using LeaRun.Application.Service.CollectionManage;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Busines.CollectionManage
{
    /// <summary>
    /// 数据修正法
    /// </summary>
    public class DataCorrectBLL
    {
        private IDataCorrectService dataCorrectService = new DataCorrectService();

        #region 获取数据


        /// <summary>
        /// 获取年度名称列表
        /// </summary>
        /// <returns>年度名称列表</returns>
        public IEnumerable<ComboBoxModel> GetYears()
        {
            return dataCorrectService.GetYearList();
        }

        /// <summary>
        /// 获取所属类别名称列表
        /// </summary>
        /// <returns>所属类别名称列表</returns>
        public IEnumerable<ComboBoxModel> GetTypes()
        {
            return dataCorrectService.GetTypeList();
        }

        /// <summary>
        /// 获取系数修正法列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<CoefficientCorrectModel> GetCoefficientCorrect(Pagination pagination, string queryJson)
        {
            return dataCorrectService.GetCoefficientList(pagination, queryJson);
        }

        /// <summary>
        /// 获取归零修正法列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<ZeroingCorrectModel> GetZeroingCorrect(Pagination pagination, string queryJson)
        {
            return dataCorrectService.GetZeroingList(pagination, queryJson);
        }

        /// <summary>
        /// 获取补录修正法列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<SupplementCorrectModel> GetSupplementCorrect(Pagination pagination, string queryJson)
        {
            return dataCorrectService.GetSupplementList(pagination, queryJson);
        }

        #endregion

        #region 提交数据



        /// <summary>
        /// 更新数据修正
        /// </summary>
        /// <param name="type">数据修正类型</param>
        /// <param name="dataCorrectList">数据修正列表</param>
        public void UpateDataCorrect(string type, string dataCorrectList)
        {
            try
            {
                dataCorrectService.UpateDataCorrectList(type, dataCorrectList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

    }
}
