using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.SettingManage
{
    /// <summary>
    /// 数据项分类信息
    /// </summary>
    public partial class BpcSM002Entity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 分类编码
        /// </summary>	
        public string TYPEID { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>		
        public string NAME { get; set; }
        /// <summary>
        /// 上级编码
        /// </summary>		
        public string PARENT { get; set; }
        /// <summary>
        /// 级别
        /// </summary>		
        public string GRADE { get; set; }
        /// <summary>
        /// 状态
        /// </summary>		
        public string STATUS { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            //TypeId采用字母加上数字格式，如：A01
            //this.TYPEID = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 20);
            this.STATUS = "1";
        }
        #endregion
    }

    public partial class BpcSM002Entity
    {
        /// <summary>
        /// 上级名称
        /// </summary>
        [NotMapped]
        public string ParentName { get; set; }
    }
}