using LeaRun.Application.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.SettingManage
{
    /// <summary>
    /// 主管机构信息
    /// </summary>
    public class PMR001MorEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// id
        /// </summary>	
        public string ID { get; set; }
        /// <summary>
        /// 机构编码
        /// </summary>		
        public string ORGID { get; set; }
        /// <summary>
        /// 机构名称
        /// </summary>		
        public string ORGNAME { get; set; }
        /// <summary>
        /// 行政区划
        /// </summary>		
        public string ADMINISTRATIVECODE { get; set; }
        /// <summary>
        /// 负责机构
        /// </summary>		
        public string MANAGERORGNAME { get; set; }
        /// <summary>
        /// 机构负责人
        /// </summary>		
        public string ORGPRI { get; set; }
        /// <summary>
        /// 隶属机构（上级主管机构）
        /// </summary>		
        public string PID { get; set; }
        /// <summary>
        /// 职能描述
        /// </summary>		
        public string DUTY { get; set; }
        /// <summary>
        /// 邮政编码
        /// </summary>		
        public string ZIPCODE { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>		
        public string TEL { get; set; }
        /// <summary>
        /// 电子邮件
        /// </summary>		
        public string EMAIL { get; set; }
        /// <summary>
        /// 通讯地址
        /// </summary>
        public string ADDRESS { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string REMARK { get; set; }
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
        /// <summary>
        /// 卫生机构类别
        /// </summary>
        public string MEDICALCARETYPE { get; set; }
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