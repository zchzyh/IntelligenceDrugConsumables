using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.CollectionManage.ViewModel
{
    /// <summary>
    /// 归零修正法
    /// </summary>
    public class ZeroingCorrectModel
    {
        /// <summary>
        /// 序号
        /// </summary>
        public string XH { get; set; }

        /// <summary>
        /// 年度
        /// </summary>
        public string JXND { get; set; }

        /// <summary>
        /// 月度
        /// </summary>
        public string JXYD { get; set; }

        /// <summary>
        /// 所属类别名称
        /// </summary>
        public string SSLBNAME { get; set; }

        /// <summary>
        /// 科室代码
        /// </summary>
        public string OFFICECODE { get; set; }

        /// <summary>
        /// 科室名称
        /// </summary>
        public string OFFICENAME { get; set; }

        /// <summary>
        /// 采集表全名称
        /// </summary>
        public string CJBQM { get; set; }

        /// <summary>
        /// 行编码
        /// </summary>
        public string HCODE { get; set; }

        /// <summary>
        /// 行名称
        /// </summary>
        public string HNAME { get; set; }

        /// <summary>
        /// 列编码
        /// </summary>
        public string LCODE { get; set; }

        /// <summary>
        /// 列名称
        /// </summary>
        public string LNAME { get; set; }

        /// <summary>
        /// 存储值
        /// </summary>
        [DecimalPrecision]
        public decimal CCVALUE { get; set; }

        /// <summary>
        /// 归零值
        /// </summary>
        [DecimalPrecision]
        public decimal GLVALUE { get; set; }

        /// <summary>
        /// 实际值
        /// </summary>
        [DecimalPrecision]
        public decimal? SJVALUE { get; set; }
    }
}
