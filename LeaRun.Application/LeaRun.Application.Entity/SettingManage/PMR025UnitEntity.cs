using LeaRun.Application.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.SettingManage
{
    /// <summary>
    /// 医疗机构注册
    /// </summary>
    public class PMR025UnitEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 单位编码
        /// </summary>
        public string UNITID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string NAME { get; set; }
        /// <summary>
        /// 上级单位
        /// </summary>
        public string PID { get; set; }
        /// <summary>
        /// 级别
        /// </summary>
        public decimal? GRADE { get; set; }
        /// <summary>
        /// 乡镇数
        /// </summary>
        public decimal? TOWNNUMBER { get; set; }
        /// <summary>
        /// 村数
        /// </summary>
        public decimal? VILLAGENUMBER { get; set; }
        /// <summary>
        /// 组数量
        /// </summary>
        public decimal? TEAMNUMBER { get; set; }
        /// <summary>
        /// 农业家庭数
        /// </summary>
        public decimal? FARMFAMILY { get; set; }
        /// <summary>
        /// 登记人数
        /// </summary>
        public decimal? RESPOPU { get; set; }
        /// <summary>
        /// 农业人口数
        /// </summary>
        public decimal? FARMPOPU { get; set; }
        /// <summary>
        /// 五保人数
        /// </summary>
        public decimal? FIVEGUARAN { get; set; }
        /// <summary>
        /// 贫困人数
        /// </summary>
        public decimal? POORPOPU { get; set; }
        /// <summary>
        /// 特困人数
        /// </summary>
        public decimal? VERYPOOR { get; set; }
        /// <summary>
        /// 流动人数
        /// </summary>
        public decimal? FLOATPOPU { get; set; }
        /// <summary>
        /// 参合人数
        /// </summary>
        public decimal? JOINPOPU { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string CONTPEOPLE { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string CONTPHONE { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string ADDRESS { get; set; }
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string POSTCODE { get; set; }
        /// <summary>
        /// 邮件
        /// </summary>
        public string EMAIL { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string STATUS { get; set; }
        /// <summary>
        /// 五笔
        /// </summary>
        public string WB { get; set; }
        /// <summary>
        /// 拼音
        /// </summary>
        public string PY { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.UNITID = Guid.NewGuid().ToString().Replace("-", "");
            this.STATUS = "1";
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyvalue"></param>
        public override void Modify(string keyvalue)
        {
            this.UNITID = keyvalue;
        }
        #endregion
    }
}