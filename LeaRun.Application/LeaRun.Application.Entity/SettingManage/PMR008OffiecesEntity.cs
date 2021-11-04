using LeaRun.Application.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.SettingManage
{
    /// <summary>
    /// 医疗机构科室信息
    /// </summary>
    public partial class PMR008OffiecesEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 医疗机构ID
        /// </summary>
        public string ORGID { get; set; }
        /// <summary>
        /// 科室代码
        /// </summary>
        public string OFFICECODE { get; set; }
        /// <summary>
        /// 科室名称    
        /// </summary>
        public string OFFICENAME { get; set; }
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
        /// 最后修改时间
        /// </summary>
        public DateTime? MODIFYAT { get; set; }
        /// <summary>
        /// 数据行版本号
        /// </summary>
        public decimal?  VERSION { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.ID = Guid.NewGuid().ToString().Replace("-", "");
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
