using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.CollectionAnalysis.ViewModel
{
    /// <summary>
    /// 数据项分析
    /// </summary>
    public class StandardDataAnalysisModel
    {
        /// <summary>
        /// 序号
        /// </summary>
        public string XH { get; set; }
        /// <summary>
        /// 绩效年度编码
        /// </summary>
        public string JXBM { get; set; }
        /// <summary>
        /// 年度
        /// </summary>
        public decimal ND { get; set; }
        /// <summary>
        /// 月度
        /// </summary>
        public decimal YD { get; set; }
        /// <summary>
        /// 一级分类
        /// </summary>
        public string TYPENAME { get; set; }
        /// <summary>
        /// 二级分类
        /// </summary>
        public string SECTYPENAME { get; set; }
        /// <summary>
        /// 基础数据编码
        /// </summary>
        public string JCSJBM { get; set; }
        /// <summary>
        /// 基础数据名称
        /// </summary>
        public string JCSJMC { get; set; }
        /// <summary>
        /// 基础数据值
        /// </summary>
        [DecimalPrecision]
        public decimal? JCSJZ { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string UNITNAME { get; set; }
    }
}