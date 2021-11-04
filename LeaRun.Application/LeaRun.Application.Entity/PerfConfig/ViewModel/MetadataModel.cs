using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfConfig.ViewModel
{
    /// <summary>
    /// 元数据
    /// </summary>
    public class MetadataModel
    {
        /// <summary>
        /// 绩效年度编码
        /// </summary>
        public string JXBM { get; set; }
        /// <summary>
        /// 绩效年度
        /// </summary>	
        public string JXND { get; set; }
        /// <summary>
        /// 元数据编码
        /// </summary>		
        public string METCODE { get; set; }
        /// <summary>
        /// 元数据名称
        /// </summary>		
        public string METNAME { get; set; }
        /// <summary>
        /// 分析器编码
        /// </summary>
        public string FXQBM { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>		
        public string UNITNAME { get; set; }
        /// <summary>
        /// 运行频率
        /// </summary>		
        public string RUNFRENAME { get; set; }
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