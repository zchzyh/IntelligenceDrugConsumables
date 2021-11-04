using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.IService.CollectionManage;
using LeaRun.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaRun.Util.Extension;

namespace LeaRun.Application.Service.CollectionManage
{
    /// <summary>
    /// 采集日常监控表
    /// </summary>
    public class BpcSP006Service : RepositoryFactory<BpcSP006Entity>, IBpcSP006Service
    {
        #region 获取数据

        /// <summary>
        /// 获取采集日常监控实体
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <returns></returns>
        public BpcSP006Entity GetEntity(string keyvalue)
        {
            return this.HQPASRepository().FindEntity(keyvalue);
        }


        #endregion

        #region 提交数据

        /// <summary>
        /// 更新采集日常监控实体
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <param name="entity">采集日常监控实体</param>
        public void UpdateEntity(string keyvalue, BpcSP006Entity entity)
        {
            if (!string.IsNullOrEmpty(keyvalue))
            {
                entity.Modify(keyvalue);
                this.HQPASRepository().Update(entity);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        public void AddRecords(List<BpcSP006Entity> entities)
        {
            IRepository db = new RepositoryFactory().HQPASRepository().BeginTrans();
            try
            {
                foreach (var e in entities)
                {
                    if(e.XH.IsEmpty())
                      e.Create();
                }

               var result = db.Insert(entities);

                db.Commit();
            }
            catch (Exception ex)
            {
                db.Rollback();
                throw;
            }
        }

        #endregion
    }
}
