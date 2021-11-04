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
    /// 绩效方案信息表
    /// </summary>
    public interface IBpePA001Service
    {
        /// <summary>
        /// 获取绩效方案实体
        /// </summary>
        /// <param name="fabh">方案编号</param>
        /// <returns></returns>
        BpePA001Entity GetEntity(string fabh);
        /// <summary>
        /// 新增/修改基础方案数据
        /// </summary>
        /// <param name="fabh"></param>
        /// <param name="bpepa001"></param>
        void SaveForm(string fabh, BpePA001Entity bpepa001);
        /// <summary>
        /// 删除基础方案数据
        /// </summary>
        /// <param name="fabh"></param>
        void RemoveForm(string fabh);
    }
}
