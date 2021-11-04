using LeaRun.Application.Entity.PerfReport;
using LeaRun.Application.Entity.PerfReport.ViewModel;
using LeaRun.Application.IService.PerfReport;
using LeaRun.Application.Service.PerfReport;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Busines.PerfReport
{
    /// <summary>
    /// 单位报告内容
    /// </summary>
    public class DeptPerfReportBLL
    {
        private IBpeRA001Service bpeRA001Service = new BpeRA001Service();
        private IBpeRA002Service bpeRA002Service = new BpeRA002Service();
        private IBpeRA003Service bpeRA003Service = new BpeRA003Service();
        private IBpeRA004Service bpeRA004Service = new BpeRA004Service();
        private IBpeRA005Service bpeRA005Service = new BpeRA005Service();

        #region 获取数据

        /// <summary>
        /// 定量指标等级报告列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<BpeRA001Entity> GetQuantitativeReportList(Pagination pagination, string queryJson)
        {
            return bpeRA001Service.GetList(pagination, queryJson);
        }

        /// <summary>
        /// 定量指标等级报告实体
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <returns></returns>
        public BpeRA001Entity GetQuantitativeReportEntity(string keyvalue)
        {
            return bpeRA001Service.GetEntity(keyvalue);
        }

        public IEnumerable<SchemeWeightModel> GetSchemeWeighList(Pagination pagination, string queryJson)
        {
            return bpeRA001Service.GetSchemeWeighList(pagination, queryJson);
        }
        /// <summary>
        /// 定性指标等级报告列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<BpeRA002Entity> GetQualitativeReportList(Pagination pagination, string queryJson)
        {
            return bpeRA002Service.GetList(pagination, queryJson);
        }

        /// <summary>
        /// 定性指标等级报告实体
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <returns></returns>
        public BpeRA002Entity GetQualitativeReportEntity(string keyvalue)
        {
            return bpeRA002Service.GetEntity(keyvalue);
        }

        /// <summary>
        /// 综合评价等级报告列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<BpeRA003Entity> GetComprehensiveReportList(Pagination pagination, string queryJson)
        {
            return bpeRA003Service.GetList(pagination, queryJson);
        }

        /// <summary>
        /// 综合评价等级报告实体
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <returns></returns>
        public BpeRA003Entity GetComprehensiveReportEntity(string keyvalue)
        {
            return bpeRA003Service.GetEntity(keyvalue);
        }

        /// <summary>
        /// 下一年度改进报告列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<BpeRA001Entity> GetNextYearReportList(string queryJson)
        {
            return bpeRA001Service.GetList(queryJson);
        }

        /// <summary>
        /// 下一年度改进报告实体
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <returns></returns>
        public BpeRA004Entity GetNextYearReportEntity(string keyvalue)
        {
            return bpeRA004Service.GetEntity(keyvalue);
        }

        /// <summary>
        /// 最终评定报告列表
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <returns></returns>
        public IEnumerable<FinalAssessmentModel> GetFinalAssessmentRep(Pagination pagination, string queryJson)
        {
            try
            {
                FinalAssessmentRepService finalAssessmentRepService = new FinalAssessmentRepService();
                return finalAssessmentRepService.GetList(pagination, queryJson);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 最终评定报告实体
        /// </summary>
        /// <param name="year">年度</param>
        /// <param name="serial_num">序号</param>
        /// <returns></returns>
        public BpeRA005Entity GetFinalAssessmentRepEntity(string serial_num)
        {
            try
            {
                return bpeRA005Service.GetEntity( serial_num);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除最终评定报告
        /// </summary>
        /// <param name="year_code">年度编码</param>
        /// <param name="serial_num">序号</param>
        public void RemoveFinalAssessmentForm(string year_code,string serial_num)
        {
            try
            {
                bpeRA005Service.RemoveForm(year_code, serial_num);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 创建最终评定报告表单（新增、修改）
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <param name="entity">最终评定报告实体</param>
        /// <returns></returns>
        public void CreateFinalAssessmentForm(BpeRA005Entity entity)
        {
            try
           {
                bpeRA005Service.SaveForm(null, entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 更改最终评定报告表单（新增、修改）
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <param name="entity">最终评定报告实体</param>
        /// <returns></returns>
        public void ModifyFinalAssessmentForm(string keyvalue ,BpeRA005Entity entity)
        {
            try
            {
                bpeRA005Service.SaveForm(entity.serial_num, entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        public void UpdateSFYPFJ(List<BpeRA003Entity> entities)
        {
            bpeRA003Service.UpdateSFYPFJ(entities);
        }
        
    }
}