using LeaRun.Application.Entity.SettingManage;
using LeaRun.Application.IService.SettingManage;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Service.SettingManage
{
    /// <summary>
    /// 主管机构信息
    /// </summary>
    public class PMR001MorService : RepositoryFactory<PMR001MorEntity>, IPMR001MorService
    {
        #region 获取数据
        /// <summary>
        /// 主管机构信息列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<PMR001MorEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<PMR001MorEntity>();
            var queryParam = queryJson.ToJObject();
            //查询条件
            if (!queryParam["keyword"].IsEmpty())
            {
                string keyword = queryParam["keyword"].ToString();

                expression = expression.And(t => t.ORGNAME.Contains(keyword));
            }
            return this.HQPASRepository().IQueryable(expression);
        }
        /// <summary>
        /// 主管机构信息实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public PMR001MorEntity GetEntity(string keyValue)
        {
            return this.HQPASRepository().FindEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除主管机构信息
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            this.HQPASRepository().Delete(keyValue);
        }
        /// <summary>
        /// 保存主管机构信息表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">主管机构信息实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, PMR001MorEntity entity)
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