using LeaRun.Application.Entity.PerfConfig;
using LeaRun.Application.Entity.PerfConfig.ViewModel;
using LeaRun.Application.IService.PerfConfig;
using LeaRun.Application.Service.PerfConfig;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Busines.PerfConfig
{
    /// <summary>
    /// 绩效年度配置
    /// </summary>
    public class YearSettingBLL
    {
        private IBpeSC001Service sc001Service = new BpeSC001Service();
        private IBpcSP007Service sp007Service = new BpcSP007Service();
        private IYearSettingService yearSettingService = new YearSettingService();
        private IAssessmentObjectService assessmentObjectService = new AssessmentObjectService();

        #region 获取数据

        /// <summary>
        /// 获取年度列表
        /// </summary>
        /// <returns>年度列表</returns>
        public IEnumerable<string> GetYears()
        {
            return sc001Service.GetYearList();
        }

        /// <summary>
        /// 获取年度编码列表
        /// </summary>
        /// <returns>年度列表</returns>
        public IEnumerable<BpeSC001Entity> GetYearBms()
        {
            return sc001Service.GetYearBmList();
        }

        /// <summary>
        /// 绩效年度配置列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<YearSettingModel> GetYearSettings(Pagination pagination, string queryJson)
        {
            return yearSettingService.GetList(pagination, queryJson);
        }

        /// <summary>
        /// 绩效年度配置实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BpeSC001Entity GetYearSettingEntity(string keyValue)
        {
            return sc001Service.GetEntity(keyValue);
        }

        /// <summary>
        /// 绩效对象配置列表
        /// </summary>
        /// <param name="jxbm">查询参数</param>
        /// <returns></returns>
        public IEnumerable<AssessmentObjectModel> GetDepartments(string jxbm)
        {
            return assessmentObjectService.GetDepartmentList(jxbm);
        }

        /// <summary>
        /// 科室编码列表
        /// </summary>
        /// <param name="jxbm">查询参数</param>
        /// <returns></returns>
        public IEnumerable<AssessmentObjectModel> GetDepartmentBms(string jxbm)
        {
            return assessmentObjectService.GetDepartmentBmList(jxbm);
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 新增绩效年度配置表单
        /// </summary>
        /// <param name="entity">绩效年度配置实体</param>
        /// <returns></returns>
        public void CreateYearSettingForm(BpeSC001Entity entity)
        {
            try
            {
                sc001Service.SaveForm(null, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 修改绩效年度配置表单
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">绩效年度配置实体</param>
        /// <returns></returns>
        public void ModifyYearSettingForm(string keyValue, BpeSC001Entity entity)
        {
            try
            {
                sc001Service.SaveForm(keyValue, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 删除考核对象配置
        /// </summary>
        /// <param name="keyValues">主键</param>
        public void RemoveAssessmentObjectForm(string[] keyValues)
        {
            try
            {
                sp007Service.RemoveForm(keyValues);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 新增考核对象配置表单
        /// </summary>
        /// <param name="entities">考核对象配置实体</param>
        /// <returns></returns>
        public void CreateAssessmentObjectsForm(List<BpcSP007Entity> entities)
        {
            try
            {
                sp007Service.SaveForm(null, entities);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}