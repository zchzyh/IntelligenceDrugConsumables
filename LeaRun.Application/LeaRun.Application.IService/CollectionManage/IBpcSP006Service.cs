using LeaRun.Application.Entity.CollectionManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.CollectionManage
{
    /// <summary>
    /// 采集日常监控表
    /// </summary>
    public interface IBpcSP006Service
    {
        #region 获取数据


        /// <summary>
        /// 获取采集日常监控实体
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <returns></returns>
        BpcSP006Entity GetEntity(string keyvalue);


        #endregion


        #region 提交数据

        /// <summary>
        /// 更新采集日常监控实体
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <param name="entity">采集日常监控实体</param>
        void UpdateEntity(string keyvalue, BpcSP006Entity entity);

        void AddRecords(List<BpcSP006Entity> entities);

        #endregion
    }
}
