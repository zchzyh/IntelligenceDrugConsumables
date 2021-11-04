using LeaRun.Application.Code;
using LeaRun.Application.Entity.SettingManage;
using LeaRun.Application.IService.SettingManage;
using LeaRun.Data;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Service.SettingManage
{
    /// <summary>
    /// 基础数据版本
    /// </summary>
    public class S102VerService : RepositoryFactory<S102VerEntity>, IS102VerService
    {
        #region 获取数据
        /// <summary>
        /// 基础数据版本列表
        /// </summary>
        /// <param name="typeId">查询参数</param>
        /// <returns></returns>
        public IEnumerable<S102VerEntity> GetList(string typeId)
        {
            var expression = LinqExtensions.True<S102VerEntity>();
            expression = expression.And(t => t.TYPEID == typeId);
            return this.HQPASRepository().IQueryable(expression).ToList();
        }
        /// <summary>
        /// 基础数据版本实体
        /// </summary>
        /// <param name="typeId">主键值</param>
        /// <param name="verId">主键值</param>
        /// <returns></returns>
        public S102VerEntity GetEntity(string typeId, string verId)
        {
            return this.HQPASRepository().FindEntity(t => t.TYPEID == typeId && t.VERID == verId);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除基础数据版本
        /// </summary>
        /// <param name="typeId">主键</param>
        /// <param name="verId">主键</param>
        public void RemoveForm(string typeId, string verId)
        {
            var db = this.HQPASRepository().BeginTrans();
            try
            {
                db.Delete(t => t.TYPEID == typeId && t.VERID == verId);

                // 将相关基础项设为无效
                string updateCodeSql = @"UPDATE [BPMS].[S103_CODE]
                                         SET [STATUS] = '0'
                                            ,[MODIFOR] = @MODIFOR
                                            ,[MODIFYDATE] = @MODIFYDATE
                                         WHERE [TYPEID] = @TYPEID AND [VERID] = @VERID";
                var updateCodeParams = new List<DbParameter>();
                updateCodeParams.Add(DbParameters.CreateDbParameter("@TYPEID", typeId));
                updateCodeParams.Add(DbParameters.CreateDbParameter("@VERID", verId));
                updateCodeParams.Add(DbParameters.CreateDbParameter("@MODIFYDATE", DateTime.Now));
                updateCodeParams.Add(DbParameters.CreateDbParameter("@MODIFOR", OperatorProvider.Provider.Current().UserName));
                db.ExecuteBySql(updateCodeSql, updateCodeParams.ToArray());

                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 保存基础数据版本表单（新增、修改）
        /// </summary>
        /// <param name="typeId">主键值</param>
        /// <param name="verId">主键值</param>
        /// <param name="s102VerEntity">基础数据版本实体</param>
        /// <returns></returns>
        public void SaveForm(string typeId, string verId, S102VerEntity s102VerEntity)
        {
            var db = this.HQPASRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(typeId) && !string.IsNullOrEmpty(verId))
                {
                    s102VerEntity.Modify(new string[] { typeId, verId });
                    db.Update(s102VerEntity);

                    if (s102VerEntity.STATUS == "1")
                    {
                        // 将其它版本号设为无效
                        string updateVerSql = @"UPDATE [BPMS].[S102_VER]
                                                SET [STATUS] = '0'
                                                   ,[MODIFOR] = @MODIFOR
                                                   ,[MODIFYDATE] = @MODIFYDATE
                                                WHERE [TYPEID] = @TYPEID AND [VERID] != @VERID";
                        var updateVerParams = new List<DbParameter>();
                        updateVerParams.Add(DbParameters.CreateDbParameter("@TYPEID", typeId));
                        updateVerParams.Add(DbParameters.CreateDbParameter("@VERID", verId));
                        updateVerParams.Add(DbParameters.CreateDbParameter("@MODIFYDATE", DateTime.Now));
                        updateVerParams.Add(DbParameters.CreateDbParameter("@MODIFOR", OperatorProvider.Provider.Current().UserName));
                        db.ExecuteBySql(updateVerSql, updateVerParams.ToArray());

                        // 将其它版本号的基础项设为无效
                        string updateCodeSql = @"UPDATE [BPMS].[S103_CODE]
                                                 SET [STATUS] = '0'
                                                    ,[MODIFOR] = @MODIFOR
                                                    ,[MODIFYDATE] = @MODIFYDATE
                                                 WHERE [TYPEID] = @TYPEID AND [VERID] != @VERID";
                        var updateCodeParams = new List<DbParameter>();
                        updateCodeParams.Add(DbParameters.CreateDbParameter("@TYPEID", typeId));
                        updateCodeParams.Add(DbParameters.CreateDbParameter("@VERID", verId));
                        updateCodeParams.Add(DbParameters.CreateDbParameter("@MODIFYDATE", DateTime.Now));
                        updateCodeParams.Add(DbParameters.CreateDbParameter("@MODIFOR", OperatorProvider.Provider.Current().UserName));
                        db.ExecuteBySql(updateCodeSql, updateCodeParams.ToArray());
                    }
                    else if (s102VerEntity.STATUS == "0")
                    {
                        // 将该版本号的基础项设为无效
                        string updateCodeSql = @"UPDATE [BPMS].[S103_CODE]
                                                 SET [STATUS] = '0'
                                                    ,[MODIFOR] = @MODIFOR
                                                    ,[MODIFYDATE] = @MODIFYDATE
                                                 WHERE [TYPEID] = @TYPEID AND [VERID] = @VERID";
                        var updateCodeParams = new List<DbParameter>();
                        updateCodeParams.Add(DbParameters.CreateDbParameter("@TYPEID", typeId));
                        updateCodeParams.Add(DbParameters.CreateDbParameter("@VERID", verId));
                        updateCodeParams.Add(DbParameters.CreateDbParameter("@MODIFYDATE", DateTime.Now));
                        updateCodeParams.Add(DbParameters.CreateDbParameter("@MODIFOR", OperatorProvider.Provider.Current().UserName));
                        db.ExecuteBySql(updateCodeSql, updateCodeParams.ToArray());
                    }
                }
                else
                {
                    s102VerEntity.Create();
                    db.Insert(s102VerEntity);
                    if (s102VerEntity.STATUS == "1")
                    {
                        // 将其它版本号设为无效
                        string updateVerSql = @"UPDATE [BPMS].[S102_VER]
                                                SET [STATUS] = '0'
                                                   ,[MODIFOR] = @MODIFOR
                                                   ,[MODIFYDATE] = @MODIFYDATE
                                                WHERE [TYPEID] = @TYPEID AND [VERID] != @VERID";
                        var updateVerParams = new List<DbParameter>();
                        updateVerParams.Add(DbParameters.CreateDbParameter("@TYPEID", s102VerEntity.TYPEID));
                        updateVerParams.Add(DbParameters.CreateDbParameter("@VERID", s102VerEntity.VERID));
                        updateVerParams.Add(DbParameters.CreateDbParameter("@MODIFYDATE", DateTime.Now));
                        updateVerParams.Add(DbParameters.CreateDbParameter("@MODIFOR", OperatorProvider.Provider.Current().UserName));
                        db.ExecuteBySql(updateVerSql, updateVerParams.ToArray());

                        // 将其它版本号的基础项设为无效
                        string updateCodeSql = @"UPDATE [BPMS].[S103_CODE]
                                                 SET [STATUS] = '0'
                                                    ,[MODIFOR] = @MODIFOR
                                                    ,[MODIFYDATE] = @MODIFYDATE
                                                 WHERE [TYPEID] = @TYPEID AND [VERID] != @VERID";
                        var updateCodeParams = new List<DbParameter>();
                        updateCodeParams.Add(DbParameters.CreateDbParameter("@TYPEID", s102VerEntity.TYPEID));
                        updateCodeParams.Add(DbParameters.CreateDbParameter("@VERID", s102VerEntity.VERID));
                        updateCodeParams.Add(DbParameters.CreateDbParameter("@MODIFYDATE", DateTime.Now));
                        updateCodeParams.Add(DbParameters.CreateDbParameter("@MODIFOR", OperatorProvider.Provider.Current().UserName));
                        db.ExecuteBySql(updateCodeSql, updateCodeParams.ToArray());
                    }
                }

                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        #endregion
    }
}