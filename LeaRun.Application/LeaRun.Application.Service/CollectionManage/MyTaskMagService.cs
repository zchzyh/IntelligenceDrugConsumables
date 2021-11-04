using LeaRun.Application.IService.CollectionManage;
using LeaRun.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaRun.Application.Entity.CollectionManage.ViewModel;
using LeaRun.Util.WebControl;
using LeaRun.Util;
using System.Data.Common;
using LeaRun.Util.Extension;
using LeaRun.Data;
using LeaRun.Application.Entity.CollectionManage;

namespace LeaRun.Application.Service.CollectionManage
{
    /// <summary>
    /// 我的采集任务
    /// </summary>
    public class MyTaskMagService : RepositoryFactory, IMyTaskMagService
    {

        #region 获取数据

        /// <summary>
        /// 获取我的采集任务列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<MyTaskMagModel> GetMyTaskMagList(Pagination pagination, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT P6.[XH]
                                    ,P2.[RWBH]
                                    ,P2.[CJBBM]
                                    ,P1.[CJBQM]
                                    ,P1.[CJPL]
                                    ,C.[NAME] CJPLNAME
                                    ,O.[OFFICECODE]
                                    ,O.[OFFICENAME]
                            	    ,P2.[ND]
                            	    ,P2.[YD]
                            	    ,P2.[KSSJ]
                            	    ,P2.[JZSJ]
                            	    ,P6.[USERID]
                            	    ,U.[NAME]
                            	    ,P6.[RWCD]
                            	    ,P6.[SQZT]
                            	    ,P6.[SHZT] FROM [HQPAS].[BPMS].[BPC_SP006] P6
                            LEFT JOIN [HQPAS].[BPMS].[BPC_SP002] P2
                            ON P2.[RWBH] = P6.[RWBH]
                            LEFT JOIN [HQPAS].[BPMS].[BPC_SP001] P1 WITH (NOLOCK)
                            ON P2.[CJBBM] = P1.[CJBBM]
                            LEFT JOIN (SELECT [CODE]
                                            , [NAME]
                                       FROM [HQPAS].[BPMS].[S103_CODE] WITH (NOLOCK)
                                       WHERE [TYPEID] = @FrequencyType AND [STATUS] = '1') C ON P1.[CJPL] = C.[CODE]
                            LEFT JOIN [HQPAS].[BPMS].[DEP_AUDIT_USER] U WITH (NOLOCK)
                            ON P6.[USERID] = U.[USERID]
                            LEFT JOIN [HQPAS].[BPMS].[PMR008_OFFIECES] O WITH (NOLOCK) 
                            ON P2.[JGDM] = O.[ID]
                            WHERE P2.[STATUS] = '1'
                            AND P1.[STATUS] = '1'
                            AND P6.[STATUS] = '1'
                            AND U.[STATUS] = '1' ");

            parameter.Add(DbParameters.CreateDbParameter("@FrequencyType", Config.GetValue("FrequencyType")));

            //年度过滤
            if (!queryParam["nd"].IsEmpty())
            {
                strSql.Append(" AND P2.[JXBM] = @ND ");
                parameter.Add(DbParameters.CreateDbParameter("@ND", queryParam["nd"].ToString()));
            }

            //月度过滤
            if (!queryParam["yd"].IsEmpty())
            {
                strSql.Append(" AND P2.[YD] = @YD ");
                parameter.Add(DbParameters.CreateDbParameter("@YD", queryParam["yd"].ToString()));
            }

            //采集状态过滤
            if (!queryParam["rwcd"].IsEmpty())
            {
                strSql.Append(" AND P6.[RWCD] = @RWCD ");
                parameter.Add(DbParameters.CreateDbParameter("@RWCD", queryParam["rwcd"].ToString()));
            }

            //申请状态过滤
            if (!queryParam["sqzt"].IsEmpty())
            {
                strSql.Append(" AND P6.[SQZT] = @SQZT ");
                parameter.Add(DbParameters.CreateDbParameter("@SQZT", queryParam["sqzt"].ToString()));
            }

            //审核状态过滤
            if (!queryParam["shzt"].IsEmpty())
            {
                strSql.Append(" AND P6.[SHZT] = @SHZT ");
                parameter.Add(DbParameters.CreateDbParameter("@SHZT", queryParam["shzt"].ToString()));
            }

            //采集表名称过滤
            if (!queryParam["cjbmc"].IsEmpty())
            {
                string cjbmc = queryParam["cjbmc"].ToString();
                strSql.Append(" AND P1.[CJBQM] LIKE @CJBMC ");
                parameter.Add(DbParameters.CreateDbParameter("@CJBMC", '%' + cjbmc + '%'));
            }

            return this.HQPASRepository().FindList<MyTaskMagModel>(strSql.ToString(), parameter.ToArray(), pagination);
        }

        /// <summary>
        /// 获取采集表表头
        /// </summary>
        /// <param name="entity">任务信息管理实体</param>
        /// <returns></returns>
        public IEnumerable<MyTableHeaderModel> GetCollectionTableHeader(BpcSp002Entity entity)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT [LBM]
                                    ,[LMC]
                                    ,[LCODE]
                                    ,[EDITABLE]
                                    ,[AUTOWIDTH]
                                    ,[WIDTH]
                                    ,[TYPE]
                                    ,[TEXTALIGN]
                                    ,[FORMATSTR]
                                    ,[ISMERGE]
                                    ,[VISIBLE]
                                    ,[INDEXNUM]
                            FROM [HQPAS].[BPMS].[BPC_SC003] WITH (NOLOCK)
                            WHERE [STATUS] = '1'
                            AND [CJBBM] = @CJBBM
                            AND [ND] = @ND
                            ORDER BY [INDEXNUM]");

            parameter.Add(DbParameters.CreateDbParameter("@CJBBM", entity.CJBBM));
            parameter.Add(DbParameters.CreateDbParameter("@ND", entity.ND));

            return this.HQPASRepository().FindList<MyTableHeaderModel>(strSql.ToString(), parameter.ToArray());
        }

        /// <summary>
        /// 获取采集表行
        /// </summary>
        /// <param name="entity">任务信息管理实体</param>
        /// <returns></returns>
        public IEnumerable<MyTableRowModel> GetCollectionTableRow(BpcSp002Entity entity)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT C1.[HXBM]
                                    ,C1.[NAME]
                                    ,C1.[SFZD]
                                    ,C1.[HCODE]
                                    ,C1.[PARENT]
                                    ,C1.[GRADE]
                                    ,C1.[PX]
                            FROM [HQPAS].[BPMS].[BPC_SC001] C1 WITH (NOLOCK)
                            LEFT JOIN [HQPAS].[BPMS].[BPC_SC002] C2 WITH (NOLOCK)
                            ON C1.[HXBM] = C2.[HXBM]
                            AND C1.[STATUS] = C2.[STATUS]
                            WHERE C1.[STATUS] = '1'
                            AND C2.[CJBBM] = @CJBBM
                            AND C2.[ND] = @ND");

            parameter.Add(DbParameters.CreateDbParameter("@CJBBM", entity.CJBBM));
            parameter.Add(DbParameters.CreateDbParameter("@ND", entity.ND));

            return this.HQPASRepository().FindList<MyTableRowModel>(strSql.ToString(), parameter.ToArray());
        }

        /// <summary>
        /// 获取采集表数据
        /// </summary>
        /// <param name="entity">任务信息管理实体</param>
        /// <returns></returns>
        public IEnumerable<MyTableDataModel> GetCollectionTableData(BpcSp002Entity entity)
        {
            List<DbParameter> parameter = new List<DbParameter>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT [XH]
                                    ,[RWBH]
                                    ,[LCODE]
                                    ,[HCODE]
                                    ,[CCVALUE]
                            FROM [HQPAS].[BPMS].[BPC_SC004] WITH (NOLOCK)
                            WHERE [STATUS] = '1'
                            AND [CJBBM] = @CJBBM
                            AND [RWBH] = @RWBH
                            AND [JXND] = @JXND
                            AND [JXYD] = @JXYD");

            parameter.Add(DbParameters.CreateDbParameter("@CJBBM", entity.CJBBM));
            parameter.Add(DbParameters.CreateDbParameter("@RWBH", entity.RWBH));
            parameter.Add(DbParameters.CreateDbParameter("@JXND", entity.ND));
            parameter.Add(DbParameters.CreateDbParameter("@JXYD", entity.YD));

            return this.HQPASRepository().FindList<MyTableDataModel>(strSql.ToString(), parameter.ToArray());
        }

        #endregion

        #region 提交数据

        #endregion
    }
}
