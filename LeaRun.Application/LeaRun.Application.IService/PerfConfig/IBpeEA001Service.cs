using LeaRun.Application.Entity.PerfConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.PerfConfig
{
    public interface IBpeEA001Service
    {
        #region 获取数据

        /// <summary>
        /// 获取指标等级实体
        /// </summary>
        /// <param name="pjffbh"></param>
        /// <returns></returns>
        BpeEA001Entity GetEntity(string pjffbh);
        /// <summary>
        /// 保存指标等级数据
        /// </summary>
        /// <param name="pjffbh"></param>
        /// <param name="entity"></param>
        void SaveForm(string pjffbh, BpeEA001Entity entity);
        /// <summary>
        /// 删除指标等级
        /// </summary>
        /// <param name="pjffbh"></param>
        void RemoveForm(string pjffbh);

        #endregion 获取数据

    }
}
