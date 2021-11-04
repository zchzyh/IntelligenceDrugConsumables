using LeaRun.Application.Entity.SettingManage;
using LeaRun.Application.IService.SettingManage;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Service.SettingManage
{
    /// <summary>
    /// 数据项分类信息
    /// </summary>
    public class BpcSM002Service : RepositoryFactory<BpcSM002Entity>, IBpcSM002Service
    {
        #region 获取数据
        /// <summary>
        /// 数据项分类信息列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<BpcSM002Entity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<BpcSM002Entity>();
            var queryParam = queryJson.ToJObject();
            //分类级别
            if (!queryParam["grade"].IsEmpty())
            {
                string keyword = queryParam["grade"].ToString();

                expression = expression.And(t => t.GRADE == keyword);
            }
            //上级分类ID
            if (!queryParam["parent"].IsEmpty())
            {
                string keyword = queryParam["parent"].ToString();

                expression = expression.And(t => t.PARENT == keyword);
            }
            expression = expression.And(t => t.STATUS == "1");
            return this.HQPASRepository().IQueryable(expression);
        }
        /// <summary>
        /// 数据项分类信息列表
        /// </summary>
        /// <param name="pagination">分页数据</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<BpcSM002Entity> GetList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<BpcSM002Entity>();
            var queryParam = queryJson.ToJObject();
            //分类级别
            if (!queryParam["grade"].IsEmpty())
            {
                string keyword = queryParam["grade"].ToString();

                expression = expression.And(t => t.GRADE == keyword);
            }
            //上级分类ID
            if (!queryParam["parent"].IsEmpty())
            {
                string keyword = queryParam["parent"].ToString();

                expression = expression.And(t => t.PARENT == keyword);
            }
            //查询条件
            if (!queryParam["keyword"].IsEmpty())
            {
                string keyword = queryParam["keyword"].ToString();

                expression = expression.And(t => t.TYPEID.Contains(keyword)
                                                 || t.NAME.Contains(keyword));
            }
            expression = expression.And(t => t.STATUS == "1");
            return this.HQPASRepository().FindList(expression, pagination);
        }
        /// <summary>
        /// 数据项分类信息实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BpcSM002Entity GetEntity(string keyValue)
        {
            return this.HQPASRepository().FindEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据项分类信息
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            this.HQPASRepository().Delete(keyValue);
        }
        /// <summary>
        /// 保存数据项分类信息表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">数据项分类信息实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, BpcSM002Entity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.HQPASRepository().Update(entity);
            }
            else
            {
                entity.Create();
                this.HQPASRepository().Insert(entity);
            }
        }
        #endregion
    }
}