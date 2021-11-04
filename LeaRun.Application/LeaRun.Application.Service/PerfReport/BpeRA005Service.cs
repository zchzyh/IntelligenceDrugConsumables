using LeaRun.Application.Entity.PerfConfig.ViewModel;
using LeaRun.Application.Entity.PerfReport;
using LeaRun.Application.IService.PerfReport;
using LeaRun.Data;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System;

namespace LeaRun.Application.Service.PerfReport
{
    /// <summary>
    /// 最终评定报告
    /// </summary>
    public class BpeRA005Service : RepositoryFactory<BpeRA005Entity>,IBpeRA005Service
    {
        #region 获取数据


        /// <summary>
        /// 获取最终评定报告实体
        /// </summary>
        /// <param name="year"></param>
        /// <param name="serial_num"></param>
        /// <returns></returns>
        public BpeRA005Entity GetEntity( string serial_num)
        {
            return this.HQPASRepository().FindEntity(e=> e.serial_num == serial_num);
        }

        #endregion

        #region 操作数据
        /// <summary>
        /// 删除最终评定报告
        /// </summary>
        /// <param name="year_code">年度</param>
        /// <param name="serial_num">序号</param>
        public void RemoveForm(string year_code, string serial_num)
        {
            this.HQPASRepository().Delete(e => e.year_code == year_code &&  e.serial_num==serial_num);
        }
        /// <summary>
        /// 保存最终评定报告表单（新增、修改）
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <param name="entity">最终评定报告实体</param>
        /// <returns></returns>
        public void SaveForm(string keyvalue, BpeRA005Entity entity)
        {
            if (!string.IsNullOrEmpty(keyvalue))
            {
                entity.Modify(new string[] { keyvalue } );
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
