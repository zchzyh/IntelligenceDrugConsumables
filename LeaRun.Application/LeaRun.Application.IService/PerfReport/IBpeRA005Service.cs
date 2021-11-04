using LeaRun.Application.Entity.PerfReport;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.IService.PerfReport
{
  public  interface IBpeRA005Service
    {
        #region 获取数据
        /// <summary>
        /// 最终评定报告实体
        /// </summary>
        /// <param name="year"></param>
        /// <param name="serial_num"></param>
        /// <returns></returns>
        BpeRA005Entity GetEntity(string serial_num);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除最终评定报告
        /// </summary>
        /// <param name="year_code"></param>
        /// <param name="keyvalue"></param>
        void RemoveForm(string year_code, string keyvalue);
        /// <summary>
        /// 保存最终评定报告（新增、修改）
        /// </summary>
        /// <param name="keyvalue">主键值</param>
        /// <param name="entity">最终评定报告实体</param>
        /// <returns></returns>
        void SaveForm(string keyvalue, BpeRA005Entity entity);
        #endregion
    }
}
