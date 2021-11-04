using LeaRun.Application.Entity.PerfGoal;
using LeaRun.Application.Entity.PerfScheme;
using LeaRun.Application.IService.PerfGoal;
using LeaRun.Application.Service.PerfScheme;
using LeaRun.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Service.PerfGoal
{
    /// <summary>
    /// 单位方案信息
    /// </summary>
    public class BpePA003Service : RepositoryFactory<BpePA003Entity>, IBpePA003Service
    {
        #region 获取数据
        /// <summary>
        /// 单位方案信息实体
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <returns></returns>
        public BpePA003Entity GetEntity(string keyvalue)
        {
            return this.HQPASRepository().FindEntity(keyvalue);
        }
        /// <summary>
        /// 获取某个方案的所有使用科室/部门
        /// </summary>
        /// <param name="year"></param>
        /// <param name="fabh"></param>
        /// <returns></returns>
        public IEnumerable<BpePA003Entity> GetSchemeDepList(string year, string fabh)
        {
            return this.HQPASRepository().IQueryable().Where(t => t.FABH == fabh && t.JXBM == year).ToList();
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除单位方案信息
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        public void RemoveForm(string keyvalue)
        {
            this.HQPASRepository().Delete(keyvalue);
        }
        /// <summary>
        /// 保存单位方案信息表单（新增、修改）
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <param name="entity">数据项分类信息实体</param>
        /// <returns></returns>
        public void SaveForm(string keyvalue, BpePA003Entity entity)
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
        /// 保存科室的方案列表
        /// </summary>
        /// <param name="fabh"></param>
        /// <param name="jxbm"></param>
        /// <param name="jgfabh"></param>
        /// <param name="jgbms"></param>
        /// <param name="entities"></param>
        public string[] SaveSchemeDepList(string fabh, string jxbm, string jgfabh, string jgbms, List<BpePA003Entity> entities)
        {
            List<BpePA003Entity> deleteEntities = null;
            List<BpePA003Entity> updateEntities = new List<BpePA003Entity>();
            List<BpePA003Entity> insertEntities = new List<BpePA003Entity>();
            if (string.IsNullOrEmpty(jgfabh))
            {//批量绑定时删除不再绑定当前基础方案的科室方案，更新已绑定的科室方案
                deleteEntities = HQPASRepository().IQueryable().Where(t => t.JXBM == jxbm && t.FABH == fabh && !jgbms.Contains(t.JGBM)).ToList();
                updateEntities.AddRange(HQPASRepository().IQueryable().Where(t => t.JXBM == jxbm && jgbms.Contains(t.JGBM)).ToList());
            }
            else
            {//单个调整，因为科室方案编码已修改，故直接删除该科室本年度的科室方案
                deleteEntities = HQPASRepository().IQueryable().Where(t => t.JXBM == jxbm && jgbms == t.JGBM).ToList();
            }

            IRepository db = new RepositoryFactory().HQPASRepository().BeginTrans();
            try
            {
                if (deleteEntities != null)
                {
                    int result = db.Delete(deleteEntities);
                }
                foreach (var e in entities)
                {
                    var insertEnt = updateEntities.Where(b3 => b3.JGBM == e.JGBM && b3.JXBM == e.JXBM).FirstOrDefault();
                    if (insertEnt == null)
                    {
                        e.Create();
                        insertEntities.Add(e);
                    }
                    else
                    {//需要更新的不新增
                        e.JGFABH = insertEnt.JGFABH;
                    }
                    e.JGFABH = string.IsNullOrEmpty(jgfabh) ? e.JGFABH : jgfabh;
                }
                db.Insert(insertEntities);
                var jgfamc = entities[0].JGFAMC;
                foreach (var item in updateEntities)
                {
                    item.Modify(item.JGFABH);
                    item.STATUS = "0";//修改了指标即是未审核
                    item.FABH = fabh;
                    item.JGFAMC = jgfamc;
                    db.Update(item);
                }
                db.Commit();
                //更新或者删除的科室方案均要删除科室指标再新增
                deleteEntities.AddRange(updateEntities);
                return deleteEntities.Select(d => d.JGFABH).ToArray();
            }
            catch(Exception)
            {
                db.Rollback();
                throw;
            }
        }
        #endregion
    }
}