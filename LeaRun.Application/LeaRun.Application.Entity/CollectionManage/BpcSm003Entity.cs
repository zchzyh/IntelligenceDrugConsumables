using LeaRun.Application.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.CollectionManage
{

    /// <summary>
    ///采集时间段表
    /// </summary>
    public partial class BpcSm003Entity : BaseEntity
    {
        /// <summary>
        /// 序号    
        /// </summary>
        public string XH { get; set; }

        /// <summary>
        /// 频率编号    
        /// </summary>
        public string PLBH { get; set; }



        /// <summary>
        /// 绩效编码
        /// </summary>
        public string JXBM { get; set; }
        
        /// <summary>
        /// 上限    
        /// </summary>
        public int SX { get; set; }

        /// <summary>
        /// 下限    
        /// </summary>
        public int XX { get; set; }

        /// <summary>
        /// 年度    
        /// </summary>
        public string ND { get; set; }

        /// <summary>
        /// 排序    
        /// </summary>
        public int PX { get; set; }

        /// <summary>
        /// 备注    
        /// </summary>
        public string REMARK { get; set; }

        /// <summary>
        /// 创建人    
        /// </summary>
        public string CREATOR { get; set; }

        /// <summary>
        /// 创建时间    
        /// </summary>
        public DateTime? CREATEAT { get; set; }

        /// <summary>
        /// 修改人    
        /// </summary>
        public string MODIFOR { get; set; }

        /// <summary>
        /// 修改时间    
        /// </summary>
        public DateTime? MODIFYAT { get; set; }

        /// <summary>
        /// 状态    
        /// </summary>
        public string STATUS { get; set; }

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.XH = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            this.CREATOR = OperatorProvider.Provider.Current().UserName;
            this.CREATEAT = DateTime.Now;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyvalue"></param>
        public override void Modify(string keyvalue)
        {
            this.MODIFOR = OperatorProvider.Provider.Current().UserName;
            this.MODIFYAT = DateTime.Now;
        }
        #endregion
    }
}