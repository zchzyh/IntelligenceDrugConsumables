﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfImprove.ViewModel
{
    /// <summary>
    /// 纵向比较法分析
    /// </summary>
    public class VerticalComparisonModel
    {
        /// <summary>
        /// BSC编号
        /// </summary>
        public string BSCBH { get; set; }

        /// <summary>
        /// BSC名称
        /// </summary>
        public string BSCMC { get; set; }

        /// <summary>
        /// CSF编号
        /// </summary>
        public string CSFBH { get; set; }

        /// <summary>
        /// CSF名称
        /// </summary>
        public string CSFMC { get; set; }

        /// <summary>
        /// KPI编号
        /// </summary>
        public string KPIBH { get; set; }

        /// <summary>
        /// KPI名称
        /// </summary>
        public string KPIMC { get; set; }

        /// <summary>
        /// 上期完成值
        /// </summary>
        [DecimalPrecision]
        public decimal? SQWCZ { get; set; }

        /// <summary>
        /// 本期完成值
        /// </summary>
        [DecimalPrecision]
        public decimal? BQWCZ { get; set; }

        /// <summary>
        /// 纵向量化分
        /// </summary>
        [DecimalPrecision]
        public decimal? ZXLHF { get; set; }
    }
}
