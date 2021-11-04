using LeaRun.Application.Entity.PerfConfig;
using LeaRun.Application.IService.PerfConfig;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Service.PerfConfig
{
    /// <summary>
    /// 年度绩效配置
    /// </summary>
    public class BpeSC001Service : RepositoryFactory<BpeSC001Entity>, IBpeSC001Service
    {
        #region 获取数据
        /// <summary>
        /// 获取年度列表
        /// </summary>
        /// <returns>年度列表</returns>
        public IEnumerable<string> GetYearList()
        {
            var strSql = new StringBuilder();
            strSql.Append(@"SELECT DISTINCT [JXND]
                            FROM [HQPAS].[BPMS].[BPE_SC001]
                            WHERE [STATUS] = '1'
                            ORDER BY [JXND] DESC");
            return this.HQPASRepository().FindList(strSql.ToString()).Select(t => t.JXND);
        }
        /// <summary>
        /// 获取年度列表
        /// </summary>
        /// <returns>年度列表</returns>
        public IEnumerable<BpeSC001Entity> GetYearBmList()
        {
            var strSql = new StringBuilder();
            strSql.Append(@"SELECT [JXBM],[JXND]
                            FROM [HQPAS].[BPMS].[BPE_SC001]
                            WHERE [STATUS] = '1'
                            ORDER BY [JXND] DESC");
            return this.HQPASRepository().FindList(strSql.ToString());
        }
        /// <summary>
        /// 年度绩效配置实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BpeSC001Entity GetEntity(string keyValue)
        {
            return this.HQPASRepository().FindEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存年度绩效配置表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">年度绩效配置实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, BpeSC001Entity entity)
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