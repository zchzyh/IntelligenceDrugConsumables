using LeaRun.Application.Entity.SettingManage;
using LeaRun.Application.IService.SettingManage;
using LeaRun.Data.Repository;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaRun.Application.Entity.CollectionManage;
using LeaRun.Application.Entity.CollectionManage.ViewModel;
using LeaRun.Data;
using LeaRun.Util;

namespace LeaRun.Application.Service.SettingManage
{
    /// <summary>
    /// 医疗机构科室信息
    /// </summary>
    public class PMR008OffiecesService : RepositoryFactory<PMR008OffiecesEntity>, IPMR008OffiecesService
    {
        #region 获取数据
        /// <summary>
        /// 医疗机构科室信息列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PMR008OffiecesEntity> GetList()
        {
            return this.HQPASRepository().IQueryable().OrderByDescending(t => t.CREATEAT).ToList();
        }

        /// <summary>
        /// 医疗机构科室信息列表(分页)
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<PMR008OffiecesEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            var expression = LinqExtensions.True<PMR008OffiecesEntity>();

            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(@"	SELECT
	                                office.[ID],
	                                office.[ORGID],
	                                office.[OFFICECODE],
	                                office.[OFFICENAME],
	                                office.[CREATOR],
	                                office.[CREATEAT],
	                                office.[MODIFOR],
	                                office.[MODIFYAT],
	                                office.[VERSION],
	                                org.[MANAGERORGNAME] AS OrgName,
                                    org.[ORGCODE]
                                FROM
	                                [HQPAS].[BPMS].[PMR008_OFFIECES] office
	                                INNER JOIN [BPMS].[PMR005_ORG] org ON office.ORGID= org.ORGCODE 
                                WHERE
	                                org.FLAG=1
                      ");
            if (!queryParam["orgId"].IsEmpty())
            {
                sbSql.Append(" AND org.[ORGID] = @orgId ");
                parameter.Add(DbParameters.CreateDbParameter("@orgId",  queryParam["orgId"].ToString()));
            }
            if (!queryParam["office"].IsEmpty())
            {
                sbSql.Append(" AND office.[OFFICENAME] LIKE @office ");
                parameter.Add(DbParameters.CreateDbParameter("@office", '%' + queryParam["office"].ToString() + '%'));
            }
            if (!queryParam["officeCode"].IsEmpty())
            {
                sbSql.Append(" AND office.[OFFICECODE] LIKE @officeCode ");
                parameter.Add(DbParameters.CreateDbParameter("@officeCode", '%' + queryParam["officeCode"].ToString() + '%'));
            }
            
            return HQPASRepository().FindList(sbSql.ToString(), parameter.ToArray(), pagination);
        }

        /// <summary>
        /// 医疗机构科室信息实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public PMR008OffiecesEntity GetEntity(string keyValue)
        {
            return this.HQPASRepository().FindEntity(keyValue);
        }
        #endregion

        #region 验证数据
        /// <summary>
        /// 医疗机构科室编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            var expression = LinqExtensions.True<PMR008OffiecesEntity>();
            expression = expression.And(t => t.OFFICECODE == enCode);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.ID != keyValue);
            }
            return this.HQPASRepository().IQueryable(expression).Count() == 0 ? true : false;
        }
        /// <summary>
        /// 医疗机构科室名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string fullName, string keyValue)
        {
            var expression = LinqExtensions.True<PMR008OffiecesEntity>();
            expression = expression.And(t => t.OFFICENAME == fullName);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.ID != keyValue);
            }
            return this.HQPASRepository().IQueryable(expression).Count() == 0 ? true : false;
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除医疗机构科室
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            //int count = this.BaseRepository().IQueryable(t => t.ParentId == keyValue).Count();
            //if (count > 0)
            //{
            //    throw new Exception("当前所选数据有子节点数据！");
            //}
            this.HQPASRepository().Delete(keyValue);
        }
        /// <summary>
        /// 保存医疗机构科室表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="departmentEntity">机构实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, PMR008OffiecesEntity offiecesEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                offiecesEntity.Modify(keyValue);
                this.HQPASRepository().Update(offiecesEntity);
            }
            else
            {
                offiecesEntity.Create();
                this.HQPASRepository().Insert(offiecesEntity);
            }
        }

        #endregion
    }
}
