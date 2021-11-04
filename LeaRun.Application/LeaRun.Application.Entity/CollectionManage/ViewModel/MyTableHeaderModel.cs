using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.CollectionManage.ViewModel
{
    /// <summary>
    /// 采集表表头
    /// </summary>
    public class MyTableHeaderModel
    {
        /// <summary>
        /// 列编码
        /// </summary>
        public string LBM { get; set; }

        /// <summary>
        /// 列名称
        /// </summary>
        public string LMC { get; set; }

        /// <summary>
        /// 字典编码
        /// </summary>
        public string LCODE { get; set; }

        /// <summary>
        /// 是否可编辑
        /// </summary>
        public string EDITABLE { get; set; }

        /// <summary>
        /// 自动宽度
        /// </summary>
        public string AUTOWIDTH { get; set; }

        /// <summary>
        /// 宽度
        /// </summary>
        [DecimalPrecision]
        public decimal? WIDTH { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public string TYPE { get; set; }

        /// <summary>
        /// 内容布局方式
        /// </summary>
        public string TEXTALIGN { get; set; }

        /// <summary>
        /// 格式化参数
        /// </summary>
        public string FORMATSTR { get; set; }

        /// <summary>
        /// 是否合并
        /// </summary>
        public string ISMERGE { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public string VISIBLE { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [DecimalPrecision]
        public decimal? INDEXNUM { get; set; }
    }
}
