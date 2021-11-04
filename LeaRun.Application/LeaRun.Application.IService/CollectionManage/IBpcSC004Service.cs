using LeaRun.Application.Entity.CollectionManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.CollectionManage
{
    /// <summary>
    /// 采集存储值表
    /// </summary>
    public interface IBpcSC004Service
    {
        #region 获取数据

        /// <summary>
        /// 获取采集存储值实体
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <returns></returns>
        BpcSC004Entity GetEntity(string keyvalue);

        /// <summary>
        /// 获取采集存储值实体
        /// </summary>
        /// <param name="rwbh">任务编号</param>
        /// <param name="lcode">列</param>
        /// <param name="hcode">行</param>
        /// <returns></returns>
        BpcSC004Entity GetEntity(string rwbh, string lcode, string hcode);

        #endregion

        #region 提交数据

        /// <summary>
        /// 保存采集存储值实体（新增、修改）
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <param name="entity">采集存储值实体</param>
        /// <returns></returns>
        void SaveForm(string keyvalue, BpcSC004Entity entity);

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="entities"></param>
        void InsertList(List<BpcSC004Entity> entities);

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="entities"></param>
        void UpdateList(List<BpcSC004Entity> entities);

        #endregion
    }
}
