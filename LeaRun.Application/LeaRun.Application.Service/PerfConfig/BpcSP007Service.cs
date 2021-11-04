using LeaRun.Application.Entity.PerfConfig;
using LeaRun.Application.IService.PerfConfig;
using LeaRun.Data.Repository;
using System.Collections.Generic;
using System.Linq;

namespace LeaRun.Application.Service.PerfConfig
{
    /// <summary>
    /// 考核对象管理
    /// </summary>
    public class BpcSP007Service : RepositoryFactory<BpcSP007Entity>, IBpcSP007Service
    {
        #region 获取数据
        /// <summary>
        /// 获取本年度被考核的科室
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public List<string> GetYearDeptCode(string year)
        {
            return HQPASRepository().IQueryable().Where(y => y.JXBM == year).Select(y => y.JGBM).Distinct().ToList();
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除考核对象管理信息
        /// </summary>
        /// <param name="keyValues">主键</param>
        public void RemoveForm(string[] keyValues)
        {
            this.HQPASRepository().Delete(keyValues);
        }
        /// <summary>
        /// 保存考核对象管理表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entities">考核对象管理实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, List<BpcSP007Entity> entities)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                foreach (var item in entities)
                {
                    item.Modify(keyValue);
                }
                this.HQPASRepository().Update(entities);
            }
            else
            {
                foreach (var item in entities)
                {
                    if (this.HQPASRepository().FindEntity(e => e.JXBM == item.JXBM && e.JGBM == item.JGBM) != null)
                    {
                        item.XH = null;
                    }
                    else
                    {
                        item.Create();
                    }
                }
                this.HQPASRepository().Insert(entities.Where(e => e.XH != null).ToList());
            }
        }
        #endregion
    }
}