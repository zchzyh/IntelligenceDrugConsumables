using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.Entity.CollectionManage.ViewModel;
using LeaRun.Application.Entity.SettingManage;
using LeaRun.Application.IService.CollectionManage;
using LeaRun.Data;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System.Linq.Expressions;
using LeaRun.Application.Entity.BaseManage;

namespace LeaRun.Application.Service.CollectionManage
{
    /// <summary>
    /// 采集任务生成
    /// </summary>
    public class BpcSp002Service : RepositoryFactory<BpcSp002Entity>, IBpcSp002Service
    {
        /// <summary>
        /// 采集任务生成
        /// </summary>
        /// <param name="year"></param>
        /// <param name="entities"></param>
        public void CreateTask(string year, List<BpcSp002Entity> entities)
        {
            decimal decYear;
            decimal.TryParse(year, out decYear);
            var jxbm = entities.Count > 0 ? entities[0].JXBM : "";
            var deletedEntities = HQPASRepository().IQueryable().Where(t => t.ND == decYear).ToList();
            IRepository db = new RepositoryFactory().HQPASRepository().BeginTrans();
            try
            {
                var editedEntities = deletedEntities.Where(d =>
                        entities.Exists(e =>
                            e.CJBBM == d.CJBBM && e.ND == d.ND && e.YD == d.YD &&
                            (e.JZSJ != d.JZSJ || e.KSSJ != d.KSSJ)))
                    .ToList();

                //排除修改过开始时间或结束时间记录
                deletedEntities.RemoveAll(d =>
                    editedEntities.Exists(e => e.CJBBM == d.CJBBM && e.ND == d.ND && e.YD == d.YD));
                entities.RemoveAll(d => editedEntities.Exists(e => e.CJBBM == d.CJBBM && e.ND == d.ND && e.YD == d.YD));
                db.Delete(deletedEntities);
                foreach (var e in entities)
                {
                    e.Create();
                }

                db.Insert(entities);
                if(!jxbm.IsEmpty())
                    CreateMonitoring(db, jxbm);
                db.Commit();
            }
            catch (Exception ex)
            {
                db.Rollback();
                throw;
            }
        }

        /// <summary>
        /// 添加采集日常监控表
        /// </summary>
        /// <param name="db"></param>
        /// <param name="jxbm"></param>
        public void CreateMonitoring(IRepository db, string jxbm)
        {
            var sp006Entities = GetNewTaskList(jxbm).ToList();
            foreach (var e in sp006Entities)
            {
                if (e.XH.IsEmpty())
                    e.Create();
            }

            db.Insert<BpcSP006Entity>(sp006Entities);
        }

        private IEnumerable<BpcSP006Entity> GetNewTaskList(string jxbm)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            var expression = LinqExtensions.True<RowColSettingModel>();

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(@"SELECT SP002.[RWBH],
                                   NULL         AS RWSJ,
                                   SP004.USERID AS SHR,
                                   SP005.USERID AS USERID,
                                   '0'          AS RWCD,
                                   '0'          AS SQZT,
                                   '0'          AS SHZT
                            FROM   [HQPAS].[BPMS].[BPC_SP002] SP002
                                   INNER JOIN [BPMS].[BPC_SP001] SP001
                                           ON SP001.CJBBM = SP002.CJBBM
                                   LEFT JOIN [BPMS].[BPC_SP004] SP004
                                          ON SP004.CJBBM = SP002.CJBBM
                                             AND SP004.ND = SP002.ND
                                   LEFT JOIN [BPMS].[BPC_SP005] SP005
                                          ON SP005.CJBBM = SP002.CJBBM
                                             AND SP005.ND = SP002.ND
                            WHERE  ( SP005.USERID IS NOT NULL )
                                   AND NOT EXISTS (SELECT 1
                                                   FROM   [BPMS].[BPC_SP006] SP006
                                                   WHERE  SP006.RWBH = SP002.RWBH
                                                          AND SP006.USERID = SP005.USERID)
                      ");
            if (!jxbm.IsEmpty())
            {
                sbSql.Append(" AND SP002.[JXBM] = @jxbm ");
                parameter.Add(DbParameters.CreateDbParameter("@jxbm", jxbm));
            }

            return new RepositoryFactory().HQPASRepository()
                .FindList<BpcSP006Entity>(sbSql.ToString(), parameter.ToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public BpcSp002Entity GetEntity(string keyValue)
        {
            return HQPASRepository().FindEntity(keyValue);
        }

        /// <summary>
        /// 获取任务信息管理实体
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public BpcSp002Entity GetEntity(Expression<Func<BpcSp002Entity, bool>> condition)
        {
            return HQPASRepository().FindEntity(condition);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void AdjustTaskDate(BpcSp002Entity entity)
        {
            if (!string.IsNullOrEmpty(entity.RWBH))
            {
                var obj = GetEntity(entity.RWBH);
                obj.KSSJ = entity.KSSJ;
                obj.JZSJ = entity.JZSJ;
                obj.Modify(obj.CJBBM);
                HQPASRepository().Update(obj);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskIds"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public void AdjustTasksDate(string taskIds, string startDate, string endDate)
        {
            string[] tasks = taskIds.Split(',');
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = $"'{tasks[i]}'";
            }

            string lastTaskIds = string.Join(",", tasks);
            string sql =
                $"update [BPMS].[BPC_SP002] set KSSJ='{startDate}',JZSJ='{endDate}' where RWBH in ({lastTaskIds})";
            this.HQPASRepository().ExecuteBySql(sql);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public TaskInfoModel GetTaskInfo(string keyValue)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(@"select SP002.*,
                                    SP001.CJBMC,
                                    SP001.CJPL,
                                    OFFIECES.OFFICENAME AS DeptName,
                                    U.NAME AS UserName
                                    from [BPMS].[BPC_SP002] SP002 
                                    INNER JOIN [BPMS].[BPC_SP001] SP001 ON SP002.CJBBM=SP001.CJBBM
                                    LEFT JOIN [BPMS].[BPC_SP005] SP005 ON SP002.CJBBM =SP005.CJBBM AND SP002.ND=SP005.ND
                                    LEFT JOIN [BPMS].[DEP_AUDIT_USER] U ON SP005.USERID=U.USERID
                                   	LEFT JOIN [BPMS].[PMR008_OFFIECES] OFFIECES on SP002.JGDM=OFFIECES.ID
                      WHERE 1=1");

            if (!keyValue.IsEmpty())
            {
                sbSql.Append(" AND SP002.[RWBH] = @RWBH ");
                parameter.Add(DbParameters.CreateDbParameter("@RWBH", keyValue));
            }

            return new RepositoryFactory().HQPASRepository()
                .FindList<TaskInfoModel>(sbSql.ToString(), parameter.ToArray()).FirstOrDefault();
        }


        ///// <summary>
        ///// 获取主管机构信息
        ///// </summary>
        ///// <returns></returns>
        //public OrganizeEntity GetOrganization()
        //{
        //    var expression = LinqExtensions.True<OrganizeEntity>();
        //    expression = expression.And(t => t.ParentId == "0");
        //    return new RepositoryFactory().BaseRepository().FindList(expression).FirstOrDefault();
        //}

        /// <summary>
        /// 获取主管机构信息（flag=1)
        /// </summary>
        /// <returns></returns>
        public PMR001MorEntity GetOrganization()
        {
            var expression = LinqExtensions.True<PMR001MorEntity>();
            expression = expression.And(t => t.FLAG == "1");
            return new RepositoryFactory().HQPASRepository().FindList(expression).FirstOrDefault();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<TaskInfoModel> GetPageList(Pagination pagination, string queryJson)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            var expression = LinqExtensions.True<RowColSettingModel>();

            StringBuilder sbSql = new StringBuilder();
         //   sbSql.Append(@"		 select A.*,
         //                           B.CJBMC,
         //                           B.CJPL,
								 //   OFFIECES.OFFICENAME as DeptName,
         //                           U.UserName
         //                           from [BPMS].[BPC_SP002] A 
         //                           INNER JOIN [BPMS].[BPC_SP001] B ON A.CJBBM=B.CJBBM
         //                           LEFT JOIN [BPMS].[BPC_SP005] C ON A.CJBBM =C.CJBBM AND A.ND=C.ND
         //                           LEFT JOIN [dbo].[V_UserInfo] U ON C.USERID=U.USERID
									//LEFT JOIN [BPMS].[PMR008_OFFIECES] OFFIECES on A.JGDM=OFFIECES.OFFICECODE
         //             WHERE 1=1");

            sbSql.Append(@"		 select A.*,
                                    B.CJBMC,
                                    B.CJPL,
								    OFFIECES.OFFICENAME as DeptName,
                                    U.NAME AS UserName
                                    from [BPMS].[BPC_SP002] A 
                                    INNER JOIN [BPMS].[BPC_SP001] B ON A.CJBBM=B.CJBBM
                                    LEFT JOIN [BPMS].[BPC_SP005] C ON A.CJBBM =C.CJBBM AND A.ND=C.ND
                                    LEFT JOIN [BPMS].[DEP_AUDIT_USER] U ON C.USERID=U.USERID
									LEFT JOIN [BPMS].[PMR008_OFFIECES] OFFIECES on A.JGDM=OFFIECES.Id
                      WHERE 1=1");


            var queryParam = queryJson.ToJObject();
            if (!queryParam["deptName"].IsEmpty())
            {
                sbSql.Append(" AND OFFIECES.[OFFICENAME] = @deptName ");
                parameter.Add(DbParameters.CreateDbParameter("@deptName", queryParam["deptName"].ToString()));
            }

            if (!queryParam["jxbm"].IsEmpty())
            {
                sbSql.Append(" AND A.[JXBM] = @jxbm ");
                parameter.Add(DbParameters.CreateDbParameter("@jxbm", queryParam["jxbm"].ToString()));
            }

            if (!queryParam["month"].IsEmpty())
            {
                sbSql.Append(" AND A.[YD] = @month ");
                parameter.Add(DbParameters.CreateDbParameter("@month", queryParam["month"].ToString()));
            }

            if (!queryParam["userName"].IsEmpty())
            {
                sbSql.Append(" AND u.[NAME] LIKE @userName ");
                parameter.Add(
                    DbParameters.CreateDbParameter("@userName", '%' + queryParam["userName"].ToString() + '%'));
            }

            if (!queryParam["tableName"].IsEmpty())
            {
                sbSql.Append(" AND B.CJBMC LIKE @tableName ");
                parameter.Add(
                    DbParameters.CreateDbParameter("@tableName", '%' + queryParam["tableName"].ToString() + '%'));
            }

            return new RepositoryFactory().HQPASRepository()
                .FindList<TaskInfoModel>(sbSql.ToString(), parameter.ToArray(), pagination);
        }

        public IEnumerable<BpcSp002Entity> GetUserTableList(string year, string userId)
        {
            throw new NotImplementedException();
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="year"></param>
        ///// <param name="userId"></param>
        ///// <returns></returns>
        //public IEnumerable<BpcSp002Entity> GetUserTableList(string year, string userId)
        //{
        //    try
        //    {
        //        List<DbParameter> parameter = new List<DbParameter>();
        //        var expression = LinqExtensions.True<BpcSp002Entity>();
        //        if (!year.IsEmpty())
        //        {
        //            expression = expression.And(e => e.ND.ToString() == year && e.USERID == userId);
        //        }

        //        return this.HQPASRepository().IQueryable(expression).ToList();
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //    return null;
        //}
    }
}