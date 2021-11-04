using LeaRun.Application.Entity.PerfConfig.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.PerfConfig
{
    /// <summary>
    /// 考核对象
    /// </summary>
    public interface IAssessmentObjectService
    {
        /// <summary>
        /// 获取考核对象列表
        /// </summary>
        /// <param name="queryJson">年度绩效编码</param>
        /// <returns>返回列表</returns>
        IEnumerable<AssessmentObjectModel> GetDepartmentList(string jxbm);
        /// <summary>
        /// 科室编码列表
        /// </summary>
        /// <param name="queryJson">年度绩效编码</param>
        /// <returns>返回列表</returns>
        IEnumerable<AssessmentObjectModel> GetDepartmentBmList(string jxbm);
    }
}