using LeaRun.Application.Entity.PerfConfig;
using LeaRun.Application.IService.PerfConfig;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Service.PerfConfig
{
    /// <summary>
    /// 分析器基本信息表
    /// </summary>
    public class BpcSM006Service : RepositoryFactory<BpcSM006Entity>, IBpcSM006Service
    {
        #region 获取数据

        /// <summary>
        /// 分析器基本信息列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<BpcSM006Entity> GetList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<BpcSM006Entity>();
            var queryParam = queryJson.ToJObject();
            //分析器类型
            if (!queryParam["type"].IsEmpty())
            {
                string keyword = queryParam["type"].ToString();

                expression = expression.And(t => t.FXQLX == keyword);
            }
            //查询条件
            if (!queryParam["keyword"].IsEmpty())
            {
                string keyword = queryParam["keyword"].ToString();

                expression = expression.And(t => t.FXQBM.Contains(keyword)
                                                 || t.FXQMC.Contains(keyword));
            }
            expression = expression.And(t => t.STATUS == "1");
            return this.HQPASRepository().FindList(expression, pagination);
        }

        /// <summary>
        /// 分析器基本信息实体
        /// </summary>
        /// <param name="fxqbm">分析器编码</param>
        /// <returns></returns>
        public BpcSM006Entity GetEntity(string fxqbm)
        {
            return this.HQPASRepository().FindEntity(fxqbm);
        }

        #endregion

        #region 提交数据
        /// <summary>
        /// 删除分析器基本信息
        /// </summary>
        /// <param name="fxqbm">分析器编码</param>
        public void RemoveForm(string fxqbm)
        {
            this.HQPASRepository().Delete(fxqbm);
        }
        /// <summary>
        /// 保存分析器基本信息表单（新增、修改）
        /// </summary>
        /// <param name="fxqbm">分析器编码</param>
        /// <param name="entity">分析器基本信息实体</param>
        /// <returns></returns>
        public void SaveForm(string fxqbm, BpcSM006Entity entity)
        {
            if (!string.IsNullOrEmpty(fxqbm))
            {
                entity.Modify(fxqbm);
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