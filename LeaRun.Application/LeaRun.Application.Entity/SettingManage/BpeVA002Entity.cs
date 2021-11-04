using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.SettingManage
{
    /// <summary>
    /// 维度基本信息
    /// </summary>
    public class BpeVA002Entity : BaseEntity
    {
        /// <summary>
        /// 维度信息编号
        /// </summary>
        public string BSCBH { get; set; }
        /// <summary>
        /// 维度信息名称
        /// </summary>
        public string BSCMC { get; set; }
        /// <summary>
        /// 维度信息描述
        /// </summary>
        public string BSCMS { get; set; }

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.BSCBH = Guid.NewGuid().ToString().Replace("-", "");
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyvalue"></param>
        public override void Modify(string keyvalue)
        {
            this.BSCBH = keyvalue;
        }
        #endregion
    }
}