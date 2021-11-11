using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.BusinessManage
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PantientInfoEntity : BaseEntity
    {
        /// <summary>
        /// 唯一标识号    
        /// </summary>
        public string CASE_NUM { get; set; }

        /// <summary>
        /// 姓名    
        /// </summary>
        public string NAME { get; set; }

        /// <summary>
        /// 性别    
        /// </summary>
        public string SEX_CODE { get; set; }

        /// <summary>
        /// 年龄    
        /// </summary>
        public string AGE { get; set; }

        /// <summary>
        /// 年龄（月）    
        /// </summary>
        public string AGE_MONTH { get; set; }

        /// <summary>
        /// 年龄（天）    
        /// </summary>
        public string AGE_DAY { get; set; }

        /// <summary>
        /// 年龄（小时）    
        /// </summary>
        public string AGE_HOUR { get; set; }

        /// <summary>
        /// 健康卡号    
        /// </summary>
        public string HEALTH_CARD_NUM { get; set; }

        /// <summary>
        /// 医疗保险号    
        /// </summary>
        public string INSURANCE_NUM { get; set; }

        /// <summary>
        /// 身份证号    
        /// </summary>
        public string ID_NUM { get; set; }

        /// <summary>
        /// 住址    
        /// </summary>
        public string ADDRESS { get; set; }

        /// <summary>
        /// 电话    
        /// </summary>
        public string TEL { get; set; }

        /// <summary>
        /// 婚姻状况    
        /// </summary>
        public string MARITAL_STATUS_CODE { get; set; }

        /// <summary>
        /// 出生日期    
        /// </summary>
        public DateTime? BIRTHDAY { get; set; }

        /// <summary>
        /// 民族    
        /// </summary>
        public string NATION_CODE { get; set; }

        /// <summary>
        /// 国籍    
        /// </summary>
        public string COUNTRY_CODE { get; set; }

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            //this.CREATOR = OperatorProvider.Provider.Current().UserName;
            //this.CREATEAT = DateTime.Now;
            //this.STATUS = "1";
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyvalue"></param>
        public override void Modify(string keyvalue)
        {
            //this.JCSJBM = keyvalue;
            //this.MODIFOR = OperatorProvider.Provider.Current().UserName;
            //this.MODIFYAT = DateTime.Now;
        }
        #endregion
    }
}