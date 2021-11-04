using LeaRun.Application.Entity.PerfConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.PerfConfig
{
    public interface IBpeEA002Service
    {
        #region 获取数据

        /// <summary>
        /// 获取综合等级实体
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        BpeEA002Entity GetEntity(string xh);
        /// <summary>
        /// 保存综合等级数据
        /// </summary>
        /// <param name="xh"></param>
        /// <param name="entity"></param>
        void SaveForm(string xh, BpeEA002Entity entity);
        /// <summary>
        /// 删除综合等级
        /// </summary>
        /// <param name="xh"></param>
        void RemoveForm(string xh);

        #endregion 获取数据
    }
}
