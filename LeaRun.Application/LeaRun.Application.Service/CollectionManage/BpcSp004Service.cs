using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.Entity.CollectionManage.ViewModel;
using LeaRun.Application.IService.CollectionManage;
using LeaRun.Data;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;

namespace LeaRun.Application.Service.CollectionManage
{
    /// <summary>
    /// 采集表分配
    /// </summary>
    public class BpcSp004Service : RepositoryFactory<BpcSp004Entity>, IBpcSp004Service
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<UserAuthTableInfoModel> GetPageList(Pagination pagination, string queryJson)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            var expression = LinqExtensions.True<RowColSettingModel>();

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(@"SELECT u.UserId,u.NAME as UserName,u.Status,u.Phone,d.NAME as DeptName,r.NAME as RoleName FROM bpms.DEP_AUDIT_USER as u
                                    left join bpms.DEP_AUDIT_USER_ROLE ur on u.USERID=ur.USERID
                                    left join bpms.DEP_AUDIT_DEPT d on u.DEPTID=d.DEPTID
                                    left join  bpms.DEP_AUDIT_ROLE  r on r.ROLEID=ur.ROLEID
                      WHERE 1=1");
            //sbSql.Append(@"SELECT * from [dbo].[V_UserInfo] WHERE 1=1");

            var queryParam = queryJson.ToJObject();
            if (!queryParam["depName"].IsEmpty())
            {
                sbSql.Append(" AND d.[NAME] = @depName ");
                parameter.Add(DbParameters.CreateDbParameter("@depName", queryParam["depName"].ToString()));
            }
            if (!queryParam["userId"].IsEmpty())
            {
                sbSql.Append(" AND u.[UserId] = @userId ");
                parameter.Add(DbParameters.CreateDbParameter("@userId", queryParam["userId"].ToString()));
            }
            if (!queryParam["userName"].IsEmpty())
            {
                sbSql.Append(" AND u.[NAME] LIKE @userName ");
                parameter.Add(DbParameters.CreateDbParameter("@userName", '%' + queryParam["userName"].ToString()+ '%'));
            }
            return new RepositoryFactory().HQPASRepository()
                .FindList<UserAuthTableInfoModel>(sbSql.ToString(), parameter.ToArray(), pagination);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<BpcSp004Entity> GetUserTableList(string year, string userId)
        {
                List<DbParameter> parameter = new List<DbParameter>();
                var expression = LinqExtensions.True<BpcSp004Entity>();
                if (!year.IsEmpty())
                {
                    expression = expression.And(e => e.ND.ToString() == year && e.USERID == userId);
                }

                return this.HQPASRepository().IQueryable(expression);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="userId"></param>
        /// <param name="entities"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void SaveData(string year,string userId,List<BpcSp004Entity> entities)
        {
            var deletedEntities = HQPASRepository().IQueryable().Where(t => t.ND.ToString() == year  && t.USERID== userId).ToList();
            IRepository db = new RepositoryFactory().HQPASRepository().BeginTrans();
            try
            {
                int result = db.Delete(deletedEntities);
                foreach (var e in entities)
                {
                    e.USERID = userId;
                    e.Create();
                    Thread.Sleep(5);
                }

                db.Insert(entities);
                db.Commit();
            }
            catch (Exception ex)
            {
                db.Rollback();
                throw;
            }
        }

        /// <summary>
        /// 获取审核权限分配实体
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public BpcSp004Entity GetEntity(Expression<Func<BpcSp004Entity, bool>> condition)
        {
            return this.HQPASRepository().FindEntity(condition);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="entities"></param>
        /// <param name="existEntity"></param>
        /// <returns></returns>
        public bool ExistsRecord(string userId, List<BpcSp004Entity> entities, out BpcSp004Entity existEntity)
        {
            existEntity = null;
            if (entities.Count < 1) return false;
            var list = GetUserTableList(entities[0].ND).ToList();
            foreach (var e in entities)
            {
                var entity = list.Find(t => t.CJBBM == e.CJBBM && t.USERID != userId);
                if (entity != null) { existEntity = entity; return true; }
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public IEnumerable<BpcSp004Entity> GetUserTableList(string year)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            var expression = LinqExtensions.True<BpcSp004Entity>();
            if (!year.IsEmpty())
            {
                expression = expression.And(e => e.ND.ToString() == year);
            }

            return this.HQPASRepository().IQueryable(expression).ToList();
        }
    }
}
