using LeaRun.Application.Entity.PerfConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.PerfConfig
{
    public interface IBpeEA003Service
    {
        #region 获取数据

        /// <summary>
        /// 获取评价方法实体
        /// </summary>
        /// <param name="xh"></param>
        /// <returns></returns>
        BpeEA003Entity GetEntity(string xh);
        /// <summary>
        /// 保存评价方法数据
        /// </summary>
        /// <param name="xh"></param>
        /// <param name="entity"></param>
        void SaveForm(string xh, BpeEA003Entity entity);
        /// <summary>
        /// 删除评价方法
        /// </summary>
        /// <param name="xh"></param>
        void RemoveForm(string xh);
        #endregion 获取数据

    }
}
