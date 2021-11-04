using LeaRun.Application.Entity.PerfReport;
using LeaRun.Application.IService.PerfReport;
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

namespace LeaRun.Application.Service.PerfReport
{
    /// <summary>
    /// 定性等级报告
    /// </summary>
    public class BpeRA002Service : RepositoryFactory<BpeRA002Entity>, IBpeRA002Service
    {
        #region 获取数据

        /// <summary>
        /// 定性指标等级报告列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<BpeRA002Entity> GetList(Pagination pagination, string queryJson)
        {

            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT
	                            RA002.*,SC001.JXND AS year,OFFIECES.OFFICENAME as OfficeName,
	                            VA003.ZTMC 
                            FROM
	                            bpms.BPE_RA002 RA002
	                            INNER JOIN bpms.BPE_VA004 VA004 ON RA002.CSFBH= VA004.CSFBH
	                            INNER JOIN bpms.BPE_VA003 VA003 ON VA003.ZTBH= VA004.ZTBH
                                INNER JOIN bpms.BPE_SC001 SC001 ON  SC001.JXBM=RA002.JXBM
	                            INNER JOIN bpms.PMR008_OFFIECES OFFIECES ON OFFIECES.ID= RA002.JGBM
                                where 1=1 and RA002.STATUS=1");
            var queryParam = queryJson.ToJObject();
            //绩效年度编码
            if (!queryParam["jxbm"].IsEmpty())
            {
                strSql.Append(" and RA002.JXBM=@CJBBM");
                parameter.Add(DbParameters.CreateDbParameter("@CJBBM", queryParam["jxbm"].ToString()));

            }

            //科室编码
            if (!queryParam["deptcode"].IsEmpty())
            {
                strSql.Append(" and RA002.JGBM=@JGBM");
                parameter.Add(DbParameters.CreateDbParameter("@JGBM", queryParam["deptcode"].ToString()));
            }

            return new RepositoryFactory().HQPASRepository()
                .FindList<BpeRA002Entity>(strSql.ToString(), parameter.ToArray(), pagination);


            //var expression = LinqExtensions.True<BpeRA002Entity>();
            //var queryParam = queryJson.ToJObject();
            ////绩效年度编码
            //if (!queryParam["jxbm"].IsEmpty())
            //{
            //    string keyword = queryParam["jxbm"].ToString();

            //    expression = expression.And(t => t.JXBM == keyword);
            //}
            ////科室编码
            //if (!queryParam["deptcode"].IsEmpty())
            //{
            //    string keyword = queryParam["deptcode"].ToString();

            //    expression = expression.And(t => t.JGBM == keyword);
            //}

            //return this.HQPASRepository().FindList(expression, pagination);
        }

        /// <summary>
        /// 定性指标等级报告实体
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <returns></returns>
        public BpeRA002Entity GetEntity(string keyvalue)
        {
            return this.HQPASRepository().FindEntity(keyvalue);
        }

        #endregion

        #region 提交数据
        /// <summary>
        /// 删除定性指标等级报告
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        public void RemoveForm(string keyvalue)
        {
            this.HQPASRepository().Delete(keyvalue);
        }
        /// <summary>
        /// 保存定性指标等级报告表单（新增、修改）
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <param name="entity">定性指标等级报告实体</param>
        /// <returns></returns>
        public void SaveForm(string keyvalue, BpeRA002Entity entity)
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
        #endregion
    }
}