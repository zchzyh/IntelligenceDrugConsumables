using LeaRun.Application.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.SettingManage
{
    /// <summary>
    /// 基础数据版本
    /// </summary>
    public class S102VerEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 基础数据字典分类编码
        /// </summary>	
        public string TYPEID { get; set; }
        /// <summary>
        /// 基础数据版本编码
        /// </summary>		
        public string VERID { get; set; }
        /// <summary>
        /// 状态
        /// </summary>		
        public string STATUS { get; set; }
        /// <summary>
        /// 描述
        /// </summary>		
        public string DESCRIPTION { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>		
        public string CREATOR { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>		
        public DateTime? CREATEDATE { get; set; }
        /// <summary>
        /// 最后修改人
        /// </summary>		
        public string MODIFOR { get; set; }
        /// <summary>
        /// 最后修改日期
        /// </summary>
        public DateTime? MODIFYDATE { get; set; }
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
            this.CREATOR = OperatorProvider.Provider.Current().UserName;
            this.CREATEDATE = DateTime.Now;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyvalues"></param>
        public override void Modify(string[] keyvalues)
        {
            this.TYPEID = keyvalues[0];
            this.VERID = keyvalues[1];
            this.MODIFOR = OperatorProvider.Provider.Current().UserName;
            this.MODIFYDATE = DateTime.Now;
        }
        #endregion
    }
}