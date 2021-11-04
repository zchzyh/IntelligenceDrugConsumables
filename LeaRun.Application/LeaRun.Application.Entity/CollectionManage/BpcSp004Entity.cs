using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.CollectionManage
{
    /// <summary>
    ///  审核权限分配  
    /// </summary>
    public class BpcSp004Entity : BaseEntity
    {
        /// <summary>
        /// 序号    
        /// </summary>
        public string XH { get; set; }

        /// <summary>
        /// 采集表编码    
        /// </summary>
        public string CJBBM { get; set; }

        /// <summary>
        /// 用户Id    
        /// </summary>
        public string USERID { get; set; }

        /// <summary>
        /// 年度    
        /// </summary>
        public string ND { get; set; }

        public override void Create()
        {
            this.XH = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }

        /// <inheritdoc />
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyvalue"></param>
        public override void Modify(string keyvalue)
        {
        }

    }

}
