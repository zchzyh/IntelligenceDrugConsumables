using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.CollectionManage.ViewModel
{
    /// <summary>
    /// 采集表
    /// </summary>
    public class CollectionCellModel
    {
        /// <summary>
        /// 序号
        /// </summary>
        public string XH { get; set; }

        /// <summary>
        /// 行-编码
        /// </summary>
        public string HCODE { get; set; }

        /// <summary>
        /// 行-名称
        /// </summary>
        public string HNAME { get; set; }

        /// <summary>
        /// 行-上级编码
        /// </summary>
        public string HPARENT { get; set; }

        /// <summary>
        /// 行-级别
        /// </summary>
        public string HGRADE { get; set; }

        /// <summary>
        /// 行-排序
        /// </summary>
        public string HPX { get; set; }

        /// <summary>
        /// 列-编码
        /// </summary>
        public string LCODE { get; set; }

        /// <summary>
        /// 列-名称
        /// </summary>
        public string LNAME { get; set; }

        /// <summary>
        /// 列-是否可编辑
        /// </summary>
        public string LEDITABLE { get; set; }

        /// <summary>
        /// 列-自动宽度
        /// </summary>
        public string LAUTOWIDTH { get; set; }

        /// <summary>
        /// 列-宽度
        /// </summary>
        [DecimalPrecision]
        public decimal? LWIDTH { get; set; }

        /// <summary>
        /// 列-数据类型
        /// </summary>
        public string LTYPE { get; set; }

        /// <summary>
        /// 列-内容布局方式
        /// </summary>
        public string LTEXTALIGN { get; set; }

        /// <summary>
        /// 列-格式化参数
        /// </summary>
        public string LFORMATSTR { get; set; }

        /// <summary>
        /// 列-是否合并
        /// </summary>
        public string LISMERGE { get; set; }

        /// <summary>
        /// 列-是否显示
        /// </summary>
        public string LVISIBLE { get; set; }

        /// <summary>
        /// 列-排序
        /// </summary>
        public string LINDEXNUM { get; set; }

        /// <summary>
        /// 存储值
        /// </summary>
        public string CCVALUE { get; set; }
    }
}
