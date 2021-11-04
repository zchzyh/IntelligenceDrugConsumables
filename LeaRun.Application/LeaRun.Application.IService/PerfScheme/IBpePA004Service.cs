using LeaRun.Application.Entity.PerfScheme;
using LeaRun.Application.Entity.PerfGoal;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.PerfScheme
{
    /// <summary>
    /// 科室绩效明细表
    /// </summary>
    public interface IBpePA004Service
    {
        /// <summary>
        /// 删除某个方案的所有明细
        /// </summary>
        /// <param name="jgfabh"></param>
        void DelDataByJGFABH(string jgfabh);
        /// <summary>
        /// 新增方案明细list
        /// </summary>
        /// <param name="entities"></param>
        void InsertList(List<BpePA004Entity> entities);
        /// <summary>
        /// 保存方案明细list
        /// </summary>
        /// <param name="entities"></param>
        void UpdateList(List<BpePA004Entity> entities);
        /// <summary>
        /// 获取某个方案明细
        /// </summary>
        /// <param name="fabh"></param>
        /// <returns></returns>
        List<BpePA004Entity> GetList(string jgfabh);
        void SaveSchemeDepDetails(List<BpePA004Entity> kpis, string[] delJgfabh);


    }
}
