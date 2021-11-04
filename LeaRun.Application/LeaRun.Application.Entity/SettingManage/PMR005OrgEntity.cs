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
    public class PMR005OrgEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 医疗机构ID
        /// </summary>	
        public string ORGID { get; set; }
        /// <summary>
        /// 机构编码
        /// </summary>		
        public string ORGCODE { get; set; }
        /// <summary>
        /// 机构名称
        /// </summary>		
        public string MANAGERORGNAME { get; set; }
        /// <summary>
        /// 简称
        /// </summary>		
        public string SHORTNAME { get; set; }
        /// <summary>
        /// 机构级别
        /// </summary>		
        public string ORGLEV { get; set; }
        /// <summary>
        /// 机构等级
        /// </summary>		
        public string ORGGRADE { get; set; }
        /// <summary>
        /// 隶属关系
        /// </summary>		
        public string BELONGTO { get; set; }
        /// <summary>
        /// 法人代表
        /// </summary>		
        public string CORPORATE { get; set; }
        /// <summary>
        /// 卫生机构类别
        /// </summary>		
        public string MEDICALCARETYPE { get; set; }
        /// <summary>
        /// 经济类型代码
        /// </summary>		
        public string ECONOMICCODE { get; set; }
        /// <summary>
        /// 机构分类代码
        /// </summary>		
        public string TYPECODE { get; set; }
        /// <summary>
        /// 行政区划代码
        /// </summary>
        public string ADMINISTRATIVECODE { get; set; }
        /// <summary>
        /// 注册资金
        /// </summary>
        [DecimalPrecision]
        public decimal? REGMONEY { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string ADDRESS { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string TEL { get; set; }
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string ZIPCODE { get; set; }
        /// <summary>
        /// 电子邮件
        /// </summary>
        public string EMAIL { get; set; }
        /// <summary>
        /// 主办单位
        /// </summary>
        public string HOSTUNIT { get; set; }
        /// <summary>
        /// 成立日期
        /// </summary>
        public string REGAT { get; set; }
        /// <summary>
        /// 单位网址
        /// </summary>
        public string COMPURL { get; set; }
        /// <summary>
        /// 是否属民族自治(1:是0:否)
        /// </summary>
        public string SWARAJ { get; set; }
        /// <summary>
        /// 民族信息
        /// </summary>
        public string SWARAJINFO { get; set; }
        /// <summary>
        /// 编制床位数
        /// </summary>
        public decimal? BEDNUM { get; set; }
        /// <summary>
        /// 实有床位数
        /// </summary>
        public decimal? REALBEDNUM { get; set; }
        /// <summary>
        /// 人员数
        /// </summary>
        public decimal? PERSONS { get; set; }
        /// <summary>
        /// 卫技人员数
        /// </summary>
        public decimal? MEDICALS { get; set; }
        /// <summary>
        /// 诊疗科室数
        /// </summary>
        public decimal? SECTIONOFFICES { get; set; }
        /// <summary>
        /// 下设卫生所个数
        /// </summary>
        public decimal? CLINICS { get; set; }
        /// <summary>
        /// 购建房屋建筑面积(单位：平方米)
        /// </summary>
        public decimal? HOUSEAREA { get; set; }
        /// <summary>
        /// 租房面积(单位：平方米)
        /// </summary>
        public decimal? RENTINGAREA { get; set; }
        /// <summary>
        /// 万员以上设备数(单位：台)
        /// </summary>
        public decimal? EQUIS { get; set; }
        /// <summary>
        /// 50~100万员设备数(单位：台)
        /// </summary>
        public decimal? EQUITENS { get; set; }
        /// <summary>
        /// 100万以上设备数(单位：台)
        /// </summary>
        public decimal? EQUIHANS { get; set; }
        /// <summary>
        /// 总资产(单位：万元)
        /// </summary>
        public decimal? TOTALMONEY { get; set; }
        /// <summary>
        /// 固定资产(单位：万元)
        /// </summary>
        public decimal? FIXMONEY { get; set; }
        /// <summary>
        /// 是否分院(1:是0：否)
        /// </summary>
        public string BRANCH { get; set; }
        /// <summary>
        /// 总院（医疗机构）
        /// </summary>
        public string PARENTORG { get; set; }
        /// <summary>
        /// 是否定点医院(1：是0：否)
        /// </summary>
        public string FIXPOINT { get; set; }
        /// <summary>
        /// 定点类型编码(多个定点类型以‘,’隔开)
        /// </summary>
        public string FIXPOINTCODE { get; set; }
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
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.ORGID = Guid.NewGuid().ToString().Replace("-", "");
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
            this.ORGID = keyvalue;
            this.MODIFOR = OperatorProvider.Provider.Current().UserName;
            this.MODIFYAT = DateTime.Now;
        }
        #endregion
    }
}