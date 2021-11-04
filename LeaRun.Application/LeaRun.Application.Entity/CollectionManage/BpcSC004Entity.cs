using LeaRun.Application.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.CollectionManage
{
    /// <summary>
    /// 采集存储值表
    /// </summary>
    public class BpcSC004Entity : BaseEntity
    {
        #region 实体成员

        /// <summary>
        /// 序号
        /// </summary>
        public string XH { get; set; }

        /// <summary>
        /// 任务编号
        /// </summary>
        public string RWBH { get; set; }

        /// <summary>
        /// 采集表编码
        /// </summary>
        public string CJBBM { get; set; }

        /// <summary>
        /// 年度
        /// </summary>
        public decimal JXND { get; set; }

        /// <summary>
        /// 月度
        /// </summary>
        public decimal JXYD { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string ORGID { get; set; }

        /// <summary>
        /// 列
        /// </summary>
        public string LCODE { get; set; }

        /// <summary>
        /// 行
        /// </summary>
        public string HCODE { get; set; }

        /// <summary>
        /// 存储值
        /// </summary>
        [DecimalPrecision]
        public decimal CCVALUE { get; set; }

        /// <summary>
        /// 系数值
        /// </summary>
        [DecimalPrecision]
        public decimal XSVALUE { get; set; }

        /// <summary>
        /// 补录值
        /// </summary>
        [DecimalPrecision]
        public decimal BLVALUE { get; set; }

        /// <summary>
        /// 实际值
        /// </summary>
        [DecimalPrecision]
        public decimal? SJVALUE { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CREATOR { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>		
        public DateTime? CREATEAT { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>		
        public string MODIFOR { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? MODIFYAT { get; set; }

        /// <summary>
        /// 状态(0删除/1正常)
        /// </summary>		
        public string STATUS { get; set; }

        #endregion

        #region 扩展操作

        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.XH = Guid.NewGuid().ToString().Replace("-", "");
            this.CREATOR = OperatorProvider.Provider.Current().UserName;
            this.CREATEAT = DateTime.Now;
            this.STATUS = "1";
        }

        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyvalue"></param>
        public override void Modify(string keyvalue)
        {
            this.XH = keyvalue;
            this.MODIFOR = OperatorProvider.Provider.Current().UserName;
            this.MODIFYAT = DateTime.Now;
        }

        #endregion
    }
}
