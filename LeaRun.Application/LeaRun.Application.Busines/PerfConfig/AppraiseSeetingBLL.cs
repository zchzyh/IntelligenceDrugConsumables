using LeaRun.Application.Entity.PerfConfig;
using LeaRun.Application.Entity.PerfConfig.ViewModel;
using LeaRun.Application.IService.PerfConfig;
using LeaRun.Application.IService.SettingManage;
using LeaRun.Application.Service.PerfConfig;
using LeaRun.Application.Service.SettingManage;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Busines.PerfConfig
{
    /// <summary>
    /// 评价设置
    /// </summary>
    public class AppraiseSeetingBLL
    {
        private IAppraiseDataService appraiseDataService = new AppraiseDataService();
        private IBpeEA001Service bpeEA001Service = new BpeEA001Service();
        private IBpeEA002Service bpeEA002Service = new BpeEA002Service();
        private IBpeEA003Service bpeEA003Service = new BpeEA003Service();

        #region 评价方法
        #region 获取数据
        /// <summary>
        /// 获取评价方法数据
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<BpeEA003Entity> GetAppraisedataList(Pagination pagination, string queryJson)
        {
            return appraiseDataService.GetList(pagination, queryJson);
        }
        /// <summary>
        /// 获取评价方法编码列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<BpeEA003Entity> GetAppraisedataBmList(string queryJson)
        {
            return appraiseDataService.GetBmList(queryJson);
        }
        /// <summary>
        /// 获取评价方法实体
        /// </summary>
        /// <param name="pjffbh"></param>
        /// <returns></returns>
        public BpeEA003Entity GetAppraiseData(string pjffbh)
        {
            return bpeEA003Service.GetEntity(pjffbh);
        }
        #endregion 获取数据
        #region 提交数据
        /// <summary>
        /// 新增评价方法
        /// </summary>
        /// <param name="entity"></param>
        public void AddAppraiseData(BpeEA003Entity entity)
        {
            try
            {
                bpeEA003Service.SaveForm(null, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 修改评价方法
        /// </summary>
        /// <param name="pjffbh"></param>
        /// <param name="entity"></param>
        public void ModifyAppraiseData(string pjffbh, BpeEA003Entity entity)
        {
            try
            {
                bpeEA003Service.SaveForm(pjffbh, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 删除评价方法
        /// </summary>
        /// <param name="pjffbhe"></param>
        public void RemoveAppraiseData(string pjffbhe)
        {
            try
            {
                bpeEA003Service.RemoveForm(pjffbhe);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion 提交数据
        #endregion 评价方法

        #region 指标等级
        #region 获取数据
        /// <summary>
        /// 获取指标等级数据列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<BpeEA001Entity> GetPerfLeveldataList(Pagination pagination, string queryJson)
        {
            return appraiseDataService.GetPerfLevelDataList(pagination, queryJson);
        }
        /// <summary>
        /// 获取指标等级数据实体
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        public BpeEA001Entity GetPerfLevelEntity(string xh)
        {
            return bpeEA001Service.GetEntity(xh);
        }
        #endregion 获取数据

        #region 提交数据
        /// <summary>
        /// 新增指标等级
        /// </summary>
        /// <param name="entity"></param>
        public void AddPerfLevel(BpeEA001Entity entity)
        {
            try
            {
                bpeEA001Service.SaveForm(null, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 修改指标等级
        /// </summary>
        /// <param name="xh"></param>
        /// <param name="entity"></param>
        public void ModifyPerfLevel(string xh, BpeEA001Entity entity)
        {
            try
            {
                bpeEA001Service.SaveForm(xh, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 删除指标等级
        /// </summary>
        /// <param name="pjffbhe"></param>
        public void RemovePerfLevel(string xh)
        {
            try
            {
                bpeEA001Service.RemoveForm(xh);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion 提交数据

        #endregion 指标等级

        #region 综合等级
        #region 获取数据
        /// <summary>
        /// 获取综合等级数据列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<BpeEA002Entity> GetSynLeveldataList(Pagination pagination, string queryJson)
        {
            return appraiseDataService.GetSynLevelDataList(pagination, queryJson);
        }
        /// <summary>
        /// 获取综合等级数据实体
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        public BpeEA002Entity GetSynLevelEntity(string xh)
        {
            return bpeEA002Service.GetEntity(xh);
        }
        #endregion 获取数据
        #region 提交数据
        /// <summary>
        /// 新增综合等级
        /// </summary>
        /// <param name="entity"></param>
        public void AddSynLevel(BpeEA002Entity entity)
        {
            try
            {
                bpeEA002Service.SaveForm(null, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 修改综合等级
        /// </summary>
        /// <param name="xh"></param>
        /// <param name="entity"></param>
        public void ModifySynLevel(string xh, BpeEA002Entity entity)
        {
            try
            {
                bpeEA002Service.SaveForm(xh, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 删除综合等级
        /// </summary>
        /// <param name="pjffbhe"></param>
        public void RemoveSynLevel(string xh)
        {
            try
            {
                bpeEA002Service.RemoveForm(xh);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion 提交数据
        #endregion 综合等级
    }
}