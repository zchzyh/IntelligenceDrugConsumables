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
    /// 基础数据编码
    /// </summary>
    public class S103CodeService : RepositoryFactory<S103CodeEntity>, IS103CodeService
    {
        #region 获取数据
        /// <summary>
        /// 基础数据编码列表
        /// </summary>
        /// <param name="typeId">查询参数</param>
        /// <param name="typeName">查询名称</param>
        /// <returns></returns>
        public IEnumerable<S103CodeEntity> GetList(string typeId, string typeName = "")
        {
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT C.[TYPEID]
                                  ,C.[VERID]
                                  ,[CODE]
                                  ,C.[NAME]
                                  ,[IX]
                                  ,C.[STATUS]
                                  ,[PY]
                                  ,[WB]
                                  ,[CREATOR]
                                  ,[CREATEDATE]
                                  ,[MODIFOR]
                                  ,[MODIFYDATE]
                                  ,[VERSION]
                                  ,[REMARK]
                            FROM [HQPAS].[BPMS].[S103_CODE] C
                            LEFT JOIN (SELECT [VERID]
                                             ,[TYPEID]
		                               FROM [HQPAS].[BPMS].[S102_VER]
			                           WHERE [STATUS] = '1') V ON C.[TYPEID] = V.[TYPEID] AND C.[VERID] = V.[VERID]
                            LEFT JOIN (SELECT [TYPEID]
                                             ,[NAME]
                            		   FROM [HQPAS].[BPMS].[S101_TYPE]
                            		   WHERE [STATUS] = '1') T ON C.[TYPEID] = T.[TYPEID]
                            WHERE C.[STATUS] = '1' AND 1 = 1 ");
            //类型ID
            if (!string.IsNullOrWhiteSpace(typeId))
            {
                strSql.Append(" AND C.[TYPEID] = @TYPEID ");
                parameter.Add(DbParameters.CreateDbParameter("@TYPEID", typeId));
            }
            //类型名称
            if (!string.IsNullOrWhiteSpace(typeName))
            {
                strSql.Append(" AND T.[NAME] = @TYPENAME ");
                parameter.Add(DbParameters.CreateDbParameter("@TYPENAME", typeName));
            }
            return this.HQPASRepository().FindList(strSql.ToString(), parameter.ToArray());
        }
        /// <summary>
        /// 基础数据编码列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<S103CodeEntity> GetList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<S103CodeEntity>();
            var queryParam = queryJson.ToJObject();
            //查询条件
            if (!queryParam["typeid"].IsEmpty())
            {
                string keyword = queryParam["typeid"].ToString();

                expression = expression.And(t => t.TYPEID == keyword);
            }
            if (!queryParam["verid"].IsEmpty())
            {
                string keyword = queryParam["verid"].ToString();

                expression = expression.And(t => t.VERID == keyword);
            }
            if (!queryParam["keyword"].IsEmpty())
            {
                string keyword = queryParam["keyword"].ToString();

                expression = expression.And(t => t.CODE.Contains(keyword)
                    || t.NAME.Contains(keyword)
                    || t.PY.Contains(keyword)
                    || t.WB.Contains(keyword));
            }
            return this.HQPASRepository().FindList(expression, pagination);
        }
        /// <summary>
        /// 基础数据版本实体
        /// </summary>
        /// <param name="typeId">主键值</param>
        /// <param name="verId">主键值</param>
        /// <param name="code">主键值</param>
        /// <returns></returns>
        public S103CodeEntity GetEntity(string typeId, string verId, string code)
        {
            return this.HQPASRepository().FindEntity(t => t.TYPEID == typeId && t.VERID == verId && t.CODE == code);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除基础数据编码
        /// </summary>
        /// <param name="typeId">主键</param>
        /// <param name="verId">主键</param>
        /// <param name="code">主键</param>
        public void RemoveForm(string typeId, string verId, string code)
        {
            this.HQPASRepository().Delete(t => t.TYPEID == typeId && t.VERID == verId && t.CODE == code);
        }
        /// <summary>
        /// 保存基础数据编码表单（新增、修改）
        /// </summary>
        /// <param name="typeId">主键值</param>
        /// <param name="verId">主键值</param>
        /// <param name="code">主键值</param>
        /// <param name="entity">基础数据编码实体</param>
        /// <returns></returns>
        public void SaveForm(string typeId, string verId, string code, S103CodeEntity entity)
        {
            if (!string.IsNullOrEmpty(typeId)
                && !string.IsNullOrEmpty(verId)
                && !string.IsNullOrEmpty(code))
            {
                entity.Modify(new string[] { typeId, verId, code });
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