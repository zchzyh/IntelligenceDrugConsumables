using LeaRun.Application.Entity.SettingManage;
using LeaRun.Application.IService.SettingManage;
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

namespace LeaRun.Application.Service.SettingManage
{
    /// <summary>
    /// 行政区域
    /// </summary>
    public class PMR025UnitService : RepositoryFactory<PMR025UnitEntity>, IPMR025UnitService
    {
        #region 获取数据
        /// <summary>
        /// 行政区域列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<PMR025UnitEntity> GetList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<PMR025UnitEntity>();
            var queryParam = queryJson.ToJObject();
            //查询条件
            if (!queryParam["keyword"].IsEmpty())
            {
                string keyword = queryParam["keyword"].ToString();

                expression = expression.And(t => t.UNITID.Contains(keyword)
                    || t.NAME.Contains(keyword)
                    || t.PY.Contains(keyword)
                    || t.WB.Contains(keyword));
            }
            return this.HQPASRepository().FindList(expression, pagination);
        }

        /// <summary>
        /// 获取所有行政区域
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PMR025UnitEntity> GetList()
        {
            //var expression = LinqExtensions.True<PMR025UnitEntity>();            
            //expression = expression.And(t => t.STATUS == "1");
            //return this.HQPASRepository().IQueryable(expression);
            return this.HQPASRepository().IQueryable();
        }

        /// <summary>
        /// 行政区域实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public PMR025UnitEntity GetEntity(string keyValue)
        {
            return this.HQPASRepository().FindEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除行政区域
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            this.HQPASRepository().Delete(keyValue);
        }
        /// <summary>
        /// 保存行政区域表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="pmr025UnitEntity">基础数据分类实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, PMR025UnitEntity pmr025UnitEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                pmr025UnitEntity.Modify(keyValue);
                this.HQPASRepository().Update(pmr025UnitEntity);
            }
            else
            {
                pmr025UnitEntity.Create();
                this.HQPASRepository().Insert(pmr025UnitEntity);
            }
        }
        #endregion
    }
}