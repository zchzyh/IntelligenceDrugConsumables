using LeaRun.Application.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.SettingManage
{
    /// <summary>
    /// 医疗卫生人员表
    /// </summary>
    public partial class PMR009UserEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 标识ID
        /// </summary>	
        public string ID { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>		
        public string CARDTYPE { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>		
        public string CARDCODE { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>		
        public string NAME { get; set; }
        /// <summary>
        /// 性别
        /// </summary>		
        public string SEX { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>		
        public DateTime? BIRTHDAY { get; set; }
        /// <summary>
        /// 所属机构
        /// </summary>		
        public string ORGID { get; set; }
        /// <summary>
        /// 岗位
        /// </summary>		
        public string POST { get; set; }
        /// <summary>
        /// 科室
        /// </summary>		
        public string SECTIONOFFICE { get; set; }
        /// <summary>
        /// 科室代码
        /// </summary>		
        public string SECTIONOFFICECODE { get; set; }
        /// <summary>
        /// 职务
        /// </summary>		
        public string DUTIES { get; set; }
        /// <summary>
        /// 职称
        /// </summary>
        public string PROFESSIONAL { get; set; }  
        /// <summary>
        /// 执业证编号
        /// </summary>
        public string LICENSE { get; set; }
        /// <summary>
        /// 执业类别代码
        /// </summary>
        public string LICENSECODE { get; set; }
        /// <summary>
        /// 专业技术资格名称
        /// </summary>
        public string PROFESSIONALNAME { get; set; }
        /// <summary>
        /// 专业技术资格代码
        /// </summary>
        public string PROFESSIONALCODE { get; set; }
        /// <summary>
        /// 学历
        /// </summary>
        public string EDUCATION { get; set; }
        /// <summary>
        /// 学位  
        /// </summary>
        public string DEGREE { get; set; }
        /// <summary>
        /// 参加工作日期
        /// </summary>
        public DateTime? WORKAT { get; set; }
        /// <summary>
        /// 国籍
        /// </summary>
        public string COUNTRYCODE { get; set; }
        /// <summary>
        /// 民族信息
        /// </summary>
        public string NATIONALITYCODE { get; set; }
        /// <summary>
        /// 生效时间
        /// </summary>
        public DateTime? EFFAT { set; get; }
        /// <summary>
        /// 失效日期
        /// </summary>
        public DateTime? EXPAT { set; get; }
        /// <summary>
        /// 婚姻状况
        /// </summary>
        public string MARRIAGECODE { set; get; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string TEL { get; set; }
        /// <summary>
        /// 工作电话
        /// </summary>
        public string WORKTEL { get; set; }
        /// <summary>
        /// 电子邮件
        /// </summary>
        public string EMAIL { get; set; }
        /// <summary>
        /// 家庭地址
        /// </summary>
        public string ADDRESS { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string REMARK { get; set; }
        /// <summary>
        /// 拼音码
        /// </summary>
        public string PY { get; set; }
        /// <summary>
        /// 五笔码
        /// </summary>
        public string WB { get; set; }
        /// <summary>
        /// 是否启用(0禁用/1启用)
        /// </summary>
        public string FLAG { get; set; }
        /// <summary>
        /// 是否开通账号(0未开通，1已开通)
        /// </summary>
        public string ACCOUNT { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CREATOR { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CREATEAT { get; set; }
       
        /// <summary>
        /// 最后修改人员
        /// </summary>
        public string MODIFOR { get; set; }
        /// <summary>
        /// 最后修改日期
        /// </summary>
        public DateTime? MODIFYAT { get; set; }
        /// <summary>
        /// 数据行版本号
        /// </summary>		
        public decimal? VERSION { get; set; }
        public string CAREERNAME { get; set; }
        public string CAREERCODE { get; set; }
        public string MDUTIES { get; set; }
        public string MDUTYCODE { set; get; }
        public string DUTYCODE { set; get; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.ID = Guid.NewGuid().ToString().Replace("-", "");
            this.FLAG = "1";
            this.CREATOR = OperatorProvider.Provider.Current().UserName;
            this.CREATEAT = DateTime.Now;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyvalue"></param>
        public override void Modify(string keyvalue)
        {
            this.ID = keyvalue;
            this.MODIFOR = OperatorProvider.Provider.Current().UserName;
            this.MODIFYAT = DateTime.Now;
        }
        #endregion
    }
}
