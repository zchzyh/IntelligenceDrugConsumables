using LeaRun.Application.Code;
using LeaRun.Application.Entity.PerfScheme;
using LeaRun.Application.Entity.PerfGoal;
using LeaRun.Application.IService.PerfScheme;
using LeaRun.Application.IService.PerfGoal;
using LeaRun.Data;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Service.PerfScheme
{
    /// <summary>
    /// 绩效方案信息表
    /// </summary>
    public class BpePA001Service : RepositoryFactory<BpePA001Entity>, IBpePA001Service
    {
        /// <summary>
        /// 获取绩效方案信息实体
        /// </summary>
        /// <param name="fabh"></param>
        /// <returns></returns>
        public BpePA001Entity GetEntity(string fabh)
        {
            return this.HQPASRepository().FindEntity(e => e.FABH == fabh);
        }
        /// <summary>
        /// 新增/修改基础方案数据
        /// </summary>
        /// <param name="fabh"></param>
        /// <param name="bpepa001"></param>
        public void SaveForm(string fabh,BpePA001Entity bpepa001)
        {
            var meta = GetEntity(bpepa001.FABH);
            if(meta == null)
            {
                bpepa001.Create();
                this.HQPASRepository().Insert(bpepa001);
            }
            else
            {
                bpepa001.Modify(bpepa001.FABH.ToString());
                this.HQPASRepository().Update(bpepa001);
            }
        }
        /// <summary>
        /// 删除基础方案数据
        /// </summary>
        /// <param name="fabh"></param>
        public void RemoveForm(string fabh)
        {
            this.HQPASRepository().Delete(e => e.FABH == fabh);
        }
    }
}
