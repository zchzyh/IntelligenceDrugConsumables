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
    public class PMR002MorDeptEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 部门编码
        /// </summary>	
        public string DEPTID { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>		
        public string DEPTNAME { get; set; }
        /// <summary>
        /// 部门负责人
        /// </summary>		
        public string DEPTPRINCIPAL { get; set; }
        /// <summary>
        /// 所属机构
        /// </summary>		
        public string ORGID { get; set; }
        /// <summary>
        /// 上级部门
        /// </summary>		
        public string PARENTDEPT { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>		
        public string TEL { get; set; }
        /// <summary>
        /// 职能描述
        /// </summary>		
        public string DUTY { get; set; }
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
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.DEPTID = Guid.NewGuid().ToString().Replace("-", "");
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
            this.DEPTID = keyvalue;
            this.MODIFOR = OperatorProvider.Provider.Current().UserName;
            this.MODIFYAT = DateTime.Now;
        }
        #endregion
    }
}