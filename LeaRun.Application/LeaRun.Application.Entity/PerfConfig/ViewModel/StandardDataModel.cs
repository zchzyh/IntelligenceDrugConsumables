using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfConfig.ViewModel
{
    /// <summary>
    /// 数据项列表信息
    /// </summary>
    public class StandardDataModel
    {
        /// <summary>
        /// 基础数据编码
        /// </summary>		
        public string JCSJBM { get; set; }
        /// <summary>
        /// 基础数据名称
        /// </summary>		
        public string JCSJMC { get; set; }
        /// <summary>
        /// 分析器编码
        /// </summary>
        public string FXQBM { get; set; }
        /// <summary>
        /// 调节系数
        /// </summary>
        [DecimalPrecision]
        public decimal? TJXS { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>		
        public string JLDWNAME { get; set; }
        /// <summary>
        /// 运行频率
        /// </summary>		
        public string YXPLNAME { get; set; }
        /// <summary>
        /// 一级分类
        /// </summary>
        public string TYPENAME { get; set; }
        /// <summary>
        /// 二级分类
        /// </summary>
        public string SECTYPENAME { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public string PX { get; set; }
        /// <summary>
        /// 状态(0删除/1正常)
        /// </summary>
        public string STATUS { get; set; }
    }
}