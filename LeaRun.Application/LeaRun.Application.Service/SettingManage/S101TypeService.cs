using LeaRun.Application.Code;
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
    /// 基础数据分类
    /// </summary>
    public class S101TypeService : RepositoryFactory<S101TypeEntity>, IS101TypeService
    {
        #region 获取数据
        /// <summary>
        /// 基础数据分类列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<S101TypeEntity> GetList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<S101TypeEntity>();
            var queryParam = queryJson.ToJObject();
            //查询条件
            if (!queryParam["keyword"].IsEmpty())
            {
                string keyword = queryParam["keyword"].ToString();

                expression = expression.And(t => t.TYPEID.Contains(keyword)
                    || t.NAME.Contains(keyword)
                    || t.PY.Contains(keyword)
                    || t.WB.Contains(keyword));
            }
            return this.HQPASRepository().FindList(expression, pagination);
        }

        /// <summary>
        /// 获取所有标准编码类别
        /// </summary>
        /// <returns></returns>
        public IEnumerable<S101TypeEntity> GetList()
        {
            var expression = LinqExtensions.True<S101TypeEntity>();
            expression = expression.And(t => t.STATUS == "1");
            return this.HQPASRepository().IQueryable(expression);
        }

        /// <summary>
        /// 基础数据分类实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public S101TypeEntity GetEntity(string keyValue)
        {
            return this.HQPASRepository().FindEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除基础数据分类
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            var db = this.HQPASRepository().BeginTrans();
            try
            {
                // 删除基础数据分类
                string deleteTypeSql = @"DELETE FROM [BPMS].[S101_TYPE] WHERE [TYPEID] = @TYPEID";
                var deleteParameters = new List<DbParameter>();
                deleteParameters.Add(DbParameters.CreateDbParameter("@TYPEID", keyValue));
                db.ExecuteBySql(deleteTypeSql, deleteParameters.ToArray());

                // 将相关版本号设为无效
                string updateVerSql = @"UPDATE [BPMS].[S102_VER]
                                        SET [STATUS] = '0'
                                           ,[MODIFOR] = @MODIFOR
                                           ,[MODIFYDATE] = @MODIFYDATE
                                        WHERE [TYPEID] = @TYPEID";
                var updateVerParams = new List<DbParameter>();
                updateVerParams.Add(DbParameters.CreateDbParameter("@TYPEID", keyValue));
                updateVerParams.Add(DbParameters.CreateDbParameter("@MODIFYDATE", DateTime.Now));
                updateVerParams.Add(DbParameters.CreateDbParameter("@MODIFOR", OperatorProvider.Provider.Current().UserName));
                db.ExecuteBySql(updateVerSql, updateVerParams.ToArray());

                // 将相关基础项设为无效
                string updateCodeSql = @"UPDATE [BPMS].[S103_CODE]
                                         SET [STATUS] = '0'
                                            ,[MODIFOR] = @MODIFOR
                                            ,[MODIFYDATE] = @MODIFYDATE
                                         WHERE [TYPEID] = @TYPEID";
                var updateCodeParams = new List<DbParameter>();
                updateCodeParams.Add(DbParameters.CreateDbParameter("@TYPEID", keyValue));
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
        /// 保存基础数据分类表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="s101TypeEntity">基础数据分类实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, S101TypeEntity s101TypeEntity)
        {
            var db = this.HQPASRepository().BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    s101TypeEntity.Modify(keyValue);
                    db.Update(s101TypeEntity);

                    if (s101TypeEntity.STATUS == "0")
                    {
                        // 将相关版本号设为无效
                        string updateVerSql = @"UPDATE [BPMS].[S102_VER]
                                                SET [STATUS] = '0'
                                                   ,[MODIFOR] = @MODIFOR
                                                   ,[MODIFYDATE] = @MODIFYDATE
                                                WHERE [TYPEID] = @TYPEID";
                        var updateVerParams = new List<DbParameter>();
                        updateVerParams.Add(DbParameters.CreateDbParameter("@TYPEID", keyValue));
                        updateVerParams.Add(DbParameters.CreateDbParameter("@MODIFYDATE", DateTime.Now));
                        updateVerParams.Add(DbParameters.CreateDbParameter("@MODIFOR", OperatorProvider.Provider.Current().UserName));
                        db.ExecuteBySql(updateVerSql, updateVerParams.ToArray());

                        // 将相关基础项设为无效
                        string updateCodeSql = @"UPDATE [BPMS].[S103_CODE]
                                                 SET [STATUS] = '0'
                                                    ,[MODIFOR] = @MODIFOR
                                                    ,[MODIFYDATE] = @MODIFYDATE
                                                 WHERE [TYPEID] = @TYPEID";
                        var updateCodeParams = new List<DbParameter>();
                        updateCodeParams.Add(DbParameters.CreateDbParameter("@TYPEID", keyValue));
                        updateCodeParams.Add(DbParameters.CreateDbParameter("@MODIFYDATE", DateTime.Now));
                        updateCodeParams.Add(DbParameters.CreateDbParameter("@MODIFOR", OperatorProvider.Provider.Current().UserName));
                        db.ExecuteBySql(updateCodeSql, updateCodeParams.ToArray());
                    }
                }
                else
                {
                    s101TypeEntity.Create();
                    db.Insert(s101TypeEntity);
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