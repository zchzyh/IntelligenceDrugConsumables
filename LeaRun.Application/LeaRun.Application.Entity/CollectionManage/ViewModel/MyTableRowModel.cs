using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.CollectionManage.ViewModel
{
    /// <summary>
    /// 采集表行
    /// </summary>
    public class MyTableRowModel
    {
        /// <summary>
        /// 横向编码
        /// </summary>
        public string HXBM { get; set; }

        /// <summary>
        /// 横向名称
        /// </summary>
        public string NAME { get; set; }

        /// <summary>
        /// 是否字典
        /// </summary>
        public string SFZD { get; set; }

        /// <summary>
        /// 字典编码
        /// </summary>
        public string HCODE { get; set; }

        /// <summary>
        /// 上级编码
        /// </summary>
        public string PARENT { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        public string GRADE { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public string PX { get; set; }
    }
}
