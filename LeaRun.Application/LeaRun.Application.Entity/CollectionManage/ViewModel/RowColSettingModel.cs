using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LeaRun.Application.Entity.CollectionManage.ViewModel
{
    public class RowColSettingModel
    {
        /// <summary>
        /// 年度
        /// </summary>
        public string ND { get; set; }

      /// <summary>
        /// 采集表编码    
        /// </summary>
        public string CJBBM { get; set; }

        /// <summary>
        /// 采集表简称    
        /// </summary>
        public string CJBMC { get; set; }

        /// <summary>
        /// 采集表全名    
        /// </summary>
        public string CJBQM { get; set; }

        /// <summary>
        /// 所属类别
        /// </summary>
        public string CategoryName{ get; set; }

        /// <summary>
        /// 行状态
        /// </summary>
        public string RowStatus { get; set; }

        /// <summary>
        /// 列状态
        /// </summary>
        public string ColStatus { get; set; }
    }
}
