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
    /// 医疗卫生人员表
    /// </summary>
    public class PMR009UserService : RepositoryFactory<PMR009UserEntity>, IPMR009UserService
    {
        #region 获取数据
        /// <summary>
        /// 医疗卫生人员列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<PMR009UserEntity> GetList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select ID,
                            CARDTYPE,
                            CARDCODE,
                            NAME,
                            SEX,
                            BIRTHDAY,
                            ORGID,
                            POST,
                            SECTIONOFFICE,
                            SECTIONOFFICECODE,
                            DUTIES,
                            PROFESSIONAL,
                            LICENSE,
                            LICENSECODE,
                            PROFESSIONALNAME,
                            PROFESSIONALCODE,
                            EDUCATION,
                            DEGREE,
                            WORKAT,
                            COUNTRYCODE,
                            NATIONALITYCODE,
                            EFFAT,
                            EXPAT,
                            MARRIAGECODE,
                            TEL,
                            WORKTEL,
                            EMAIL,
                            [ADDRESS],
                            REMARK,
                            PY,
                            WB,
                            FLAG,
                            ACCOUNT,
                            CREATOR,
                            CREATEAT,
                            MODIFOR,
                            MODIFYAT,
                            [VERSION],
                            CAREERNAME,
                            CAREERCODE,
                            MDUTIES,
                            MDUTYCODE,
                            DUTYCODE
                            from BPMS.PMR009_USER
                            WHERE 1 = 1 ");
            if (!queryParam["organizeId"].IsEmpty())
            {
                strSql.Append(@" AND ORGID=@ORGID ");
                parameter.Add(DbParameters.CreateDbParameter("@ORGID",queryParam["organizeId"].ToString()));
            }
            if (!queryParam["parentId"].IsEmpty())
            {
                strSql.Append(@" AND SECTIONOFFICECODE=@SECTIONOFFICECODE ");
                parameter.Add(DbParameters.CreateDbParameter("@SECTIONOFFICECODE", queryParam["parentId"].ToString()));
            }
            if (!queryParam["keyword"].IsEmpty())//关键字查询
            {
                string keyord = queryParam["keyword"].ToString();
                strSql.Append(@" AND ( CARDCODE LIKE @keyword 
                                        or NAME LIKE @keyword 
                    )");
                parameter.Add(DbParameters.CreateDbParameter("@keyword", '%' + keyord + '%'));
            }
            return this.HQPASRepository().FindList(strSql.ToString(), parameter.ToArray(), pagination);
        }
        /// <summary>
        /// 医疗卫生人员列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<PMR009UserEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<PMR009UserEntity>();
            var queryParam = queryJson.ToJObject();
            //查询条件
            if (!queryParam["keyword"].IsEmpty())
            {
                string keyword = queryParam["keyword"].ToString();

                expression = expression.And(t => t.CARDCODE.Contains(keyword)
                                                 || t.NAME.Contains(keyword)
                                                 || t.PY.Contains(keyword)
                                                 || t.WB.Contains(keyword));
            }
            //if (!queryParam["orgid"].IsEmpty())
            //{
            //    string keyword = queryParam["orgid"].ToString();

            //    expression = expression.And(t => t.ADMINISTRATIVECODE == keyword);
            //}
            return this.HQPASRepository().IQueryable(expression);
        }
        /// <summary>
        /// 医疗卫生人员实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public PMR009UserEntity GetEntity(string keyValue)
        {
            return this.HQPASRepository().FindEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除医疗卫生人员表
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            this.HQPASRepository().Delete(keyValue);
        }
        /// <summary>
        /// 保存医疗卫生人员表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">主管机构信息实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, PMR009UserEntity entity)
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
