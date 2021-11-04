using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.CollectionManage
{
    /// <summary>
    ///采集表分配
    /// </summary>
    public class BpcSp005Entity : BaseEntity
    {
        /// <summary>
        /// 无    
        /// </summary>
        public string USERID { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string XH { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string  ND { get; set; }

        /// <summary>
        /// 无    
        /// </summary>
        public string CJBBM { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public override void Create()
        {
            this.XH = Guid.NewGuid().ToString().Replace("-","");// DateTime.Now.ToString("yyyyMMddHHmmssfff");
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