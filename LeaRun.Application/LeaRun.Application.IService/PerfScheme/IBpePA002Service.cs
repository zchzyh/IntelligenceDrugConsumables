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
    /// 绩效方案明细表
    /// </summary>
    public interface IBpePA002Service
    {
        /// <summary>
        /// 删除某个方案的所有明细
        /// </summary>
        /// <param name="fabh"></param>
        void DelDataByFABH(string fabh);
        /// <summary>
        /// 新增方案明细list
        /// </summary>
        /// <param name="entities"></param>
        void InsertList(List<BpePA002Entity> entities);
        /// <summary>
        /// 保存方案明细list
        /// </summary>
        /// <param name="entities"></param>
        void UpdateList(List<BpePA002Entity> entities);
        /// <summary>
        /// 获取某个方案明细
        /// </summary>
        /// <param name="fabh"></param>
        /// <returns></returns>
        List<BpePA002Entity> GetList(string fabh);

    }
}
