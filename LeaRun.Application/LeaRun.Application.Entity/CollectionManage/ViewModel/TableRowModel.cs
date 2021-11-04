using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.CollectionManage.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class TableRowModel
    {
        /// <summary>
        /// 横向编码
        /// </summary>
        public string HXBM { get; set; }
        
        /// <summary>
        /// 横向名称编码名称
        /// </summary>
        public string RowName { get; set; }

        /// <summary>
        /// 采集表编码
        /// </summary>
        public string CJBBM { get; set; }

        /// <summary>
        /// 是否字典
        /// </summary>
        public string SFZD { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int PX { get; set; }


    }
}
