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
    /// 医疗机构注册
    /// </summary>
    public class PMR005OrgService : RepositoryFactory<PMR005OrgEntity>, IPMR005OrgService
    {
        #region 获取数据

        /// <summary>
        /// 医疗机构注册列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<PMR005OrgEntity> GetList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select 
                            ORGID,
                            ORGCODE,
                            MANAGERORGNAME,
                            SHORTNAME,ORGLEV,
                            ORGGRADE,
                            BELONGTO,
                            CORPORATE,
                            MEDICALCARETYPE,
                            ECONOMICCODE,
                            TYPECODE,
                            ADMINISTRATIVECODE,
                            REGMONEY,
                            [ADDRESS],
                            TEL,
                            ZIPCODE,
                            EMAIL,
                            HOSTUNIT,
                            REGAT,
                            COMPURL,
                            SWARAJ,
                            SWARAJINFO,
                            BEDNUM,
                            REALBEDNUM,
                            PERSONS,
                            MEDICALS,
                            SECTIONOFFICES,
                            CLINICS,
                            HOUSEAREA,
                            RENTINGAREA,
                            EQUIS,
                            EQUITENS,
                            TOTALMONEY,
                            FIXMONEY,
                            BRANCH,
                            PARENTORG,
                            FIXPOINT,
                            FIXPOINTCODE,
                            REMARK,
                            PY,WB,
                            FLAG,
                            CREATOR,
                            CREATEAT,
                            MODIFOR,
                            MODIFYAT,
                            [VERSION]
                            from BPMS.PMR005_ORG
                            WHERE 1 = 1 ");        
            if (!queryParam["keyword"].IsEmpty())//关键字查询
            {
                string keyord = queryParam["keyword"].ToString();
                strSql.Append(@" AND ( ORGCODE LIKE @keyword 
                                        or MANAGERORGNAME LIKE @keyword 
                    )");
                parameter.Add(DbParameters.CreateDbParameter("@keyword", '%' + keyord + '%'));
            }
            return this.HQPASRepository().FindList(strSql.ToString(), parameter.ToArray(), pagination);
        }

        /// <summary>
        /// 医疗机构注册列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<PMR005OrgEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<PMR005OrgEntity>();
            var queryParam = queryJson.ToJObject();
            //查询条件
            if (!queryParam["keyword"].IsEmpty())
            {
                string keyword = queryParam["keyword"].ToString();

                expression = expression.And(t => t.MANAGERORGNAME.Contains(keyword)
                                                 || t.SHORTNAME.Contains(keyword)
                                                 || t.PY.Contains(keyword)
                                                 || t.WB.Contains(keyword));
            }
            if (!queryParam["orgid"].IsEmpty())
            {
                string keyword = queryParam["orgid"].ToString();

                expression = expression.And(t => t.ADMINISTRATIVECODE == keyword);
            }
            return this.HQPASRepository().IQueryable(expression);
        }

        /// <summary>
        /// 医疗机构注册列表
        /// </summary>
        /// <param name="jxbm">年度绩效编码</param>
        /// <returns></returns>
        public IEnumerable<PMR005OrgEntity> GetListByJXBM(string jxbm)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT O.[ORGCODE]
                          	      ,O.[MANAGERORGNAME]
                            FROM [HQPAS].[BPMS].[BPC_SP007] P
                            LEFT JOIN (SELECT [ORGCODE]
                          				     ,[MANAGERORGNAME]
                          			   FROM [HQPAS].[BPMS].[PMR005_ORG]
                          			   WHERE [FLAG] = '1') O ON P.[JGBM] = O.[ORGCODE]
                            WHERE 1 = 1 ");
            //绩效年度编码
            if (!jxbm.IsEmpty())
            {
                strSql.Append(" AND [JXBM] = @JXBM ");
                parameter.Add(DbParameters.CreateDbParameter("@JXBM", jxbm));
            }
            return this.HQPASRepository().FindList(strSql.ToString(), parameter.ToArray());
        }

        /// <summary>
        /// 医疗机构注册实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public PMR005OrgEntity GetEntity(string keyValue)
        {
            return this.HQPASRepository().FindEntity(keyValue);
        }

        #endregion

        #region 提交数据
        /// <summary>
        /// 删除医疗机构注册
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            this.HQPASRepository().Delete(keyValue);
        }
        /// <summary>
        /// 保存医疗机构注册表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">主管机构信息实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, PMR005OrgEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
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