using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.IService.CollectionManage;
using LeaRun.Data.Repository;
using LeaRun.Util.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Service.CollectionManage
{
    /// <summary>
    /// 采集存储值表
    /// </summary>
    public class BpcSC004Service : RepositoryFactory<BpcSC004Entity>, IBpcSC004Service
    {
        #region 获取数据


        /// <summary>
        /// 获取采集存储值实体
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <returns></returns>
        public BpcSC004Entity GetEntity(string keyvalue)
        {
            return this.HQPASRepository().FindEntity(keyvalue);
        }


        /// <summary>
        /// 获取采集存储值实体
        /// </summary>
        /// <param name="rwbh">任务编号</param>
        /// <param name="lcode">列</param>
        /// <param name="hcode">行</param>
        /// <returns></returns>
        public BpcSC004Entity GetEntity(string rwbh, string lcode, string hcode)
        {
            var expression = LinqExtensions.True<BpcSC004Entity>();
            expression = expression.And(t => t.RWBH == rwbh && t.LCODE == lcode && t.HCODE == hcode);
            return this.HQPASRepository().FindEntity(expression);
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 保存采集存储值实体（新增、修改）
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <param name="entity">采集存储值实体</param>
        /// <returns></returns>
        public void SaveForm(string keyvalue, BpcSC004Entity entity)
        {
            if (!string.IsNullOrEmpty(keyvalue))
            {
                entity.Modify(keyvalue);
                this.HQPASRepository().Update(entity);
            }
            else
            {
                entity.Create();
                this.HQPASRepository().Insert(entity);
            }
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="entities"></param>
        public void InsertList(List<BpcSC004Entity> entities)
        {
            this.HQPASRepository().Insert(entities);
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="entities"></param>
        public void UpdateList(List<BpcSC004Entity> entities)
        {
            foreach (var entity in entities)
            {
                this.HQPASRepository().Update(entity);
            }
        }

        #endregion
    }
}
