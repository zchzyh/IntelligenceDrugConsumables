using LeaRun.Application.Entity.PerfReport;
using LeaRun.Application.Entity.PerfReport.ViewModel;
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
    /// 定量指标等级报告
    /// </summary>
    public class BpeRA001Service : RepositoryFactory<BpeRA001Entity>, IBpeRA001Service
    {
        #region 获取数据

        /// <summary>
        /// 定量指标等级报告列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<BpeRA001Entity> GetList(Pagination pagination, string queryJson)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT
	                            RA001.*,
	                            VA003.ZTMC, SC001.JXND AS year,OFFIECES.OFFICENAME as OfficeName
                            FROM
	                            bpms.BPE_RA001 RA001
	                            INNER JOIN bpms.BPE_VA004 VA004 ON RA001.CSFBH= VA004.CSFBH
	                            INNER JOIN bpms.BPE_VA003 VA003 ON VA003.ZTBH= VA004.ZTBH
                                INNER JOIN bpms.BPE_SC001 SC001 ON  SC001.JXBM=RA001.JXBM
                                INNER JOIN bpms.PMR008_OFFIECES OFFIECES ON OFFIECES.ID= RA001.JGBM
                                where 1=1 and RA001.STATUS=1
");
            var queryParam = queryJson.ToJObject();
            //绩效年度编码
            if (!queryParam["jxbm"].IsEmpty())
            {
                strSql.Append(" and RA001.JXBM=@CJBBM");
                parameter.Add(DbParameters.CreateDbParameter("@CJBBM", queryParam["jxbm"].ToString()));

            }

            //科室编码
            if (!queryParam["deptcode"].IsEmpty())
            {
                strSql.Append(" and RA001.JGBM=@JGBM");
                parameter.Add(DbParameters.CreateDbParameter("@JGBM", queryParam["deptcode"].ToString()));
            }

            return new RepositoryFactory().HQPASRepository()
                .FindList<BpeRA001Entity>(strSql.ToString(), parameter.ToArray(), pagination);
        }

        /// <summary>
        /// 下一年度改进报告
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<BpeRA001Entity> GetList(string queryJson)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT
	                            RA001.*,
	                            VA003.ZTMC 
                            FROM
	                            bpms.BPE_RA001 RA001
	                            INNER JOIN bpms.BPE_VA004 VA004 ON RA001.CSFBH= VA004.CSFBH
	                            INNER JOIN bpms.BPE_VA003 VA003 ON VA003.ZTBH= VA004.ZTBH
                                where 1=1 and RA001.STATUS=1
");
            var queryParam = queryJson.ToJObject();
            //绩效年度编码
            if (!queryParam["jxbm"].IsEmpty())
            {
                strSql.Append(" and JXBM=@CJBBM");
                parameter.Add(DbParameters.CreateDbParameter("@CJBBM", queryParam["jxbm"].ToString()));

            }

            //科室编码
            if (!queryParam["deptcode"].IsEmpty())
            {
                strSql.Append(" and JGBM=@JGBM");
                parameter.Add(DbParameters.CreateDbParameter("@JGBM", queryParam["deptcode"].ToString()));
            }

            return new RepositoryFactory().HQPASRepository()
                .FindList<BpeRA001Entity>(strSql.ToString(), parameter.ToArray());
        }

        public IEnumerable<SchemeWeightModel> GetSchemeWeighList(Pagination pagination, string queryJson)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            var queryParam = queryJson.ToJObject();

            parameter.Add(DbParameters.CreateDbParameter("@jxbm", queryParam["jxbm"].ToString()));

             var officeNo = queryParam["officeNo"].IsEmpty() ? "" : queryParam["officeNo"].ToString();
             parameter.Add(DbParameters.CreateDbParameter("@officeNo", officeNo));


            var jgpabh = queryParam["JGFABH"].IsEmpty() ? "" : queryParam["JGFABH"].ToString();
            parameter.Add(DbParameters.CreateDbParameter("@JGFABH", jgpabh));

            var level = queryParam["level"].IsEmpty() ? "0" : queryParam["level"].ToString();
            parameter.Add(DbParameters.CreateDbParameter("@level", level));

            var zbbh = queryParam["zbbh"].IsEmpty() ? "" : queryParam["zbbh"].ToString();
            parameter.Add(DbParameters.CreateDbParameter("@zbbh", zbbh));
            

            strSql .Append("EXEC [dbo].[proc_GetSchemeIndValue] @jxbm,@officeNo,@JGFABH,@level,@zbbh");
            return new RepositoryFactory().HQPASRepository()//.ExecuteByProc().("proc_GetSchemeIndValue", parameter.ToArray())
                .FindList<SchemeWeightModel>(strSql.ToString(), parameter.ToArray());
        }

        /// <summary>
        /// 定量指标等级报告实体
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <returns></returns>
        public BpeRA001Entity GetEntity(string keyvalue)
        {
            return this.HQPASRepository().FindEntity(keyvalue);
        }

        #endregion

        #region 提交数据
        /// <summary>
        /// 删除定量指标等级报告
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        public void RemoveForm(string keyvalue)
        {
            this.HQPASRepository().Delete(keyvalue);
        }
        /// <summary>
        /// 保存定量指标等级报告表单（新增、修改）
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <param name="entity">定量指标等级报告实体</param>
        /// <returns></returns>
        public void SaveForm(string keyvalue, BpeRA001Entity entity)
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