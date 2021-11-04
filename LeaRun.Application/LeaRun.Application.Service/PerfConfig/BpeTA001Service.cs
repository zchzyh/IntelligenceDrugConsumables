using LeaRun.Application.Entity.PerfConfig;
using LeaRun.Application.IService.PerfConfig;
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

namespace LeaRun.Application.Service.PerfConfig
{
    /// <summary>
    /// 指标库基本信息
    /// </summary>
    public class BpeTA001Service : RepositoryFactory<BpeTA001Entity>, IBpeTA001Service
    {
        #region 获取数据

        /// <summary>
        /// 指标库基本信息列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<BpeTA001Entity> GetList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<BpeTA001Entity>();
            var queryParam = queryJson.ToJObject();
            //绩效年度编码
            if (!queryParam["jxbm"].IsEmpty())
            {
                string keyword = queryParam["jxbm"].ToString();

                expression = expression.And(t => t.JXBM == keyword);
            }
            //指标等级
            if (!queryParam["level"].IsEmpty())
            {
                string keyword = queryParam["level"].ToString();

                expression = expression.And(t => t.ZBJB == keyword);
            }
            return this.HQPASRepository().FindList(expression, pagination);
        }

        /// <summary>
        /// 指标库基本信息实体
        /// </summary>
        /// <param name="zbbh">指标编号</param>
        /// <param name="jxbm">绩效年度编码</param>
        /// <returns></returns>
        public BpeTA001Entity GetEntity(string zbbh, string jxbm)
        {
            return this.HQPASRepository().FindEntity(e => e.ZBBH == zbbh && e.JXBM == jxbm);
        }

        /// <summary>
        /// 获取定量指标设置等级列表
        /// </summary>
        /// <returns>定量指标设置等级列表</returns>
        public IEnumerable<BpeTA001Entity> GetLevelList(string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT [JXBM]
                          	      ,[ZBBH]
                          	      ,[ZBMC]
                          	      ,[FJZB]
                          	      ,[ZBJB]
                            FROM [HQPAS].[BPMS].[BPE_TA001]
                            WHERE [STATUS] = '1'");
            //绩效年度编码
            if (!queryParam["jxbm"].IsEmpty())
            {
                strSql.Append(" AND [JXBM] = @JXBM ");
                parameter.Add(DbParameters.CreateDbParameter("@JXBM", queryParam["jxbm"].ToString()));
            }
            //等级
            if (!queryParam["level"].IsEmpty())
            {
                strSql.Append(" AND [ZBJB] = @ZBJB ");
                parameter.Add(DbParameters.CreateDbParameter("@ZBJB", queryParam["level"].ToString()));
            }
            //父级指标
            if (!queryParam["fjzb"].IsEmpty())
            {
                strSql.Append(" AND [FJZB] = @FJZB ");
                parameter.Add(DbParameters.CreateDbParameter("@FJZB", queryParam["fjzb"].ToString()));
            }
            return this.HQPASRepository().FindList(strSql.ToString(), parameter.ToArray());
        }

        #endregion

        #region 提交数据
        /// <summary>
        /// 删除指标库基本信息
        /// </summary>
        /// <param name="zbbh">指标编号</param>
        /// <param name="jxbm">绩效年度编码</param>
        public void RemoveForm(string zbbh, string jxbm)
        {
            this.HQPASRepository().Delete(t => t.ZBBH == zbbh && t.JXBM == jxbm);
        }
        /// <summary>
        /// 保存指标库基本信息表单（新增、修改）
        /// </summary>
        /// <param name="zbbh">指标编号</param>
        /// <param name="jxbm">绩效年度编码</param>
        /// <param name="entity">指标库基本信息实体</param>
        /// <returns></returns>
        public void SaveForm(string zbbh, string jxbm, BpeTA001Entity entity)
        {
            if (!string.IsNullOrEmpty(zbbh) && !string.IsNullOrEmpty(jxbm))
            {
                entity.Modify(new string[] { zbbh, jxbm });
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